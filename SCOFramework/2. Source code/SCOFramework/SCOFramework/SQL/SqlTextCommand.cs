using System.Data.SqlClient;
namespace SCOFramework
{
    public class SqlTextCommand : SCOSqlCommand
    {
        public SqlTextCommand(SqlConnection cnn, string query) : base(cnn)
        {
            _query = query;
        }
    }
}
