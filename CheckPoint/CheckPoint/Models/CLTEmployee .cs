using CheckPoint.Enums;
using CheckPoint.Exceptions;
using CheckPoint.Interfaces;
using System.Xml.Linq;

namespace CheckPoint.Models
{
    public class CltEmployee : Employee, IEmployee
    {
        internal decimal Salary { get; set; }
        internal bool TrustPosition { get; set; }

        public CltEmployee(int registryNumber, string name, Gender gender, EmployeeType employeeType, decimal salary, bool trustPosition)
            : base(registryNumber, name, gender, employeeType)
        {
            if (salary < 0)
                throw new NegativeValueException(salary);

            this.RegistryNumber = registryNumber;
            this.Name = name;
            this.Gender = gender;
            this.EmployeeType = employeeType;
            this.Salary = salary;
            this.TrustPosition = trustPosition;
        }
        public override decimal CalcPerMonth()
        {
            if (Salary < 0)
                throw new NegativeValueException(Salary);
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
