using System.Collections.Generic;
using SCOFramework;
using System.Configuration;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new SCOSqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
            var cmd = conn.CreateCommand("select * from Student");
            conn.Open();
            List<Student> students = cmd.Execute<Student>();
            conn.Close();
        }
    }
}
