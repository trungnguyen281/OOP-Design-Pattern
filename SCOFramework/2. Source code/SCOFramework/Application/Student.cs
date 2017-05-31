using SCOFramework;

namespace Application
{
    public class Student
    {
        [PrimaryKey]
        [DBColumn("ID")]
        public string ID { get; set; }

        [DBColumn("Name")]
        public string Name { get; set; }
    }
}
