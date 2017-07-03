﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCOFramework
{
    public class SqlMapper : Mapper
    {
        protected override void MapOneToMany<T>(SCOSqlConnection cnn, DataRow dr, T obj)
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
                            Type itemType = type.GetGenericArguments()[0];
                            SqlMapper mapper = new SqlMapper();

                            MethodInfo getTableNameMethod = mapper.GetType().GetMethod("GetTableName")
                               .MakeGenericMethod(new Type[] { itemType });
                            string tableName = getTableNameMethod.Invoke(mapper, null) as string;

                            MethodInfo getForeignKeyAttributeMethod = mapper.GetType().GetMethod("GetForeignKeys")
                                .MakeGenericMethod(new Type[] { itemType });
                            List<ForeignKeyAttribute> foreignKeyAttributes = getForeignKeyAttributeMethod.Invoke(mapper, null) as List<ForeignKeyAttribute>;

                            MethodInfo getColumnAttributeMethod = mapper.GetType().GetMethod("GetColumns")
                                .MakeGenericMethod(typeof(T));
                            List<ColumnAttribute> columnAttributes = getColumnAttributeMethod.Invoke(mapper, null) as List<ColumnAttribute>;

                            string whereStr = string.Empty;

                            foreach (ForeignKeyAttribute foreignKeyAttribute in foreignKeyAttributes.Where(k => k.RelationshipID == oneToManyAttribute.RelationshipID))
                            {
                                ColumnAttribute column = FindColumn(foreignKeyAttribute.References, columnAttributes);
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

                                cnn.Open();
                                MethodInfo method = cnn.GetType().GetMethod("ExecuteQueryWithOutRelationship")
                                .MakeGenericMethod(new Type[] { itemType });
                                property.SetValue(obj, method.Invoke(cnn, new object[] { query }));
                                cnn.Close();
                            }
                        }
                    }
                }
            }
        }

        protected override void MapToOne<T>(SCOSqlConnection cnn, DataRow dr, T obj)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                Type type = property.PropertyType;
                var attributes = property.GetCustomAttributes(false);

                var toOneAttributes = attributes.Where(a => a.GetType() == typeof(OneToOneAttribute) || a.GetType() == typeof(ManyToOneAttribute)).ToList();
                if (toOneAttributes != null && toOneAttributes.Count != 0)
                {
                    foreach (var attribute in toOneAttributes)
                    {
                        SqlMapper mapper = new SqlMapper();

                        MethodInfo getForeignKeyAttributeMethod = mapper.GetType().GetMethod("GetForeignKeys")
                            .MakeGenericMethod(typeof(T));
                        List<ForeignKeyAttribute> foreignKeyAttributes = getForeignKeyAttributeMethod.Invoke(mapper, null) as List<ForeignKeyAttribute>;

                        MethodInfo getColumnAttributeMethod = mapper.GetType().GetMethod("GetColumns")
                            .MakeGenericMethod(new Type[] { type });

                        List<ColumnAttribute> columnAttributes = getColumnAttributeMethod.Invoke(mapper, null) as List<ColumnAttribute>;

                        string tableName = string.Empty;
                        string whereStr = string.Empty;

                        if (attribute.GetType() == typeof(OneToOneAttribute))
                        {
                            foreignKeyAttributes = foreignKeyAttributes.Where(k => k.RelationshipID == (attribute as OneToOneAttribute).RelationshipID).ToList();
                            tableName = (attribute as OneToOneAttribute).TableName;
                        }
                        else
                        {
                            foreignKeyAttributes = foreignKeyAttributes.Where(k => k.RelationshipID == (attribute as ManyToOneAttribute).RelationshipID).ToList();
                            tableName = (attribute as ManyToOneAttribute).TableName;
                        }

                        foreach (ForeignKeyAttribute foreignKeyAttribute in foreignKeyAttributes)
                        {
                            ColumnAttribute column = FindColumn(foreignKeyAttribute.References, columnAttributes);
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
                            string query = string.Format("SELECT * FROM {0} WHERE {1}", tableName, whereStr);

                            cnn.Open();
                            MethodInfo method = cnn.GetType().GetMethod("ExecuteQueryWithOutRelationship")
                            .MakeGenericMethod(new Type[] { type });
                            var ienumerable = (IEnumerable)method.Invoke(cnn, new object[] { query });
                            cnn.Close();

                            MethodInfo method2 = mapper.GetType().GetMethod("GetFirst")
                            .MakeGenericMethod(new Type[] { type });
                            var firstElement = method2.Invoke(mapper, new object[] { ienumerable });

                            property.SetValue(obj, firstElement);
                        }   
                    }
                }
            }
        }
    }
}
