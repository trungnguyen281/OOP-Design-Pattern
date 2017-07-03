using SCOFramework;
using System.Collections.Generic;

namespace Application
{
    [Table("Student")]
    public class Student
    {
        [PrimaryKey("ID", false)]
        [Column("ID", DataType.VARCHAR)]
        [ForeignKey("2", "ID", "StudentID")]
        public string ID { get; set; }

        [PrimaryKey("Name", false)]
        [Column("Name", DataType.NVARCHAR)]
        public string Name { get; set; }

        [OneToMany("1", "Phone")]
        public List<PhoneNumber> Phone { get; set; }

        [OneToOne("2", "IDCard")]
        public IDCard abc { get; set; }
    }
}
