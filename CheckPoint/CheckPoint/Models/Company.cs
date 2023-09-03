using CheckPoint.Enums;
using CheckPoint.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models
{
    internal class Company
    {
        private List<Employee> Employees { get; set; }
        private int NextRegistryNumber { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
            NextRegistryNumber = 1;// start in 0
        }
        public int GenerateRegistryNumber()
        {
            int nextNumber = NextRegistryNumber;
            NextRegistryNumber++;
            return nextNumber;
        }
        public void AutomaticRegisterEmployee()//1
        {
            PjEmployee pj1 = new PjEmployee(GenerateRegistryNumber(), "Lucas Albert", Gender.Male, EmployeeType.Pj, 60m, 5, 1, "222");
            PjEmployee pj2 = new PjEmployee(GenerateRegistryNumber(), "José Marreta", Gender.Male, EmployeeType.Pj, 50m, 7, 0, "222");
            CltEmployee clt1 = new CltEmployee(GenerateRegistryNumber(), "Ana Nicolet", Gender.Female, EmployeeType.Clt, 10m, true);
            CltEmployee clt2 = new CltEmployee(GenerateRegistryNumber(), "Clebber Aniston", Gender.Male, EmployeeType.Clt, 1800m, true);

            Employees.Add(pj1);
            Employees.Add(pj2);
            Employees.Add(clt1);
            Employees.Add(clt2);

            Console.WriteLine("OK");
            
        }
        public void ShowAllEmployees()//2
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("Employees list is empty");
            }
            foreach (var e in Employees)
            {
                if (e is PjEmployee pj)
                {
                    Console.WriteLine($"Register: {e.RegistryNumber}");
                    Console.WriteLine($"Name: {e.Name}");
                    Console.WriteLine($"Gender: {e.Gender}");
                    Console.WriteLine($"EmployeeType: {e.EmployeeType}");

                    Console.WriteLine($"HourValue: {pj.HourValue}");
                    Console.WriteLine($"ContractedHours: {pj.ContractedHours}");
                    Console.WriteLine($"ExtraHours: {pj.ExtraHours}");
                    Console.WriteLine($"CnpjCompany: {pj.CnpjCompany}\n");
                }
                else if (e is CltEmployee clt)
                {
                    Console.WriteLine($"Register: {e.RegistryNumber}");
                    Console.WriteLine($"Name: {e.Name}");
                    Console.WriteLine($"Gender: {e.Gender}");
                    Console.WriteLine($"EmployeeType: {e.EmployeeType}");

                    Console.WriteLine($"Salary: {clt.Salary}");
                    Console.WriteLine($"TrustPosition: {clt.TrustPosition}\n");
                }

            }
        }
        public void ShowAllCltEmployees()//3
        {
            EmployeeType typeAccount = EmployeeType.Pj;

            foreach (var e in Employees.Where(x => x.EmployeeType == EmployeeType.Clt))
            {
                if (e is CltEmployee clt)
                {
                    Console.WriteLine($"Register: {e.RegistryNumber}");
                    Console.WriteLine($"Name: {e.Name}");
                    Console.WriteLine($"Gender: {e.Gender}");
                    Console.WriteLine($"EmployeeType: {e.EmployeeType}");

                    Console.WriteLine($"Salary: {clt.Salary}");
                    Console.WriteLine($"TrustPosition: {clt.TrustPosition}\n");
                }

                typeAccount = e.EmployeeType;
            }
            if (Employees.Count == 0 || typeAccount != EmployeeType.Clt)
            {
                Console.WriteLine("Employees list is empty or different account type\n");
                return;
            }
        }
        public void ShowAllPjEmployees()//4
        {
            EmployeeType typeAccount = EmployeeType.Clt;
            foreach (var e in Employees)
            {
                if (e is PjEmployee pj)
                {
                    Console.WriteLine($"Register: {e.RegistryNumber}");
                    Console.WriteLine($"Name: {e.Name}");
                    Console.WriteLine($"Gender: {e.Gender}");
                    Console.WriteLine($"EmployeeType: {e.EmployeeType}");

                    Console.WriteLine($"HourValue: {pj.HourValue}");
                    Console.WriteLine($"ContractedHours: {pj.ContractedHours}");
                    Console.WriteLine($"ExtraHours: {pj.ExtraHours}");
                    Console.WriteLine($"CnpjCompany: {pj.CnpjCompany}\n");
                }
                typeAccount = e.EmployeeType;
            }
            if (Employees.Count == 0 || typeAccount != EmployeeType.Pj)
            {
                Console.WriteLine("Employees list is empty or different account type\n");
                return;
            }

        }
        public void ShowMonthlyCostofEmployees()//5
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("Employees list is empty");
            }
            decimal result = 0m;
            foreach (var e in Employees)
            {
                result += e.CalcPerMonth();
            }
            Console.WriteLine($"ShowMonthlyCostofEmployees: {result}\n");

        }
        public void IncreaseCostCltEmployee()//6
        {
            EmployeeType typeAccount = EmployeeType.Clt;
            Console.WriteLine("Registry account:");
            var registryNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Percent in % to increase:");
            var percent = decimal.Parse(Console.ReadLine()); // Use decimal instead of int for percentages


            foreach (var e in Employees)
            {
                if (e.RegistryNumber == registryNumber && e is CltEmployee clt)
                {
                    Console.WriteLine($"Register: {e.RegistryNumber}");
                    Console.WriteLine($"Name: {e.Name}");
                    Console.WriteLine($"Gender: {e.Gender}");
                    Console.WriteLine($"EmployeeType: {e.EmployeeType}");

                    Console.WriteLine($"ExtraHours: {clt.Salary}");
                    Console.WriteLine($"TrustPosition: {clt.TrustPosition}\n");

                    //increase percent
                    decimal finalSalary = e.AddPercent(percent);
                    //decimal finalSalary = e.AddPercent(percent);

                    Console.WriteLine($"Final Salary: {finalSalary}");
                    typeAccount = e.EmployeeType;
                }
            }
            if (Employees.Count == 0 || typeAccount != EmployeeType.Clt)
            {
                Console.WriteLine("Employees list is empty or different account type\n");
                return;
            }


        }
        public void IncreaseCostPjEmployee()//7
        {
            Console.WriteLine("Registry account:");
            var RegistryNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Percent in % to increase:");
            var percent = decimal.Parse(Console.ReadLine()); // Use decimal instead of int for percentages

            var typeAccount = EmployeeType.Clt;

            foreach (var e in Employees)
            {

                if (e.RegistryNumber == RegistryNumber && e.EmployeeType == EmployeeType.Pj)
                {
                    if (e is PjEmployee pj)
                    {
                        Console.WriteLine($"{pj.HourValue} += {pj.HourValue} * {percent} / 100\n");
                        Console.WriteLine($"Register: {e.RegistryNumber}");
                        Console.WriteLine($"Name: {pj.Name}");
                        Console.WriteLine($"HourValue: {pj.HourValue}");
                        Console.WriteLine($"Gender: {pj.Gender}");
                        Console.WriteLine($"EmployeeType: {pj.EmployeeType}");
                        Console.WriteLine($"CalcPerMonth: {pj.CalcPerMonth()}\n");

                        //increase percent
                        decimal finalSalary = pj.AddPercent(percent);
                        typeAccount = pj.EmployeeType;
                        Console.WriteLine($"Hour Value: {finalSalary}");
                        
                    }

                }
                if (Employees.Count == 0 || typeAccount != EmployeeType.Pj)
                {
                    Console.WriteLine("Employees list is empty or different account type\n");
                    return;
                }
            }


        }
        public void SerachPjEmployeeByRegisterNumber()//8
        {
            Console.WriteLine("Registry account:");
            var RegistryNumber = int.Parse(Console.ReadLine());

            if (Employees.Count == 0)
            {
                Console.WriteLine("Employees list is empty");
            }

            foreach (var e in Employees)
            {

                if (e.RegistryNumber == RegistryNumber && e.EmployeeType == EmployeeType.Pj)
                {
                    if (e is PjEmployee pj)
                    {
                        Console.WriteLine($"Register: {pj.RegistryNumber}");
                        Console.WriteLine($"Name: {pj.Name}");
                        Console.WriteLine($"Name: {pj.HourValue}");
                        Console.WriteLine($"Gender: {pj.Gender}");
                        Console.WriteLine($"Employee Type: {pj.EmployeeType}");
                        Console.WriteLine($"Current Salary: {pj.CalcPerMonth()}\n");
                    }

                }
            }
        }
    }
}
