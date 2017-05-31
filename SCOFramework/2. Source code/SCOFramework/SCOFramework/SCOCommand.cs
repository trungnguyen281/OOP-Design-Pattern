using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCOFramework
{
    public interface SCOCommand
    {
        List<T> Execute<T>() where T : new();
    }
}