using SCOFramework;

namespace DemoSCO
{
    [Table("STUDENT_SUBJECT")]
    public class Student_Subject
    {
        [PrimaryKey("STUDENTID", false)]
        [ForeignKey("3", "STUDENTID", "ID")]
        [Column("STUDENTID", DataType.VARCHAR)]
        public string StudentID { get; set; }

        [PrimaryKey("SUBJECTID", true)]
        [Column("SUBJECTID", DataType.INT)]
        public int SubjectID { get; set; }
    }
}
