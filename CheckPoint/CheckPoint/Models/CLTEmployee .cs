using CheckPoint.Enums;
using System.Xml.Linq;

namespace CheckPoint.Models
{
    public class CLTEmployee : Employee
    {
        private decimal Salary { get; set; }
        private bool TrustPosition { get; set; }

        public CLTEmployee(int registryNumber, string name, Gender gender, EmployeeType employeeType, decimal salary, bool trustPosition)
            : base(registryNumber, name, gender, employeeType)
        {
            this.RegistryNumber = registryNumber;
            this.Name = name;
            this.Gender = gender;
            this.EmployeeType = employeeType;
            this.Salary = salary;
            this.TrustPosition = trustPosition;
        }
        public override decimal CalcPerMonth()
        {
            decimal cost = Salary
                + Salary * 0.1111m  // Fração de férias
                + Salary * 0.0833m  // Fração de 13º salário
                + Salary * 0.08m    // FGTS
                + Salary * 0.04m    // FGTS/Provisão de multa para rescisão
                + Salary * 0.0793m; // Previdenciário

            if (TrustPosition)//cargo de confiança = true
                cost += 1000m;

            return cost;
        }

        public override decimal AddPercent(decimal increasePercent)
        {
            Salary = CalcPerMonth() + (CalcPerMonth() * (increasePercent / 100m));//percent
            return Salary;
        }
    }
}
