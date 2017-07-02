using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOFramework
{
    public class ForeignKeyAttribute : Attribute
    {
        public string RelationshipID { get; private set; }
        public string Name { get; private set; }
        public string References { get; private set; }

        public ForeignKeyAttribute (string relationshipID, string name, string references)
        {
            RelationshipID = relationshipID;
            Name = name;
            References = references;
        }
    }
}
