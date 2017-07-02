using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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