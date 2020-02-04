using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Bank
    {
        public string BankName { get; set; }
        public string BankId { get; set; }
        public decimal SIMPS = 0.05m;
        public decimal OIMPS = 0.06m;
        public decimal SRTGS = 0m;
        public decimal ORTGS = 0.02m;
        public string Currency { get; set; }
        public BankStaff Bankstaff { get; set; }
        public List<Account> Accounts = new List<Account>();
        public List<Transaction> BankTransactions = new List<Transaction>();

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
            BankId = BankName.Substring(0, 3) + DateTime.Now.ToString("mmss");
        }

        public void BankInfo()
        {
            Console.WriteLine("\nBank Name : " + BankName);
            Console.WriteLine("Bank Id : " + BankId);
            Console.WriteLine("Bank Currency : " + Currency + "\n");
        }

        public void CreateAccount()
        {
            Accounts.Add(new Account(BankName, BankId));
        }

        public void DeleteAccount()
        {
            Console.WriteLine("Enter Account Id of Account to be deleted : ");
            string accountId = Console.ReadLine();
            Accounts.RemoveAll(x => x.AccountId == accountId);
            Console.WriteLine("Account Deleted!");
        }

        public void ShowTransactions()
        {
            foreach (var Account in Accounts)
            {
                Account.TransactionHistory();
            }
        }

        public void FundTransfer(Account sAccountId, Account rAccountId)
        {
            string sendersAccountId = sAccountId.AccountId;
            string receiversAccountId = rAccountId.AccountId;
            decimal amount;
            decimal ServiceCharge;
            Console.WriteLine("Enter Receiver's AccountId : ");
            receiversAccountId = Console.ReadLine();
            Console.WriteLine("Enter Amount : ");
            amount = Convert.ToDecimal(Console.ReadLine());
            if(sendersAccountId.Substring(4,7)==receiversAccountId.Substring(4,7))
            {

                Console.WriteLine("Select One :");
                Console.WriteLine("1. IMPS (5%)");
                Console.WriteLine("2. RTGS (0%)");
                Console.WriteLine("RTGS will be default.");
                int choice = Convert.ToInt32(Console.ReadKey());
                switch(choice)
                {
                    case 1:
                        ServiceCharge = SIMPS;
                        break;

                    case 2:
                        ServiceCharge = SRTGS;
                        break;

                    default:
                        ServiceCharge = SRTGS;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Select One :");
                Console.WriteLine("1. IMPS (6%)");
                Console.WriteLine("2. RTGS (2%)");
                Console.WriteLine("RTGS will be default.");
                int choice = Convert.ToInt32(Console.ReadKey());
                switch (choice)
                {
                    case 1:
                        ServiceCharge = OIMPS;
                        break;

                    case 2:
                        ServiceCharge = ORTGS;
                        break;

                    default:
                        ServiceCharge = ORTGS;
                        break;
                }
                sAccountId.Withdrawal(amount);
                rAccountId.Deposit(amount - ServiceCharge * amount);
            }
        }
    }
}