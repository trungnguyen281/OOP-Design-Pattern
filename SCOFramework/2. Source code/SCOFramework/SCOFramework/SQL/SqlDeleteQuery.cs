using System.Collections.Generic;
using System.Data.SqlClient;

namespace SCOFramework
{
    public class SqlDeleteQuery<T> : SqlQuery where T : new()
    {
        public SqlDeleteQuery(SqlConnection cnn, string connectionString, T obj) : base(cnn, connectionString)
        {
            SqlMapper mapper = new SqlMapper();
            string tableName = mapper.GetTableName<T>();
            List<PrimaryKeyAttribute> primaryKeys = mapper.GetPrimaryKeys<T>();
            Dictionary<ColumnAttribute, object> listColumnValues = mapper.GetColumnValues<T>(obj);

            string whereStr = string.Empty;
            foreach (PrimaryKeyAttribute primaryKey in primaryKeys)
            {
                ColumnAttribute column = mapper.FindColumn(primaryKey.Name, listColumnValues);
                if (column != null)
                {
                    string format = "{0} = {1}, ";
                    if (column.Type == DataType.NCHAR || column.Type == DataType.NVARCHAR)
                        format = "{0} = N'{1}', ";
                    else if (column.Type == DataType.CHAR || column.Type == DataType.VARCHAR)
                        format = "{0} = '{1}', ";

                    whereStr += string.Format(format, primaryKey.Name, listColumnValues[column]);
                }
            }
            if (!string.IsNullOrEmpty(whereStr))
            {
                whereStr = whereStr.Substring(0, whereStr.Length - 2);
                _query = string.Format("DELETE {0} WHERE {1}", tableName, whereStr);
            } 
        }
    }
}
