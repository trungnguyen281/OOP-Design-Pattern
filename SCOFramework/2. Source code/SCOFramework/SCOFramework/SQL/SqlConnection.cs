using System;
using System.Collections.Generic;
using SqlClient = System.Data.SqlClient;

namespace SCOFramework
{
    public class SCOSqlConnection : SCOConnection
    {
        private SqlClient.SqlConnection _cnn;

        public SCOSqlConnection(string connectionString)
        {
            _connectionString = connectionString;
            _cnn = new SqlClient.SqlConnection(connectionString);
        }

        public override void Open()
        {
            if (_cnn.State != System.Data.ConnectionState.Open)
                _cnn.Open();
        }

        public override void Close()
        {
            if (_cnn.State != System.Data.ConnectionState.Closed)
                _cnn.Close();
        }

        public override ICanAddWhere<T> Select<T>()
        {
            return SelectSqlQuery<T>.Create(_cnn, _connectionString);
        }

        public override void Insert<T>(T obj)
        {
            SqlInsertQuery<T> query = new SqlInsertQuery<T>(_cnn, _connectionString, obj);
            query.ExecuteNonQuery();
        }

        public override void Update<T>(T obj)
        {
            SqlUpdateQuery<T> query = new SqlUpdateQuery<T>(_cnn, _connectionString, obj);
            query.ExecuteNonQuery();
        }

        public override void Delete<T>(T obj)
        {
            SqlDeleteQuery<T> query = new SqlDeleteQuery<T>(_cnn, _connectionString, obj);
            query.ExecuteNonQuery();
        }

        public override List<T> ExecuteQuery<T>(string queryString)
        {
            SqlQuery query = new SqlQuery(_cnn, _connectionString, queryString);
            return query.ExecuteQuery<T>();
        }

        public override List<T> ExecuteQueryWithOutRelationship<T>(string queryString)
        {
            SqlQuery query = new SqlQuery(_cnn, _connectionString, queryString);
            return query.ExecuteQueryWithOutRelationship<T>();
        }

        public override int ExecuteNonQuery(string queryString)
        {
            SqlQuery query = new SqlQuery(_cnn, _connectionString, queryString);
            return query.ExecuteNonQuery();
        }
    }
}