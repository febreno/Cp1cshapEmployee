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
            Company company = new Company();
            
            void ShowMenu()
            {
                int opcao = 0;

                while (opcao != 10)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1 - Cadastro autoático");
                    Console.WriteLine("2 - Exibir funcionários");
                    Console.WriteLine("3 - Exibir funcionários CLT");
                    Console.WriteLine("4 - Exibir funcionários PJ");
                    Console.WriteLine("5 - Exibir soma do custo mensal de todos os funcionários (Funcionário PJ sem horas extras)");
                    Console.WriteLine("6 - Aumentar salário de funcionário CLT em % do salário atual");
                    Console.WriteLine("7 - Aumentar salário de funcionário PJ em R$ do valor hora");
                    Console.WriteLine("8 - Pesquisar funcionário por registro");
                    Console.WriteLine("9 - Exibir custo mensal de funcionário");
                    Console.WriteLine("10 - Sair \n");

                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            company.AutomaticRegisterEmployee();
                            break;
                        case 2:
                            company.ShowAllEmployees();
                            break;
                        case 3:
                            company.ShowAllCltEmployees();
                            break;
                        case 4:
                            company.ShowAllPjEmployees();
                            break;
                        case 5:
                            company.ShowMonthlyCostofEmployees();
                            break;
                        case 6:
                            company.IncreaseCostCltEmployee();//7
                            break;
                        case 7:
                            company.IncreaseCostPjEmployee();//8
                            break;
                        case 8:
                            company.SerachPjEmployeeByRegisterNumber();//9
                            break;
                        case 9:
                            company.IncreaseCostPjEmployee();
                            break;
                    }
                }
            }
            //do a AutomaticRegister when start
            //company.AutomaticRegisterEmployee();
            ShowMenu();
        }
    }
    
    
}

//ADD
// Interface
// Exceptions
