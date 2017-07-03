using System.Collections.Generic;
using System.Data.SqlClient;

namespace SCOFramework
{
    public class SelectSqlQuery<T> : SqlQuery,  ICanAddWhere<T>, ICanAddHavingOrRun<T>, ICanAddGroupBy<T>, ICanRun<T> where T : new()
    {
        private SelectSqlQuery(SqlConnection cnn, string connectionString) : base(cnn, connectionString)
        {
            SqlMapper mapper = new SqlMapper();
            _query += "SELECT";
            foreach (ColumnAttribute column in mapper.GetColumns<T>())
                _query = string.Format("{0} {1},", _query, column.Name);

            _query = _query.Substring(0, _query.Length - 1);

            _query = string.Format("{0} FROM {1}", _query, mapper.GetTableName<T>());
        }

        public static ICanAddWhere<T> Create(SqlConnection cnn, string connectionString)
        {
            return new SelectSqlQuery<T>(cnn, connectionString);
        }

        public ICanAddHavingOrRun<T> Where(string condition)
        {
            _query = string.Format("{0} WHERE {1}", _query, condition);
            return this;
        }

        public ICanAddHavingOrRun<T> AllRow()
        {
            return this;
        }

        public ICanAddGroupBy<T> Having(string condition)
        {
            _query = string.Format("{0} HAVING {1}", _query, condition);
            return this;
        }

        public ICanRun<T> GroupBy(string columnNames)
        {
            _query = string.Format("{0} GROUP BY {1}", _query, columnNames);
            return this;
        }

        public List<T> Run()
        {
            return ExecuteQuery<T>();
        }
    }
}
