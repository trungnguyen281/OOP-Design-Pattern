using System;

namespace SCOFramework
{
    public class TableAttribute : Attribute
    {
        public string Name { get; private set; }

        public TableAttribute(string Name)
        {
            this.Name = Name;
        }
    }
}
