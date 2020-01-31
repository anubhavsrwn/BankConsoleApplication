using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Account
    {

        public string AccountId { get; set; }
        public string AccountHolderName { get; set; }
        public decimal AccountBalance { get; set; }
        public Customer Customer;
        
            
        public Account()
        {
            Console.WriteLine("Enter the Name of the Account Holder");
            AccountHolderName = Console.ReadLine();
            Customer = new Customer(AccountHolderName);
            Console.WriteLine("Enter the amount of Initial Deposit : ");
            AccountBalance += Convert.ToDecimal(Console.ReadLine());
        }

        public void GenerateAccountId()
        {
            AccountId = AccountHolderName.Substring(0, 3) + DateTime.Now.ToString("yyMMddHHmmss");
        }

    }
}
