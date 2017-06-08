using System.Data.SqlClient;

namespace SCOFramework
{
    public class UpdateSqlCommand : SCOSqlCommand, UpdateCommand
    {
        private UpdateSqlCommand(SqlConnection cnn) : base(cnn)
        {
        }

        public static ICanAddUpdate Create(SqlConnection cnn)
        {
            return new UpdateSqlCommand(cnn);
        }

        public ICanAddSet Update(string tableName)
        {
            _query += "UPDATE " + tableName;
            return this;
        }

        public ICanAddSetOrWhere Set(string statement)
        {
            if (!_query.Contains("SET"))
                _query += " SET " + statement;
            else
                _query += ", " + statement;

            return this;
        }

        public ICanAddExecuteNonQuery Where(string condition)
        {
            _query += " WHERE " + condition;
            return this;
        }

        public void Execute()
        {
            base.ExecuteNonQuery();
        }
    }
}
