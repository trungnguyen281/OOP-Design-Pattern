using SCOFramework;
using System.Collections.Generic;

namespace DemoSCO
{
    [Table("STUDENT")]
    public class Student
    {
        [PrimaryKey("ID", false)]
        [Column("ID", DataType.VARCHAR)]
        public string ID { get; set; }

        [Column("NAME", DataType.NVARCHAR)]
        public string Name { get; set; }

        [Column("GENDER", DataType.NVARCHAR)]
        public string Gender { get; set; }

        [Column("TEACHERID", DataType.VARCHAR)]
        [ForeignKey("1", "TEACHERID", "ID")]
        public string TeacherID { get; set; }

        [ManyToOne("1", "TEACHER")]
        public Teacher Teacher { get; set; }

        [OneToOne("2", "TRANSCRIPT")]
        [ForeignKey("2", "ID", "ID")]
        public Transcript Transcipt { get; set; }

        [OneToMany("3", "STUDENT_SUBJECT")]
        public List<Student_Subject> Student_Subjects { get; set; }
    }
}

