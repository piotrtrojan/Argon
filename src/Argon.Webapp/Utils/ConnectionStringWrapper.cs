using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Argon.Webapp.Utils
{
    public class ConnectionStringWrapper
    {
        public string Value { get; set; }

        public ConnectionStringWrapper(string value)
        {
            Value = value;
        }
    }
}
