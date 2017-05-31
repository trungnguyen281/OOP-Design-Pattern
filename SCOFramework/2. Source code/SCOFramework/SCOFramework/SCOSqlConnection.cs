using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SCOFramework
{
    public class SCOSqlConnection : SCOConnection
    {
        private SqlConnection cnn;

        public SCOSqlConnection(string connectionString)
        {
            cnn = new SqlConnection(connectionString);
        }

        public override void Open()
        {
            cnn.Open();
        }

        public override void Close()
        {
            cnn.Close();
        }

        public override SCOCommand CreateCommand()
        {
            return new SCOSlqCommand(cnn);
        }

        public override SCOCommand CreateCommand(string query)
        {
            return new SCOSlqCommand(cnn, query);
        }
    }
}