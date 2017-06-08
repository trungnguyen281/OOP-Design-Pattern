using System.Collections.Generic;

namespace SCOFramework
{
    public abstract class SCOCommand
    {
        public abstract List<T> ExecuteReader<T>() where T : new();
        public abstract void ExecuteNonQuery();
    }
}