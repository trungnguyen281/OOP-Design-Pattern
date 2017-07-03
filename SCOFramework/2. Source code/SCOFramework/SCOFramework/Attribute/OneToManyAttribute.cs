using System;

namespace SCOFramework
{
    public class OneToManyAttribute : Attribute
    {
        public string RelationshipID { get; private set; }
        public string TableName { get; private set; }

        public OneToManyAttribute(string relationshipID, string tableName)
        {
            RelationshipID = relationshipID;
            TableName = tableName;
        }
    }
}
