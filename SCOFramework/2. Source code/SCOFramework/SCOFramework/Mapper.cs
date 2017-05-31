using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SCOFramework
{
    public class Mapper
    {
        public static T MapToObject<T>(DataRow dr) where T : new()
        {
            T obj = new T();
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(DBColumnAttribute));

                if (columnMapping != null)
                {
                    var mapsTo = columnMapping as DBColumnAttribute;
                    property.SetValue(obj, dr[mapsTo.Name]);
                }
            }

            return obj;
        }
    }
}