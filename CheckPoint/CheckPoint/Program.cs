using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CheckPoint.Enums;
using CheckPoint.Models;

namespace EmpresaFuncionarios
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> ListEmployee()
            {
                List<Employee> employees = new List<Employee>();
                return employees;
            }
            void AutomaticRegisterEmployee()//1
            {
                var cltEmployee = new CLTEmployee()
                {
                    RegistryNumber = 1,
                    Name = "Thiago",
                    Gender = Gender.Male,
                    EmployeeType = EmployeeType.Clt,
                    Salary = 1300,
                    TrustPosition = true
                };
                ListEmployee().Add(cltEmployee);

                var pjEmployee = new PJEmployee
                {
                    RegistryNumber = 2,
                    Name = "Isabela rocha",
                    Gender = Gender.Female,
                    EmployeeType = EmployeeType.Pj,
                    HourValue = 50,
                    ContractedHours = 160,
                    ExtraHours = 10,
                    CNPJCompany = "12.345.678/0001-00",
                };
                ListEmployee().Add(pjEmployee);
            }
            void ShowAllEmployees()//3
            {

                foreach (var e in ListEmployee())
                {
                    Console.WriteLine($"Register - {e.RegistryNumber}");
                    Console.WriteLine($"Name - {e.Name}");
                    Console.WriteLine($"Gender - {e.Gender}");
                    Console.WriteLine($"ExtraHours - {e.CalcPerMonth()} \n");
                    Console.WriteLine($"ExtraHours - {e.CalcPerMonth()} \n");
                }
            }
            void ShowAllCltEmployees()//4
            {
                foreach (var e in ListEmployee().Where(x => x.EmployeeType == EmployeeType.Clt))
                {
                    Console.WriteLine($"Register - {e.RegistryNumber}");
                    Console.WriteLine($"Name - {e.Name}");
                    Console.WriteLine($"Gender - {e.Gender}");
                    Console.WriteLine($"Gender - {e.EmployeeType}");
                    Console.WriteLine($"ExtraHours - {e.CalcPerMonth()} \n");
                    Console.WriteLine($"ExtraHours - {e.CalcPerMonth()} \n");
                }
            }
            void ShowAllPjEmployees()//5
            {
                foreach (var e in ListEmployee().Where(x => x.EmployeeType == EmployeeType.Pj))
                {
                    Console.WriteLine($"Register - {e.RegistryNumber}");
                    Console.WriteLine($"Name - {e.Name}");
                    Console.WriteLine($"Gender - {e.Gender}");
                    Console.WriteLine($"Gender - {e.EmployeeType}");
                    Console.WriteLine($"ExtraHours - {e.CalcPerMonth()} \n");
                    Console.WriteLine($"ExtraHours - {e.CalcPerMonth()} \n");
                }

            }
            void ShowMonthlyCostofEmployees()//6
            {
                decimal result = 0m;
                foreach (var e in ListEmployee())
                {
                    result += e.CalcPerMonth();
                }
                Console.WriteLine($"ShowMonthlyCostofEmployees: {result}");

            }
            void IncreaseCostCltEmployee()//7
            {
                Console.WriteLine("Registry account:");
                var RegistryNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Percent in % to increase:");
                var percent = decimal.Parse(Console.ReadLine()); // Use decimal instead of int for percentages

                foreach (var e in ListEmployee())
                {
                    if (e.RegistryNumber == RegistryNumber && e.EmployeeType == EmployeeType.Clt)
                    {
                        if (e is CLTEmployee clt)
                        {
                            Console.WriteLine($"Register: {clt.RegistryNumber}");
                            Console.WriteLine($"Name: {clt.Name}");
                            Console.WriteLine($"Gender: {clt.Gender}");
                            Console.WriteLine($"Employee Type: {clt.EmployeeType}");
                            Console.WriteLine($"Current Salary: {clt.CalcPerMonth}");

                            //increase percent
                            decimal finalSalary = clt.AddPercent(percent);
                            //decimal finalSalary = e.AddPercent(percent);

                            Console.WriteLine($"Final Salary: {finalSalary}");
                        }
                    }
                }


            }
            void IncreaseCostPjEmployee()//8
            {
                Console.WriteLine("Registry account:");
                var RegistryNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Percent in % to increase:");
                var percent = decimal.Parse(Console.ReadLine()); // Use decimal instead of int for percentages

                foreach (var e in ListEmployee())
                {

                    if (e.RegistryNumber == RegistryNumber && e.EmployeeType == EmployeeType.Pj)
                    {
                        if (e is PJEmployee pj)
                        {
                            Console.WriteLine($"{pj.HourValue} += {pj.HourValue} * {percent} / 100\n");
                            Console.WriteLine($"Register: {e.RegistryNumber}");
                            Console.WriteLine($"Name: {pj.Name}");
                            Console.WriteLine($"Name: {pj.HourValue}");
                            Console.WriteLine($"Gender: {pj.Gender}");
                            Console.WriteLine($"Employee Type: {pj.EmployeeType}");
                            Console.WriteLine($"Current Salary: {pj.CalcPerMonth}");

                            //increase percent
                            decimal finalSalary = pj.AddPercent(percent);

                            Console.WriteLine($"Hour Value: {finalSalary}");
                        }

                    }
                }


            }
            void SerachPjEmployeeByRegisterNumber()//9
            {
                Console.WriteLine("Registry account:");
                var RegistryNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Percent in % to increase:");
                var percent = decimal.Parse(Console.ReadLine()); // Use decimal instead of int for percentages

                foreach (var e in ListEmployee())
                {

                    if (e.RegistryNumber == RegistryNumber && e.EmployeeType == EmployeeType.Pj)
                    {
                        if (e is PJEmployee pj)
                        {
                            Console.WriteLine($"{pj.HourValue} += {pj.HourValue} * {percent} / 100\n");
                            Console.WriteLine($"Register: {pj.RegistryNumber}");
                            Console.WriteLine($"Name: {pj.Name}");
                            Console.WriteLine($"Name: {pj.HourValue}");
                            Console.WriteLine($"Gender: {pj.Gender}");
                            Console.WriteLine($"Employee Type: {pj.EmployeeType}");
                            Console.WriteLine($"Current Salary: {pj.CalcPerMonth}");

                            //increase percent
                            decimal finalSalary = pj.AddPercent(percent);

                            Console.WriteLine($"Hour Value: {finalSalary}");
                        }

                    }
                }


            }
            void ShowMenu()
            {
                int opcao = 0;

                while (opcao != 11)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1 - Cadastro autoático");
                    Console.WriteLine("2 - Cadastro manual");
                    Console.WriteLine("3 - Exibir funcionários");
                    Console.WriteLine("4 - Exibir funcionários CLT");
                    Console.WriteLine("5 - Exibir funcionários PJ");
                    Console.WriteLine("6 - Exibir soma do custo mensal de todos os funcionários (Funcionário PJ sem horas extras)");
                    Console.WriteLine("7 - Aumentar salário de funcionário CLT em % do salário atual");
                    Console.WriteLine("8 - Aumentar salário de funcionário PJ em R$ do valor hora");
                    Console.WriteLine("9 - Pesquisar funcionário por registro");
                    Console.WriteLine("10 - Exibir custo mensal de funcionário");
                    Console.WriteLine("11 - Sair");

                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            AutomaticRegisterEmployee();
                            break;
                        case 3:
                            ShowAllEmployees();
                            break;
                        case 4:
                            ShowAllCltEmployees();
                            break;
                        case 5:
                            ShowAllPjEmployees();
                            break;
                        case 6:
                            ShowMonthlyCostofEmployees();
                            break;
                        case 7:
                            IncreaseCostCltEmployee();
                            break;
                        case 8:
                            IncreaseCostPjEmployee();
                            break;
                        case 9:
                            IncreaseCostPjEmployee();
                            break;
                        case 10:
                            IncreaseCostPjEmployee();
                            break;
                    }
                }
            }

            ShowMenu();
        }
    }
    
    
}

//ADD
// Interface
// Exceptions
