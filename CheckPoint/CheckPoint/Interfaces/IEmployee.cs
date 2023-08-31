using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Interfaces
{
    internal interface IEmployee
    {
        public abstract decimal CalcPerMonth();
        public abstract decimal AddPercent(decimal increasePercent);
    }
}
