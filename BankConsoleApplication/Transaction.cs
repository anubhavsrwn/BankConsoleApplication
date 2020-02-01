using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Transaction
    {
        public string TransactionType; //Deposit, Withdrawal or Fund Transfer
        public string SendersAccountId { get; set; }
        public string ReciversAccountId { get; set; }
        public decimal Amount { get; set; }
        public Transaction()
        {
            
           
        }
    }
}
