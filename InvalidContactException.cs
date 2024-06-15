using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home9_csharp
{
    public class InvalidContactException : Exception
    {
        public InvalidContactException(string msg) : base(msg)
        { }
    }
}
