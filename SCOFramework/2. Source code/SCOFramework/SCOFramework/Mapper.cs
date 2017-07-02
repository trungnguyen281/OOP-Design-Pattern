using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SCOFramework
{
    public class Mapper
    {
        public static T MapWithRelationship<T>(SCOSqlConnection cnn, DataRow dr) where T : new()
        {
            T obj = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute));
                if (columnMapping != null)
                {
                    var mapsTo = columnMapping as ColumnAttribute;
                    property.SetValue(obj, dr[mapsTo.Name]);
                }
            }

            MapOneToMany(cnn, dr, obj);
            MapManyToOne(cnn, dr, obj);

            return obj;
        }

        public static T MapWithOutRelationship<T>(SCOSqlConnection cnn, DataRow dr) where T : new()
        {
            T obj = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute));
                if (columnMapping != null)
                {
                    var mapsTo = columnMapping as ColumnAttribute;
                    property.SetValue(obj, dr[mapsTo.Name]);
                }
            }

            return obj;
        }

        private static void MapOneToMany<T>(SCOSqlConnection cnn, DataRow dr, T obj) where T : new()
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                var oneToManyAttributes = attributes.Where(a => a.GetType() == typeof(OneToManyAttribute)).ToList();
                if (oneToManyAttributes != null && oneToManyAttributes.Count != 0)
                {
                    foreach (OneToManyAttribute oneToManyAttribute in oneToManyAttributes)
                    {
                        Type type = property.PropertyType;
                        if (type.IsGenericType)
                        {
                            cnn.Open();
                            Type itemType = type.GetGenericArguments()[0];

                            MethodInfo getTableNameMethod = typeof(Mapper).GetMethod("GetTableName")
                               .MakeGenericMethod(new Type[] { itemType });
                            string tableName = getTableNameMethod.Invoke(typeof(Mapper), null) as string;

                            MethodInfo getForeignKeyAttributeMethod = typeof(Mapper).GetMethod("GetForeignKey")
                                .MakeGenericMethod(new Type[] { itemType });
                            List<ForeignKeyAttribute> foreignKeyAttributes = getForeignKeyAttributeMethod.Invoke(typeof(Mapper), null) as List<ForeignKeyAttribute>;

                            MethodInfo getColumnAttributeMethod = typeof(Mapper).GetMethod("GetColumnAttribute")
                                .MakeGenericMethod(typeof(T));
                            List<ColumnAttribute> columnAttributes = getColumnAttributeMethod.Invoke(typeof(Mapper), null) as List<ColumnAttribute>;

                            string whereStr = string.Empty;

                            foreach (ForeignKeyAttribute foreignKeyAttribute in foreignKeyAttributes.Where(k => k.RelationshipID == oneToManyAttribute.RelationshipID))
                            {
                                ColumnAttribute column = FindColumnAttribute(foreignKeyAttribute.References, columnAttributes);
                                if (column != null)
                                {
                                    string format = "{0} = {1}, ";
                                    if (column.Type == DataType.NCHAR || column.Type == DataType.NVARCHAR)
                                        format = "{0} = N'{1}', ";
                                    else if (column.Type == DataType.CHAR || column.Type == DataType.VARCHAR)
                                        format = "{0} = '{1}', ";

                                    whereStr += string.Format(format, foreignKeyAttribute.Name, dr[foreignKeyAttribute.References]);
                                }
                            }
                            if (!string.IsNullOrEmpty(whereStr))
                            {
                                whereStr = whereStr.Substring(0, whereStr.Length - 2);
                                string query = string.Format("SELECT * FROM {0} WHERE {1}", tableName, whereStr);

                                MethodInfo method = cnn.GetType().GetMethod("ExecuteQueryWithOutRelationship")
                                .MakeGenericMethod(new Type[] { itemType });
                                property.SetValue(obj, method.Invoke(cnn, new object[] { query }));
                            }

                            cnn.Close();
                        }
                    }
                }
            }
        }

        private static void MapManyToOne<T>(SCOSqlConnection cnn, DataRow dr, T obj) where T : new()
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                Type type = property.PropertyType;
                var attributes = property.GetCustomAttributes(false);
                
                var manyToOneAttributes = attributes.Where(a => a.GetType() == typeof(ManyToOneAttribute)).ToList();
                if (manyToOneAttributes != null && manyToOneAttributes.Count != 0)
                {
                    foreach (ManyToOneAttribute manyToOneAttribute in manyToOneAttributes)
                    {
                        cnn.Open();

                        MethodInfo getForeignKeyAttributeMethod = typeof(Mapper).GetMethod("GetForeignKey")
                            .MakeGenericMethod(typeof(T));
                        List<ForeignKeyAttribute> foreignKeyAttributes = getForeignKeyAttributeMethod.Invoke(typeof(Mapper), null) as List<ForeignKeyAttribute>;

                        MethodInfo getColumnAttributeMethod = typeof(Mapper).GetMethod("GetColumnAttribute")
                            .MakeGenericMethod(new Type[] { type });

                        List<ColumnAttribute> columnAttributes = getColumnAttributeMethod.Invoke(typeof(Mapper), null) as List<ColumnAttribute>;

                        string whereStr = string.Empty;

                        foreach (ForeignKeyAttribute foreignKeyAttribute in foreignKeyAttributes.Where(k => k.RelationshipID == manyToOneAttribute.RelationshipID))
                        {
                            ColumnAttribute column = FindColumnAttribute(foreignKeyAttribute.References, columnAttributes);
                            if (column != null)
                            {
                                string format = "{0} = {1}, ";
                                if (column.Type == DataType.NCHAR || column.Type == DataType.NVARCHAR)
                                    format = "{0} = N'{1}', ";
                                else if (column.Type == DataType.CHAR || column.Type == DataType.VARCHAR)
                                    format = "{0} = '{1}', ";

                                whereStr += string.Format(format, foreignKeyAttribute.References, dr[foreignKeyAttribute.Name]);
                            }
                        }
                        if (!string.IsNullOrEmpty(whereStr))
                        {
                            whereStr = whereStr.Substring(0, whereStr.Length - 2);
                            string query = string.Format("SELECT * FROM {0} WHERE {1}", manyToOneAttribute.TableName, whereStr);

                            MethodInfo method = cnn.GetType().GetMethod("ExecuteQueryWithOutRelationship")
                            .MakeGenericMethod(new Type[] { type });
                            var ienumerable = (IEnumerable)method.Invoke(cnn, new object[] { query });

                            MethodInfo method2 = typeof(Mapper).GetMethod("GetFirst")
                            .MakeGenericMethod(new Type[] { type });
                            var firstElement = method2.Invoke(typeof(Mapper), new object[] { ienumerable });

                            property.SetValue(obj, firstElement);
                        }

                        cnn.Close();
                    }
                }
            }
        }

        public static string GetTableName<T>() where T : new()
        {
            var tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;

            if (tableAttribute != null)
                return tableAttribute.Name;
            return string.Empty;
        }

        public static List<PrimaryKeyAttribute> GetPrimaryKey<T>() where T : new()
        {
            List<PrimaryKeyAttribute> primaryKeys = new List<PrimaryKeyAttribute>();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                var primaryKeyAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(PrimaryKeyAttribute));
                if (primaryKeyAttribute != null)
                    primaryKeys.Add(primaryKeyAttribute as PrimaryKeyAttribute);
            }

            if (primaryKeys.Count > 0)
                return primaryKeys;
            else
                return null;
        }

        public static List<ForeignKeyAttribute> GetForeignKey<T>() where T : new()
        {
            List<ForeignKeyAttribute> foreignKeys = new List<ForeignKeyAttribute>();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                var foreignKeyAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(ForeignKeyAttribute));
                if (foreignKeyAttribute != null)
                foreignKeys.Add(foreignKeyAttribute as ForeignKeyAttribute);
            }

            if (foreignKeys.Count > 0)
                return foreignKeys;
            else
                return null;
        }

        public static List<ColumnAttribute> GetColumnAttribute<T>() where T : new()
        {
            List<ColumnAttribute> columnAttributes = new List<ColumnAttribute>();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute));

                if (columnMapping != null)
                {
                    var mapsTo = columnMapping as ColumnAttribute;
                    columnAttributes.Add(mapsTo);
                }
            }

            if (columnAttributes.Count > 0)
                return columnAttributes;
            else
                return null;
        }

        public static Dictionary<ColumnAttribute, object> GetColumnValues<T>(T obj)
        {
            Dictionary<ColumnAttribute, object> listColumnValues = new Dictionary<ColumnAttribute, object>();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute));

                if (columnMapping != null)
                {
                    var mapsTo = columnMapping as ColumnAttribute;
                    listColumnValues.Add(mapsTo, property.GetValue(obj, null));
                }
            }

            if (listColumnValues.Count > 0)
                return listColumnValues;
            else
                return null;
        }

        public static ColumnAttribute FindColumnAttribute(string name, Dictionary<ColumnAttribute, object> listColumValues)
        {
            foreach (ColumnAttribute column in listColumValues.Keys)
                if (column.Name == name)
                    return column;
            return null;
        }

        public static ColumnAttribute FindColumnAttribute(string name, List<ColumnAttribute> listColumAttributes)
        {
            foreach (ColumnAttribute column in listColumAttributes)
                if (column.Name == name)
                    return column;
            return null;
        }

        public static T GetFirst<T>(IEnumerable students)
        {
            List<T> list = students.Cast<T>().ToList();
            return list[0];
        }
    }
}