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
            conn.Open();
            //-----------
            var cmd = conn.CreateTextCommand("SELECT * FROM Student");
            List<Student> students = cmd.ExecuteReader<Student>();

            var cmd2 = conn.CreateSelectCommand();
            List<Student> students2 = cmd2.Select("*").From("Student").AllRows().Execute<Student>();

            var cmd3 = conn.CreateUpdateCommand();
            cmd3.Update("Student").Set("Name = N'Trung Nguyen'").Set("Grade = 'CTT3'").Where("ID = '1312635'").Execute();

            //-----------
            conn.Close();
        }
    }
}
