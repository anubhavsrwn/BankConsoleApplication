using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankConsoleApplication
{
    class Program
    {
        static List<Bank> BankList = new List<Bank>();
        static void CreateNewBank()
        {
            BankList.Add(new Bank());
            Console.WriteLine("Bank Created...");
            Console.ReadKey();
            Menu();
        }
        static void ViewAllBanks()
        {
            if (BankList.Count == 0)
            {
                Console.WriteLine("No Existing Banks!");
                Console.ReadKey();
                Menu();
            }
            foreach (var bank in BankList)
            {
                bank.BankInfo();
            }
            Console.ReadKey();
            Menu();
        }
        static void LoginBankStaff()
        {
            if (BankList.Count == 0)
            {
                Console.WriteLine("No Existing Banks!");
                Console.ReadKey();
                Menu();
            }
            Console.WriteLine("Select a bank to Login as an Bank Staff");
            for (int i = 0; i < BankList.Count; i++)
            {
                Bank bank = BankList[i];
                Console.WriteLine((i + 1) + "." + bank.BankName);
            }
            int choiceBank = Convert.ToInt32(Console.ReadLine());
            choiceBank--;
            if (choiceBank >= BankList.Count)
            {
                Console.WriteLine("Invalid Selection!");
                Console.ReadKey();
                Menu();
            }
            Console.WriteLine("Enter Bank Staff ID : ");
            string bankStaffId = Console.ReadLine();
            Console.WriteLine("Enter Your Password : ");
            string bankStaffPassword = Console.ReadLine();

            if ((BankList[choiceBank].Bankstaff.BankStaffId == bankStaffId) && (BankList[choiceBank].Bankstaff.BankStaffPassword == bankStaffPassword))
            {
            StaffLoginMenu:
                Console.Clear();
                Console.WriteLine("Logged in as " + BankList[choiceBank].Bankstaff.BankStaffName);
                Console.WriteLine("Select any option : ");
                Console.WriteLine("1. Create an account.");
                Console.WriteLine("2. Delete an account.");
                Console.WriteLine("3. Show Transactions.");
                Console.WriteLine("4. Revert Transactions.");
                Console.WriteLine("5. Exit this menu.");
                int choice3 = Convert.ToInt32(Console.ReadLine());
                switch (choice3)
                {
                    case 1:
                        BankList[choiceBank].CreateAccount();
                        Console.WriteLine("Account Created Succesfully");
                        Console.ReadKey();
                        goto StaffLoginMenu;

                    case 2:
                        BankList[choiceBank].DeleteAccount();
                        Console.WriteLine("Account Deleted Succesfully");
                        Console.ReadKey();
                        goto StaffLoginMenu;

                    case 3:
                        BankList[choiceBank].ShowTransactions();
                        Console.ReadKey();
                        goto StaffLoginMenu;
                        
                    case 4:
                        BankList[choiceBank].RevertTransaction();
                        Console.ReadKey();
                        goto StaffLoginMenu;

                    case 5:
                        Menu();
                        break;

                    default:
                        goto StaffLoginMenu;
                }
            }

            else
            {
                Console.WriteLine("Invalid Credentials!");
            }
            Menu();

        }
        static void LoginCustomer()
        {
            if (BankList.Count == 0)
            {
                Console.WriteLine("No Existing Banks!");
                Console.ReadKey();
                Menu();
            }
            int index;
            Console.WriteLine("Select the bank in which you have an account");
            for (int i = 0; i < BankList.Count; i++)
            {
                Bank bank = BankList[i];
                Console.WriteLine((i + 1) + "." + bank.BankName);
            }
            int choiceBank = Convert.ToInt32(Console.ReadLine());
            choiceBank--;
            if (choiceBank >= BankList.Count)
            {
                Console.WriteLine("Invalid Selection!");
                Console.ReadKey();
                Menu();
            }
            if (BankList[choiceBank].Accounts.Count == 0)
            {
                Console.WriteLine("Accounts do not Exist!");
                Console.ReadKey();
                Menu();
            }
            Console.WriteLine("Enter customer ID : ");
            string customerId = Console.ReadLine();
            Console.WriteLine("Enter Your Password : ");
            string customerPassword = Console.ReadLine();

            for (index = 0; index < BankList[choiceBank].Accounts.Count; index++)
            {
                Account Account = (Account)BankList[choiceBank].Accounts[index];
                if ((Account.Customer.CustomerId == customerId) && (Account.Customer.CustomerPassword == customerPassword))
                {
                    Console.WriteLine("Successfully logged in as " + Account.Customer.CustomerName);
                    break;
                }

                else if (index == BankList[choiceBank].Accounts.Count - 1)
                {
                    Console.WriteLine("Invalid Credentials!");
                    Menu();
                }
            }

        CostumerLoginMenu:
            Console.Clear();
            Console.WriteLine("Logged in as " + BankList[choiceBank].Accounts[index].AccountHolderName);
            Console.WriteLine("Select any option : ");
            Console.WriteLine("1. Make a Deposit.");
            Console.WriteLine("2. Make a Withdrawal.");
            Console.WriteLine("3. Transfer funds.");
            Console.WriteLine("4. View Transactions.");
            Console.WriteLine("5. Exit this menu.");
            int choice4 = Convert.ToInt32(Console.ReadLine());
            switch (choice4)
            {
                case 1:
                    BankList[choiceBank].Accounts[index].Deposit();
                    Console.ReadKey();
                    goto CostumerLoginMenu;

                case 2:
                    BankList[choiceBank].Accounts[index].Withdrawal();
                    Console.ReadKey();
                    goto CostumerLoginMenu;

                case 3:
                    Console.WriteLine("Enter Receiver's Bank ID : ");
                    int bankIndex, accountIndex;
                    string bankId = Console.ReadLine();
                    for (bankIndex = 0; bankIndex < BankList.Count; bankIndex++)
                    {
                        Bank Bank = (Bank)BankList[bankIndex];
                        if (Bank.BankId == bankId)
                        {

                            break;
                        }
                        else if (bankIndex == BankList.Count - 1)
                        {
                            Console.WriteLine("Bank not found!");
                            goto CostumerLoginMenu;
                        }
                    }
                    Console.WriteLine("Enter Receiver's Account ID : ");
                    string receiverAccountId = Console.ReadLine();
                    for (accountIndex = 0; accountIndex < BankList[bankIndex].Accounts.Count; accountIndex++)
                    {
                        Account Account = (Account)BankList[bankIndex].Accounts[accountIndex];
                        if (Account.AccountId == receiverAccountId)
                        {
                            break;
                        }
                        else if (accountIndex == BankList[bankIndex].Accounts.Count - 1)
                        {
                            Console.WriteLine("Account not found!");
                            goto CostumerLoginMenu;
                        }
                    }
                    BankList[choiceBank].FundTransfer(BankList[choiceBank].Accounts[index], BankList[bankIndex].Accounts[accountIndex]);
                    Console.ReadKey();
                    goto CostumerLoginMenu;

                case 4:
                    BankList[choiceBank].Accounts[index].TransactionHistory();
                    Console.ReadKey();
                    goto CostumerLoginMenu;

                case 5:
                    Menu();
                    break;

                default:
                    goto CostumerLoginMenu;
            }
            Menu();

        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Create New Bank.");
            Console.WriteLine("2. View All Banks.");
            Console.WriteLine("3. Login as a Bank Staff.");
            Console.WriteLine("4. Login as a Customer.");
            Console.WriteLine("5. Exit.");
            Console.WriteLine("Enter Your Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    CreateNewBank();
                    break;
                case 2:
                    ViewAllBanks();
                    break;
                case 3:
                    LoginBankStaff();
                    break;
                case 4:
                    LoginCustomer();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Menu();
                    break;
            }
        }
        static void Main(string[] args)
        {
            Menu();
            
        }
        
        
           
    }
}
