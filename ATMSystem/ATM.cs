using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ATMSystem;

public class ATM
{
    Account currentAccount = null;
    private int accountNumber = 100123;
    private String adminUsername = null;
    private String adminPassword = null;

    public void setAdmin(String usrname, String pass)
    {
        adminUsername = usrname;
        adminPassword = pass;
    }
    public void startUp(List<Account> accounts)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.ResetColor();

                Console.WriteLine("\n\n\t  [1] Login");
                Console.WriteLine("\t  [2] Create Account");
                Console.WriteLine("\t  [3] Admin");
                Console.WriteLine("\t  [4] Exit");
                Console.Write("\n\tEnter choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    loginPage(accounts);
                else if (choice == 2)
                    createUserAccount(accounts);
                else if (choice == 3)
                    loginAdmin(accounts);
                else if (choice == 4)
                    return;
                
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tInvalid Input");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n  ==============================================");
        Console.WriteLine("      THANK YOU FOR USING ATM BANKING SYSTEM    ");
        Console.WriteLine("  ==============================================");
        Console.ResetColor();
        Console.ReadKey();
    }

    public void loginUser(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t              Login             ");
            Console.ResetColor();

            Console.WriteLine("\n\tEnter [Q] to cancel/exit");
            Console.Write("\n\n\t  Account Number : ");

            string num = Console.ReadLine();

            if (num == "Q" || num == "q")
            {
                return;
            }

            Console.Write("\n\t  Enter PIN      : ");
            string pin = Console.ReadLine();

            if (pin == "Q" || pin == "q")
            {
                return;
            }

            bool found = false;

            foreach (Account acc in accounts)
            {
                if (acc.getNumber() == num && acc.getPIN() == pin)
                {
                    currentAccount = acc;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tLogin successful!");
                Console.ResetColor();

                Console.ReadKey();

                userMenu(accounts);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tWrong number or PIN");
            Console.ResetColor();

            Console.ReadKey();
        }
    }

    public void loginAdmin(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           Admin Login          ");
            Console.ResetColor();

            Console.WriteLine("\n\tEnter [Q] to cancel/exit");
            Console.Write("\n\n\t  Username       : ");
            string username = Console.ReadLine();

            if (username == "Q" || username == "q")
            {
                return;
            }

            Console.Write("\n\t  Enter password : ");
            string pass = Console.ReadLine();

            if (pass == "Q" || pass == "q")
            {
                return;
            }

            if (username == adminUsername && pass == adminPassword)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\tLogin successful!");
                Console.ResetColor();
                Console.ReadKey();
                adminMenu(accounts);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\tWrong number or PIN");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

    public void userMenu(List<Account> accounts)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.WriteLine("\t              MENU              ");
                Console.ResetColor();
                Console.WriteLine("\n\tWellcome " + currentAccount.getName());
                Console.WriteLine("\n\n\t  [1] Check Balance");
                Console.WriteLine("\t  [2] Deposit");
                Console.WriteLine("\t  [3] Withraw");
                Console.WriteLine("\t  [4] Send");
                Console.WriteLine("\t  [5] Transaction History");
                Console.WriteLine("\t  [6] Profile");
                Console.WriteLine("\t  [7] Logout");
                Console.Write("\n\tEnter choice : ");
                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                    checkBalance();
                else if (choice == 2)
                    Deposit();
                else if (choice == 3)
                    Withdraw();
                else if (choice == 4)
                    Send(accounts);
                else if (choice == 6)
                    accountProfile(accounts);
                else if (choice == 7)
                    return;
                else
                    continue;

               
            }
            catch (Exception)
            {
               
            }
           
        }
    }

    public void adminMenu(List<Account> accounts)
    {
        while (true)
        {
            try
            {


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.WriteLine("\t            ADMIN MENU          ");
                Console.ResetColor();
                Console.WriteLine("\n\tADMIN");
                Console.WriteLine("\n\n\t  [1] Create Account");
                Console.WriteLine("\t  [2] Update Information");
                Console.WriteLine("\t  [3] Delete User Information");
                Console.WriteLine("\t  [4] Bank Statistic");
                Console.WriteLine("\t  [5] Logout");

                Write("\n\t  ➤ ", ConsoleColor.Green);
                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                    createUserAccount(accounts);
                if (choice == 2)
                {

                }
                if (choice == 4)
                    bankStatistics(accounts);
                else if (choice == 5)
                {
                    return;
                }
                else
                    continue;


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid Input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

        }
    }

    public void Send(List<Account> accounts)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.WriteLine("\t             SEND            ");
                Console.ResetColor();
                Console.WriteLine("\n\tEnter [Q] to cancel/exit");
                Console.Write("\n\n\t  Send to ");
                Console.Write("\n\n\t    Acc. Number : ");
                string input = Console.ReadLine();
                if (input == "Q" || input == "q")
                    return;
                bool found = false;
                Account receiver = null;
                foreach (Account acc in accounts)
                {
                    if (acc.getNumber() == input)
                    {
                        receiver = acc;
                        found = true;
                        break;
                    }
                }
                if(found)
                {
                    Console.WriteLine("\n\n\t    Name   : " + receiver.getName());
              
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tAccount not found");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                while(true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t================================");
                    Console.WriteLine("\t           ATM MACHINE          ");
                    Console.WriteLine("\t================================");
                    Console.WriteLine("\t             SEND            ");
                    Console.ResetColor();
                    Console.WriteLine("\n\tEnter [Q] to cancel/exit");
                    Console.Write("\n\n\t  Send to ");
                    Console.Write("\n\n\t    Acc. Number : "+input);
                    Console.WriteLine("\n\n\t     Name   : " + receiver.getName());
                    decimal amount;
                    Console.Write("\n\t     Amount : ");
                    amount = Convert.ToDecimal(Console.ReadLine());
                    if (amount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\tInvalid amount");
                        Console.ResetColor(); Console.ReadKey(); continue;
                    }
                    if (amount > currentAccount.getBalance())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\tInsuficient balance");
                        Console.ResetColor(); Console.ReadKey(); continue;
                    }
                    currentAccount.Transfer(receiver, amount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n\tTransfer success");
                    Console.ResetColor(); Console.ReadKey(); return;
                }
                


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tInvalid input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

        }
    }

    public void bankStatistics(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t          BANK STATISTIC        ");
            Console.ResetColor();
            WriteLine("\n\n\t  Total users : " + accounts.Count(), ConsoleColor.Green);
            decimal totalMoney = 0;
            foreach (Account acc in accounts)
            {
                totalMoney += acc.getBalance();
            }
            WriteLine("\n\t  Total money : ₱" + totalMoney.ToString("N2"), ConsoleColor.Green);
            Console.Write("\n\tEnter [Q] to return ");
            string choice = Console.ReadLine();
            if (choice == "Q" || choice == "q")
                return;
        }
    }

    public void Withdraw()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.WriteLine("\t             WITHDRAW            ");
                Console.ResetColor();
                Console.WriteLine("\n\tEnter [Q] to cancel/exit");
                Console.Write("\n\n\t  Ammount : ");
                string input = Console.ReadLine();
                if (input == "Q" || input == "q")
                    return;

                decimal amount;
                if (!decimal.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tInvalid input");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tInvalid amount");
                    Console.ResetColor(); Console.ReadKey(); continue;
                }
                if (amount > currentAccount.getBalance())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tInsuficient balance");
                    Console.ResetColor(); Console.ReadKey(); continue;
                }
                currentAccount.Withdraw(amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\tWithdraw success");
                Console.ResetColor(); Console.ReadKey(); return;


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tInvalid input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

        }
    }

    public void checkBalance()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t================================");
        Console.WriteLine("\t           ATM MACHINE          ");
        Console.WriteLine("\t================================");
        Console.WriteLine("\t             BALANCE            ");
        Console.ResetColor();
        Console.Write("\n\n\t  Balance : ₱");
        Console.WriteLine(currentAccount.getBalance().ToString("N2"));
        Console.Write("\n\n\tPress any key to return...");
        Console.ReadKey();
    }

    public void Deposit()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.WriteLine("\t             DEPOSIT            ");
                Console.ResetColor();
                Console.WriteLine("\n\tEnter [Q] to cancel/exit");
                Console.Write("\n\n\t  Ammount : ₱");
                string input = Console.ReadLine();
                if (input == "Q" || input == "q")
                    return;

                decimal amount;
                if (!decimal.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tInvalid amount");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tInvalid amount");
                    Console.ResetColor(); Console.ReadKey(); continue;
                }
                currentAccount.Deposit(amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\tDeposit success");
                Console.ResetColor(); Console.ReadKey(); return;


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tInvalid input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

        }
    }

    public void accountProfile(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t             PROFILE            ");
            Console.ResetColor();
            Console.WriteLine("\n\n\t  " + currentAccount.getName());
            Console.WriteLine("\t  " + currentAccount.getNumber());
            Console.WriteLine("\t  PIN : " + currentAccount.getPIN());
            Console.WriteLine("\n\t  [1] Change Info");
            Console.WriteLine("\t  [2] Exit");
            Write("\n\t  ➤ ", ConsoleColor.Green);
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                updateAcc(accounts);
            if (choice == 2)
                return;
        }


    }

    public void updateAcc(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t             PROFILE            ");
            Console.ResetColor();
            Console.WriteLine("\n\tUpadte Profile");
            Console.WriteLine("\n\n\t  [1] Name");
            Console.WriteLine("\t  [2] PIN");
            Console.WriteLine("\t  [3] Exit");
            Write("\n\t  ➤ ", ConsoleColor.Green);
            int choice = int.Parse(Console.ReadLine());
            //UPDATE NAME
            if (choice == 1)
                updateName();
            //UPDATE PIN
            if (choice == 2)
                updatePIN();
            if (choice == 3)
                break;

        }


    }

    public void updateName()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           UPDATE NAME          ");
            Console.ResetColor();
            Console.WriteLine("\n\tEnter [Q] to cancel/exit");
            Console.Write("\n\n\t  Name : ");
            string name = Console.ReadLine();
            if (name == "Q" || name == "q")
            {
                return;
            }
            if (name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                currentAccount.setName(name);
                Write("\n\n\tName updated successfuly", ConsoleColor.Green);
                Console.ReadKey();
                return;
            }
            else
            {
                Write("\n\n\tInvalid name. Numbers and special characters are not allowed", ConsoleColor.Red);
                Console.ReadKey();
                continue;
            }
        }
    }

    public void updatePIN()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           UPDATE PIN           ");
            Console.ResetColor();
            Console.WriteLine("\n\tEnter [Q] to cancel/exit");
            WriteLine("\n\t  Enter a 6 digit PIN", ConsoleColor.Gray);
            Console.Write("\t  New PIN :");
            string pin = Console.ReadLine();
            if (pin == "Q" || pin == "q")
            {
                return;
            }
            if (!long.TryParse(pin, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n\tInvalid PIN! Numbers only.");
                Console.ResetColor();
            }
            if (pin.Length == 6 && long.TryParse(pin, out _))
            {
                currentAccount.setPIN(pin);
                Write("\n\n\tPIN updated successfuly", ConsoleColor.Green);
                Console.ReadKey();
                return;
            }
            else
            {
                Write("\n\n\tPIN must contain exactly 6 numbers!", ConsoleColor.Red);
                Console.ReadKey();
                continue;
            }
        }

    }
    public void loginPage(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t================================");
            Console.WriteLine("\t           ATM MACHINE          ");
            Console.WriteLine("\t================================");
            Console.WriteLine("\t              Login             ");
            Console.ResetColor();

            Console.WriteLine("\n\tEnter [Q] to cancel/exit");
            Console.Write("\n\n\t  Account Number : ");

            string num = Console.ReadLine();

            if (num == "Q" || num == "q")
            {
                return;
            }

            Console.Write("\n\t  Enter PIN      : ");
            string pin = Console.ReadLine();

            if (pin == "Q" || pin == "q")
            {
                return;
            }

            bool found = false;

            foreach (Account acc in accounts)
            {
                if (acc.getNumber() == num && acc.getPIN() == pin)
                {
                    currentAccount = acc;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tLogin successful!");
                Console.ResetColor();

                Console.ReadKey();

                userMenu(accounts);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tWrong number or PIN");
            Console.ResetColor();

            Console.ReadKey();
        }
    }

    public void createUserAccount(List<Account> accounts)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t================================");
                Console.WriteLine("\t           ATM MACHINE          ");
                Console.WriteLine("\t================================");
                Console.WriteLine("\t          Create Account        ");
                Console.ResetColor();
                Console.WriteLine("\n\tEnter [Q] to cancel/exit");

                Account n = new Account(null, null, null);
                string accNum = accountNumber.ToString();

                //Name
                Console.Write("\n\n\t  Name      : ");
                string name = Console.ReadLine();
                if (name == "Q" || name == "q")
                {
                    break;
                }
                if (name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    n.setName(name);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tInvalid name. Numbers and special characters are not allowed");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                //PIN
                Console.Write("\n\t  Enter PIN : ");
                string pin = Console.ReadLine();
                if (pin == "Q" || pin == "q")
                {
                    return;
                }
                if (!long.TryParse(pin, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid PIN! Numbers only.");
                    Console.ResetColor();
                }
                if (pin.Length == 6 && long.TryParse(pin, out _))
                {
                    n.setPIN(pin);
                    n.setNumber(accNum); //Acc Number
                    accounts.Add(n);
                    Console.WriteLine("\n\tAccount Number: " + accNum);
                    accountNumber++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tAccount created successfuly");
                    Console.ResetColor();
                    Console.WriteLine("\n\nPress any key to proceed to login page....");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("PIN must contain exactly 6 numbers!");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }
            
        }
    }

    public void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}