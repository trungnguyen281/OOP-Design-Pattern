using SCOFramework;
using System.Collections.Generic;

namespace DemoSCO
{
    [Table("TEACHER")]
    public class Teacher
    {
        [PrimaryKey("ID", false)]
        [Column("ID", DataType.VARCHAR)]
        public string ID { get; set; }

        [Column("NAME", DataType.NVARCHAR)]
        public string Name { get; set; }

        [OneToMany("1", "STUDENT")]
        public List<Student> StudentList { get; set; }
    }
}

