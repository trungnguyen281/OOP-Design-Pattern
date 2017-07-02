using SCOFramework;
using System.Collections.Generic;

namespace Application
{
    [Table("Student")]
    public class Student
    {
        [PrimaryKey("ID", false)]
        [Column("ID", DataType.VARCHAR)]
        public string ID { get; set; }

        [Column("Name", DataType.NVARCHAR)]
        public string Name { get; set; }

        [OneToMany("1", "Phone")]
        public List<PhoneNumber> Phone { get; set; }
    }
}
