using System;

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
