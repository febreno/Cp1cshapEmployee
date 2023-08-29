using CheckPoint.Enums;

namespace CheckPoint.Models
{
    public abstract class Employee
    {
        protected int RegistryNumber { get; set; }
        protected string Name { get; set; }
        protected Gender Gender { get; set; }
        protected EmployeeType EmployeeType { get; set; }
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
