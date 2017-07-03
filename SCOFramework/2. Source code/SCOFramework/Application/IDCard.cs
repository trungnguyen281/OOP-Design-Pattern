using SCOFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    [Table("IDCard")]
    public class IDCard
    {
        [PrimaryKey("StudentID", false)]
        [Column("StudentID", DataType.VARCHAR)]
        public string StudentID { get; set; }

        [Column("IDNumber", DataType.VARCHAR)]
        public string IDNumber { get; set; }

        [Column("Address", DataType.NVARCHAR)]
        public string Address { get; set; }
    }
}
