using System;

namespace SCOFramework
{
    public class ColumnAttribute : Attribute
    {
        public string Name { get; private set; }
        public DataType Type { get; private set; }

        public ColumnAttribute(string name, DataType type)
        {
            Name = name;
            Type = type;
        }
    }
}