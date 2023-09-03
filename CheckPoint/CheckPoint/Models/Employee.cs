using CheckPoint.Enums;
using CheckPoint.Interfaces;

namespace CheckPoint.Models
{
    public abstract class Employee : IEmployee
    {
        protected internal int RegistryNumber { get; set; }
        protected internal string Name { get; set; }
        protected internal Gender Gender { get; set; }
        protected internal EmployeeType EmployeeType { get; set; }
        protected internal Employee(int registryNumber, string name, Gender gender, EmployeeType employeeType)
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
