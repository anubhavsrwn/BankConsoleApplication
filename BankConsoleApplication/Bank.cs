using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Bank
    {
        public string BankName { get; set; }
        public string BankId { get; set; }
        public string Currency { get; set; }
        public BankStaff Bankstaff;
        public List<Account> Accounts;

        public Bank()
        {
            Console.WriteLine("Enter Bank Name");
            BankName = Console.ReadLine();
            GenerateBankId();
            Currency = "INR";
            Bankstaff = new BankStaff(BankName);
        }


        public void GenerateBankId()
        {
            BankId = BankName.Substring(0, 3) + DateTime.Now.ToString("yyMMddHHmmss");
        }
        public void BankInfo()
        {
            Console.WriteLine("Bank Name : " + BankName);
            Console.WriteLine("Bank Id : " + BankId);
            Console.WriteLine("Bank Currency : " + Currency);
        }

        public void CreateAccount()
        {
            Accounts.Add(new Account());
        }


    }
}
