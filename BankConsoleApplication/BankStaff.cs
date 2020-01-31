using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsoleApplication
{
    class BankStaff
    {
        public string BankStaffName { get; set; }
        public string BankStaffId  { get; set; }
        public string BankStaffPassword { get; set; }
        
        public BankStaff(string BankName)
        {
            Console.WriteLine("Enter Staff Name");
            BankStaffName = Console.ReadLine();
            BankStaffId = BankStaffName + "@" + BankName.Substring(0, 3);
            Console.WriteLine("Staff Bank ID is : " + BankStaffId);
            Console.WriteLine("Create Staff Password");
            BankStaffPassword = Console.ReadLine();
        }

        
        /*
        public ModifyAccount();
        public ShowTransaction();
        public RevertTransaction(); 
        */


    }
}
