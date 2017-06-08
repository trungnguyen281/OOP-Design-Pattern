using System.Collections.Generic;
using System.Data;
using SqlClient = System.Data.SqlClient;

namespace SCOFramework
{
    public class SCOSqlCommand : SCOCommand
    {
        protected SqlClient.SqlCommand _cmd;
        protected string _query;

        protected SCOSqlCommand(SqlClient.SqlConnection cnn)
        {
            _cmd = new SqlClient.SqlCommand();
            _cmd.Connection = cnn;
            _cmd.CommandType = System.Data.CommandType.Text;
        }

        public override List<T> ExecuteReader<T>()
        {
            _cmd.CommandText = _query;

            DataTable dt = new DataTable();
            SqlClient.SqlDataAdapter adapter = new SqlClient.SqlDataAdapter(_cmd);
            adapter.Fill(dt);

            List<T> res = new List<T>();
            foreach (DataRow dr in dt.Rows)
                res.Add(Mapper.MapToObject<T>(dr));

            return res;
        }

        public override void ExecuteNonQuery()
        {
            _cmd.CommandText = _query;
            _cmd.ExecuteNonQuery();
        }
    }
}
