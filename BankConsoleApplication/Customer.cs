using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class Customer
    {
        public string CustomerName;
        public string CustomerMobile;

        public Customer(string customerName)
        {
            this.CustomerName = customerName;
            Console.WriteLine("Enter Customer Contact number : ");
            CustomerMobile = Console.ReadLine();
        }
    }
}
