using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Customer
    {
        public string CustomerName;
        public string CustomerId;
        public string CustomerPassword;

        public Customer(string customerName, string customerId)
        {
            this.CustomerName = customerName;
            this.CustomerId = customerId;
            Console.WriteLine("Customer Id is : "+ CustomerId);
            Console.WriteLine("Create a Password");
            CustomerPassword = Console.ReadLine();
        }
    }
}
