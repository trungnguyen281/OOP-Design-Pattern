using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOFramework
{
    public class ManyToOneAttribute : Attribute
    {
        public string RelationshipID { get; private set; }
        public string TableName { get; private set; }

        public ManyToOneAttribute(string relationshipID, string tableName)
        {
            RelationshipID = relationshipID;
            TableName = tableName;
        }
    }
}
