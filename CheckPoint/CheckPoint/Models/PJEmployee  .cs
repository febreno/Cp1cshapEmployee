using CheckPoint.Enums;
using CheckPoint.Exceptions;
using CheckPoint.Interfaces;

namespace CheckPoint.Models
{
    public class PjEmployee : Employee
    {
        protected internal decimal HourValue { get; set; }
        protected internal int ContractedHours { get; set; }
        protected internal int ExtraHours { get; set; }
        protected internal string CnpjCompany { get; set; } = "00.000.000/0000-00";

        protected internal PjEmployee(int registryNumber, string name, Gender gender, EmployeeType employeeType, decimal hourValue, int contractedHours, int extraHours, string cnpjCompany)
            : base(registryNumber, name, gender, employeeType) // construtor by class base
        {

            if (hourValue < 0 || contractedHours < 0 || extraHours < 0)
            {
                throw new NegativeValueException($"NegativeValueException: {HourValue} || {ContractedHours} || {ExtraHours}");
            }
            this.RegistryNumber = registryNumber;
            this.Name = name;
            this.Gender = gender;
            this.EmployeeType = employeeType;
            this.HourValue = hourValue;
            this.ContractedHours = contractedHours;
            this.ExtraHours = extraHours;
            this.CnpjCompany = cnpjCompany;
        }

        public override decimal CalcPerMonth()
        {
            if (HourValue < 0 || ContractedHours < 0 || ExtraHours < 0)
            {
                throw new NegativeValueException($"NegativeValueException: {HourValue} || {ContractedHours} || {ExtraHours}");
            }
            //return (HourValue * ExtraHours) + (HourValue * ExtraHours);
            return HourValue * (ContractedHours + ExtraHours);
        }

        public override decimal AddPercent(decimal increasePercent)
        {
            HourValue += HourValue * (increasePercent / 100);
            return HourValue;
        }
    }
}
