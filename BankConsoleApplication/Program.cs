using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Bank> BankList = new List<Bank>();
            Menu:
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Create New Bank");
            Console.WriteLine("2. View All Banks");
            Console.WriteLine("3. Login As an BankStaff");
            Console.WriteLine("Enter Your Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BankList.Add(new Bank());
                    goto Menu;
                case 2:
                    foreach (var bank in BankList)
                    {
                        bank.BankInfo();
                    }
                    goto Menu;
                case 3: 

                    break;


                default:
                    break;
            }

        }
    }
}
