using System;

namespace SCOFramework
{
    public class OneToOneAttribute : Attribute
    {
        public string RelationshipID { get; private set; }
        public string TableName { get; private set; }

        public OneToOneAttribute(string relationshipID, string tableName)
        {
            RelationshipID = relationshipID;
            TableName = tableName;
        }
    }
}
