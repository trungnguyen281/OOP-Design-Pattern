using SqlClient = System.Data.SqlClient;

namespace SCOFramework
{
    public class SCOSqlConnection : SCOConnection
    {
        private SqlClient.SqlConnection _cnn;

        public SCOSqlConnection(string connectionString)
        {
            _cnn = new SqlClient.SqlConnection(connectionString);
        }

        public override void Open()
        {
            _cnn.Open();
        }

        public override void Close()
        {
            _cnn.Close();
        }


        public override ICanAddSelect CreateSelectCommand()
        {
            return SelectSqlCommand.Create(_cnn);
        }

        public override ICanAddUpdate CreateUpdateCommand()
        {
            return UpdateSqlCommand.Create(_cnn);
        }

        public override SCOCommand CreateTextCommand(string query)
        {
            return new SqlTextCommand(_cnn, query);
        }
    }
}