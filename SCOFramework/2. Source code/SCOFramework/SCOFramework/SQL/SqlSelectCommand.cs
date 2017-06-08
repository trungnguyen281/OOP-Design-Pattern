using System.Collections.Generic;
using System.Data.SqlClient;

namespace SCOFramework
{
    public class SelectSqlCommand : SCOSqlCommand, SelectCommand
    {
        private SelectSqlCommand(SqlConnection cnn) : base(cnn)
        {
        }

        public static ICanAddSelect Create(SqlConnection cnn)
        {
            return new SelectSqlCommand(cnn);
        }

        public ICanAddFrom Select(string selectedColumn)
        {
            _query += "SELECT " + selectedColumn;
            return this;
        }

        public ICanAddWhere From(string tableName)
        {
            _query += " FROM " + tableName;
            return this;
        }

        public ICanAddHavingOrRun AllRows()
        {
            return this;
        }

        public ICanAddHavingOrRun Where(string condition)
        {
            _query += " WHERE " + condition;
            return this;
        }

        public ICanAddExecuteReader GroupBy(string columnName)
        {
            _query += " GROUP BY " + columnName;
            return this;
        }

        public ICanAddGroupBy Having(string condition)
        {
            _query += " HAVING " + condition;
            return this;
        }

        public List<T> Execute<T>() where T : new()
        {
            return base.ExecuteReader<T>();
        }
    }
}
