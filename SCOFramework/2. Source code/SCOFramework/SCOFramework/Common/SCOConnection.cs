﻿using System.Collections.Generic;

namespace SCOFramework
{
    public abstract class SCOConnection
    {
        protected string _connectionString { get; set; }

        public abstract void Open();
        public abstract void Close();
        public abstract ICanAddWhere<T> Select<T>() where T : new();
        public abstract int Insert<T>(T obj) where T : new();
        public abstract int Update<T>(T obj) where T : new();
        public abstract int Delete<T>(T obj) where T : new();
        public abstract List<T> ExecuteQuery<T>(string query) where T : new();
        public abstract List<T> ExecuteQueryWithOutRelationship<T>(string query) where T : new();
        public abstract int ExecuteNonQuery(string query);
    }
}