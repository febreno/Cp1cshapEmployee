# Cp1cshapEmployee
Console App Application

<details>
<summary>Doc</summary>
<img src="./doc/diagram.png" width="900" title="hover text">

</details>

```CS
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using CheckPoint.Enums;
using CheckPoint.Models;

namespace EmpresaFuncionarios
{
    class Program
    {

        static void Main(string[] args)
        {
            void Test1()
            {
                Console.WriteLine("Test");
                PJEmployee emp = new PJEmployee(1, "Test", Gender.Male, EmployeeType.Pj, 10m, 1,1,"222");
                List<PJEmployee> list = new List<PJEmployee>();
                list.Add(emp);
                foreach (PJEmployee item in list)
                {
                    Console.WriteLine(item.ContractedHours);
                    Console.WriteLine(item.HourValue);
                    Console.WriteLine(item.HourValue);
                }
            }

            void ShowMenu()
            {
                int opcao = 0;

                while (opcao != 11)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1 - Cadastro autoático");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Test1();
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

````
