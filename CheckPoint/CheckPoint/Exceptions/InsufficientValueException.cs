using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Exceptions
{
    internal class InsufficientValueException : Exception
    {
        public InsufficientValueException(string message) : base(message) {}

        public InsufficientValueException(decimal accountValue) : base($"InsufucicientValueException: {accountValue}") { }
    }
}
