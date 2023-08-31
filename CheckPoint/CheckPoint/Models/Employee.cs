using CheckPoint.Enums;
using CheckPoint.Interfaces;

namespace CheckPoint.Models
{
    public abstract class Employee : IEmployee
    {
        internal int RegistryNumber { get; set; }
        internal string Name { get; set; }
        internal Gender Gender { get; set; }
        internal EmployeeType EmployeeType { get; set; }
        protected Employee(int registryNumber, string name, Gender gender, EmployeeType employeeType)
        {
            this.RegistryNumber = registryNumber;
            this.Name = name;
            this.Gender = gender;
            this.EmployeeType = employeeType;
        }
        public abstract decimal CalcPerMonth();
        public abstract decimal AddPercent(decimal increasePercent);
    }
}
