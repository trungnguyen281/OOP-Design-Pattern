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
            List<Student> students = conn.Select<Student>().AllRow().Run();
            PhoneNumber p = students[3].Phone[0];
            p = conn.Select<PhoneNumber>().Where("ID = " + p.ID).Run()[0];
           
            //conn.Delete(student);
            Student s = new Student();
            s.ID = "1312635";
            s.Name = "Nguyễn Đức Trung";

            //conn.Insert(s);
            List<PhoneNumber> phones = conn.Select<PhoneNumber>().AllRow().Run();
            
            //-----------
            conn.Close();
        }
    }
}
