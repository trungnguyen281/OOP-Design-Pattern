using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOFramework
{
    public class SqlQuery : IQuery
    {
        protected string _connectionString;
        protected SqlCommand _cmd;
        protected string _query;

        public SqlQuery(SqlConnection cnn, string connectionString)
        {
            _connectionString = connectionString;
            _cmd = new SqlCommand();
            _cmd.Connection = cnn;
            _cmd.CommandType = CommandType.Text;
        }

        public SqlQuery(SqlConnection cnn, string connectionString, string query)
        {
            _connectionString = connectionString;
            _cmd = new SqlCommand();
            _cmd.Connection = cnn;
            _cmd.CommandType = CommandType.Text;
            _query = query;
        }

        public List<T> ExecuteQuery<T>() where T : new()
        {
            _cmd.CommandText = _query;

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(_cmd);
            adapter.Fill(dt);

            List<T> res = new List<T>();
            SCOSqlConnection cnn = new SCOSqlConnection(_connectionString);
            SqlMapper mapper = new SqlMapper();

            foreach (DataRow dr in dt.Rows)
                res.Add(mapper.MapWithRelationship<T>(cnn, dr));

            return res;
        }

        public List<T> ExecuteQueryWithOutRelationship<T>() where T : new()
        {
            _cmd.CommandText = _query;

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(_cmd);
            adapter.Fill(dt);

            List<T> res = new List<T>();
            SCOSqlConnection cnn = new SCOSqlConnection(_connectionString);
            SqlMapper mapper = new SqlMapper();

            foreach (DataRow dr in dt.Rows)
                res.Add(mapper.MapWithOutRelationship<T>(cnn, dr));

            return res;
        }

        public int ExecuteNonQuery()
        {
            _cmd.CommandText = _query;
            return _cmd.ExecuteNonQuery();
        }
    }
}
