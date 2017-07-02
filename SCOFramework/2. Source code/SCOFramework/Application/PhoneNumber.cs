using SCOFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    [Table("PhoneNumber")]
    public class PhoneNumber
    {
        [PrimaryKey("ID", true)]
        [Column("ID", DataType.INT)]
        public int ID { get; set; }

        [Column("Phone", DataType.VARCHAR)]
        public string Phone { get; set; }

        [Column("StudentID", DataType.VARCHAR)]
        [ForeignKey("1", "StudentID", "ID")]
        public string StudentID { get; set; }

        [ManyToOne("1", "Student")]
        public Student Student { get; set; }
    }
}
