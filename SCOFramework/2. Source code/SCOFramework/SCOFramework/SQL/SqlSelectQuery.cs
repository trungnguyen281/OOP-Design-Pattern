using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace SCOFramework
{
    public class SelectSqlQuery<T> : SqlQuery,  ICanAddWhere<T>, ICanAddHavingOrRun<T>, ICanAddGroupBy<T>, ICanAddRun<T> where T : new()
    {
        private SelectSqlQuery(SqlConnection cnn, string connectionString) : base(cnn, connectionString)
        {
            _query += "SELECT";
            foreach (ColumnAttribute column in Mapper.GetColumnAttribute<T>())
                _query = string.Format("{0} {1},", _query, column.Name);

            _query = _query.Substring(0, _query.Length - 1);

            _query = string.Format("{0} FROM {1}", _query, Mapper.GetTableName<T>());
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

        public ICanAddHavingOrRun<T> GroupBy(string columnNames)
        {
            _query = string.Format("{0} GROUP BY {1}", _query, columnNames);
            return this;
        }

        public ICanAddGroupBy<T> Having(string condition)
        {
            _query = string.Format("{0} HAVING {1}", _query, condition);
            return this;
        }

        public List<T> Run()
        {
            return ExecuteQuery<T>();
        }
    }

    public interface ICanAddWhere<T> where T : new()
    {
        ICanAddHavingOrRun<T> Where(string condition);
        ICanAddHavingOrRun<T> AllRow();
    }

    public interface ICanAddHavingOrRun<T> where T : new()
    {
        ICanAddGroupBy<T> Having(string condition);
        List<T> Run();
    }

    public interface ICanAddGroupBy<T> where T : new()
    {
        ICanAddHavingOrRun<T> GroupBy(string columnName);
    }

    public interface ICanAddRun<T> where T : new()
    {
        List<T> Run();
    }
}
