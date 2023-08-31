using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Exceptions
{
    internal class NegativeValueException : Exception
    {
        public NegativeValueException(string message) : base(message) { }

        public NegativeValueException(decimal value) : base($"NegativeValueException decimal: {value}") { }

        public NegativeValueException(int value) : base($"NegativeValueException int: {value}") { }
    }
}
