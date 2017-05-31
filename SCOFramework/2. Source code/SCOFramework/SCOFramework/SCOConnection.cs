using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCOFramework
{
    public abstract class SCOConnection
    {
        public string ConnectionString { get; set; }

        public abstract void Close();

        public abstract void Open();

        public abstract SCOCommand CreateCommand();

        public abstract SCOCommand CreateCommand(string query);
    }
}