using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Transaction
    {
        public string TransactionType { get; set; } //Deposit, Withdrawal or Fund Transfer
        public string TransactionId { get; set; }
        public string AccountId { get; set; }
        public string SendersAccountId { get; set; }
        public string ReceiversAccountId { get; set; }
        public decimal UpdatedBalance { get; set; }
        public decimal Amount { get; set; }

        public void GenerateTransactionId()
        {
            TransactionId = "TXN"+ DateTime.Now.ToString("yyMMddHHmmss");
        }



        public Transaction(string transactionType, string accountId, decimal amount, decimal updatedbalance)
        {
            this.TransactionType = transactionType;
            this.Amount = amount;
            this.AccountId = accountId;
            this.UpdatedBalance = updatedbalance;
            GenerateTransactionId();
        }

        public Transaction(string transactionType, decimal amount, string sendersAccountId, string receiversAccountId)
        {
            this.TransactionType = transactionType;
            this.Amount = amount;
            this.SendersAccountId = sendersAccountId;
            this.ReceiversAccountId = receiversAccountId;
            GenerateTransactionId();
        }

        public Transaction(string transactionType, string accountId, string accountId2, decimal amount, decimal updatedBalance)
        {
            this.TransactionType = transactionType;
            AccountId = accountId;
            if (transactionType == "Sent to")
            {
                this.ReceiversAccountId = accountId2;
            }
            else
            { 
            this.SendersAccountId = accountId2;
            }
            this.Amount = amount;
            this.UpdatedBalance = updatedBalance;
            GenerateTransactionId();
        }

        public void Display()
        {
            Console.WriteLine(AccountId + " | " + TransactionId +" | "+ TransactionType + " | "+SendersAccountId + ReceiversAccountId +" | " + Amount + " | BAL : " + UpdatedBalance);
        }
    }
}
