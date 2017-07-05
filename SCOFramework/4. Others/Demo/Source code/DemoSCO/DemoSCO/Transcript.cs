using SCOFramework;

namespace DemoSCO
{
    [Table("TRANSCRIPT")]
    public class Transcript
    {
        [PrimaryKey("ID", false)]
        [Column("ID", DataType.VARCHAR)]
        public string StudentID { get; set; }

        [Column("GPA", DataType.FLOAT)]
        public double GPA { get; set; }
    }
}
