using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SCOFramework
{
    public abstract class Mapper
    {
        public T MapWithRelationship<T>(SCOSqlConnection cnn, DataRow dr) where T : new()
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
            MapToOne(cnn, dr, obj);

            return obj;
        }

        public T MapWithOutRelationship<T>(SCOSqlConnection cnn, DataRow dr) where T : new()
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

        protected abstract void MapOneToMany<T>(SCOSqlConnection cnn, DataRow dr, T obj) where T : new();
        protected abstract void MapToOne<T>(SCOSqlConnection cnn, DataRow dr, T obj) where T : new();

        public string GetTableName<T>() where T : new()
        {
            var tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;

            if (tableAttribute != null)
                return tableAttribute.Name;
            return string.Empty;
        }

        public List<PrimaryKeyAttribute> GetPrimaryKeys<T>() where T : new()
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

        public List<ForeignKeyAttribute> GetForeignKeys<T>() where T : new()
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

        public List<ColumnAttribute> GetColumns<T>() where T : new()
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

        public Dictionary<ColumnAttribute, object> GetColumnValues<T>(T obj)
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

        public ColumnAttribute FindColumn(string name, Dictionary<ColumnAttribute, object> listColumValues)
        {
            foreach (ColumnAttribute column in listColumValues.Keys)
                if (column.Name == name)
                    return column;
            return null;
        }

        public ColumnAttribute FindColumn(string name, List<ColumnAttribute> listColumAttributes)
        {
            foreach (ColumnAttribute column in listColumAttributes)
                if (column.Name == name)
                    return column;
            return null;
        }

        public T GetFirst<T>(IEnumerable source)
        {
            List<T> list = source.Cast<T>().ToList();
            if (list != null && list.Count != 0)
                return list[0];
            return default(T);
        }
    }
}