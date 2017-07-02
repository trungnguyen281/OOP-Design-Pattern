using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCOFramework
{
    public class PrimaryKeyAttribute : Attribute
    {
        public string Name { get; private set; }
        public bool AutoID { get; private set; }
        
        public PrimaryKeyAttribute(string name, bool autoID)
        {
            Name = name;
            AutoID = autoID;
        }
    }
}