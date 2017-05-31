using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SCOFramework
{
    public class SCOSlqCommand : SCOCommand
    {
        SqlCommand cmd;
        public string Query { get; set; }

        public SCOSlqCommand(SqlConnection cnn)
        {
            cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.Text;
        }

        public SCOSlqCommand(SqlConnection cnn, string query)
        {
            cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.Text;

            Query = query;
        }

        public List<T> Execute<T>() where T : new()
        {
            cmd.CommandText = Query;

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            List<T> res = new List<T>();
            foreach(DataRow dr in dt.Rows)
                res.Add(Mapper.MapToObject<T>(dr));

            return res;
        }
    }
}