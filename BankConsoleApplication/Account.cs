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
        public List<Transaction> AccountTransactions = new List<Transaction>();
        
            
        public Account(string BankName, string BankId)
        {
            Console.WriteLine("Enter the Name of the Account Holder");
            AccountHolderName = Console.ReadLine();
            GenerateAccountId( BankName);
            Customer = new Customer(AccountHolderName, AccountId);
            Console.WriteLine("Bank Id : " + BankId);
            Console.WriteLine("Enter the amount of Initial Deposit : ");
            AccountBalance += Convert.ToDecimal(Console.ReadLine());
            AccountTransactions.Add(new Transaction("Account Created", AccountId, AccountBalance, AccountBalance));
        }

        public void GenerateAccountId(string BankName)
        {
            AccountId = AccountHolderName.Substring(0,3)+"@"+BankName.Substring(0,3) + DateTime.Now.ToString("mmss");
        }

        public void Deposit()
        {
            Console.WriteLine("Enter Amount to be deposited : ");
            decimal depositAmount =Convert.ToDecimal(Console.ReadLine());
            AccountBalance += depositAmount;
            Console.WriteLine("Updated balance : " + AccountBalance);
            AccountTransactions.Add(new Transaction("Deposit", AccountId, depositAmount, AccountBalance));
        }

        public void Deposit(decimal depositAmount)
        {
            
            AccountBalance += depositAmount;
            Console.WriteLine("Updated balance : " + AccountBalance);
            AccountTransactions.Add(new Transaction("Deposit", AccountId, depositAmount, AccountBalance));
        }

        public void Withdrawal()
        {
            Console.WriteLine("Enter Amount to be Withdrawn : ");
            decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
            AccountBalance -= withdrawalAmount;
            Console.WriteLine("Updated balance : " + AccountBalance);
            AccountTransactions.Add(new Transaction("Withdrawal", AccountId, withdrawalAmount, AccountBalance));

        }


        public void Withdrawal(decimal withdrawalAmount)
        {
            
            AccountBalance -= withdrawalAmount;
            Console.WriteLine("Updated balance : " + AccountBalance);
            AccountTransactions.Add(new Transaction("Withdrawal", AccountId, withdrawalAmount, AccountBalance));

        }


        public void TransactionHistory()
        {
            foreach (var AccountTransaction in AccountTransactions)
            {
                AccountTransaction.Display();
            }
        }


    }
}
