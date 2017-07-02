using System.Collections.Generic;

namespace SCOFramework
{
    public abstract class SCOConnection
    {
        protected string _connectionString { get; set; }

        public abstract void Close();

        public abstract void Open();

        public abstract ICanAddWhere<T> Select<T>() where T : new();
        public abstract void Update<T>(T obj) where T : new();
        public abstract void Delete<T>(T obj) where T : new();
        public abstract void Insert<T>(T obj) where T : new();
        public abstract List<T> ExecuteQuery<T>(string v) where T : new();
        public abstract List<T> ExecuteQueryWithOutRelationship<T>(string v) where T : new();
        public abstract void ExecuteNonQuery(string v);
    }
}