using SCOFramework;

namespace DemoSCO
{
    public class Subject
    {
        [PrimaryKey("ID", true)]
        [Column("ID", DataType.INT)]
        public string ID { get; set; }

        [Column("Name", DataType.NVARCHAR)]
        public string Name { get; set; }
    }
}
