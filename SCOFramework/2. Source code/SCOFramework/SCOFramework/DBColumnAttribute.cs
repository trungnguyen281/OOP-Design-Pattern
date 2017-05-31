using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCOFramework
{
    public class DBColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public DBColumnAttribute(string name)
        {
            Name = name;
        }
    }
}