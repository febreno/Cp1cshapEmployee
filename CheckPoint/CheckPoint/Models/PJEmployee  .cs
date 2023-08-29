using CheckPoint.Enums;

namespace CheckPoint.Models
{
    public class PJEmployee : Employee
    {
        private decimal HourValue { get; set; }
        private int ContractedHours { get; set; }
        private int ExtraHours { get; set; }
        private string CnpjCompany { get; set; } = "00.000.000/0000-00";

        public PJEmployee(int registryNumber, string name, Gender gender, EmployeeType employeeType, decimal hourValue, int contractedHours, int extraHours, string cnpjCompany)
            : base(registryNumber, name, gender, employeeType) // construtor by class base
        {
            this.HourValue = hourValue;
            this.ContractedHours = contractedHours;
            this.ExtraHours = extraHours;
            this.CnpjCompany = cnpjCompany;
        }

        public override decimal CalcPerMonth()
        {
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
