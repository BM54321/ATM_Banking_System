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
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("MENU");
                Console.ResetColor();
                Console.WriteLine("\n");

                BlockLine("[1] Login");
                BlockLine("[2] Create Account");
                BlockLine("[3] Admin");
                BlockLine("[4] Exit");
                ChoicePrompt();

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    loginPage(accounts);
                else if (choice == 2)
                    createUserAccount(accounts);
                else if (choice == 3)
                    loginAdmin(accounts);
                else if (choice == 4)
                    break;

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n" + Pad() + "Invalid Input");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        CenterLine("==============================================");
        CenterLine("THANK YOU FOR USING ATM BANKING SYSTEM");
        CenterLine("==============================================");
        Console.ResetColor();
        Console.ReadKey();
    }

    public void loginUser(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("Login");
            Console.ResetColor();

            Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
            Console.Write("\n\n" + Pad() + "Account Number : ");

            string num = Console.ReadLine();

            if (num == "Q" || num == "q")
            {
                return;
            }

            Console.Write("\n" + Pad() + "Enter PIN      : ");
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
                Console.Write("\n" + Pad() + "Login successful!");
                Console.ResetColor();

                Console.ReadKey();

                userMenu(accounts);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n" + Pad() + "Wrong number or PIN");
            Console.ResetColor();

            Console.ReadKey();
        }
    }

    public void loginAdmin(List<Account> accounts)
    {
        while (true)
        {
            Console.Clear();
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("Admin Login");
            Console.ResetColor();

            Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
            Console.Write("\n\n" + Pad() + "Username       : ");
            string username = Console.ReadLine();

            if (username == "Q" || username == "q")
            {
                return;
            }

            Console.Write("\n" + Pad() + "Enter password : ");
            string pass = Console.ReadLine();

            if (pass == "Q" || pass == "q")
            {
                return;
            }

            if (username == adminUsername && pass == adminPassword)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n" + Pad() + "Login successful!");
                Console.ResetColor();
                Console.ReadKey();
                adminMenu(accounts);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n" + Pad() + "Wrong number or PIN");
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
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("USER MENU");
                Console.ResetColor();
                Console.WriteLine("\n\n" + Pad() + "Wellcome " + currentAccount.getName() + "\n\n");
                BlockLine("[1] Check Balance");
                BlockLine("[2] Deposit");
                BlockLine("[3] Withraw");
                BlockLine("[4] Send");
                BlockLine("[5] Transaction History");
                BlockLine("[6] Profile");
                BlockLine("[7] Logout");
                ChoicePrompt();
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
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("ADMIN MENU");
                Console.ResetColor();
                Console.WriteLine("\n");
                BlockLine("[1] Create Account");
                BlockLine("[2] Update Information");
                BlockLine("[3] Delete User Information");
                BlockLine("[4] Bank Statistic");
                BlockLine("[5] Logout");

                ChoicePrompt();
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
                Console.Write(Pad() + "Invalid Input");
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
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("SEND");
                Console.ResetColor();
                Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
                Console.Write("\n\n" + Pad() + "Send to ");
                Console.Write("\n\n" + Pad() + "  Acc. Number : ");
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
                if (found)
                {
                    Console.WriteLine("\n\n" + Pad() + "  Name   : " + receiver.getName());

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n" + Pad() + "Account not found");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                while (true)
                {
                    Console.Clear();
                    spaceVertical();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    CenterLine("================================");
                    CenterLine("ATM MACHINE");
                    CenterLine("================================");
                    CenterLine("SEND");
                    Console.ResetColor();
                    Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
                    Console.Write("\n\n" + Pad() + "Send to ");
                    Console.Write("\n\n" + Pad() + "  Acc. Number : " + input);
                    Console.WriteLine("\n\n" + Pad() + "   Name   : " + receiver.getName());
                    decimal amount;
                    Console.Write("\n" + Pad() + "   Amount : ");
                    amount = Convert.ToDecimal(Console.ReadLine());
                    if (amount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + Pad() + "Invalid amount");
                        Console.ResetColor(); Console.ReadKey(); continue;
                    }
                    if (amount > currentAccount.getBalance())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + Pad() + "Insuficient balance");
                        Console.ResetColor(); Console.ReadKey(); continue;
                    }
                    currentAccount.Transfer(receiver, amount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n" + Pad() + "Transfer success");
                    Console.ResetColor(); Console.ReadKey(); return;
                }



            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n" + Pad() + "Invalid input");
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
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("BANK STATISTIC");
            Console.ResetColor();
            WriteLine("\n\n" + Pad() + "Total users : " + accounts.Count(), ConsoleColor.Green);
            decimal totalMoney = 0;
            foreach (Account acc in accounts)
            {
                totalMoney += acc.getBalance();
            }
            WriteLine("\n" + Pad() + "Total money : ₱" + totalMoney.ToString("N2"), ConsoleColor.Green);
            Console.Write("\n" + Pad() + "Enter [Q] to return ");
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
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("WITHDRAW");
                Console.ResetColor();
                Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
                Console.Write("\n\n" + Pad() + "Ammount : ");
                string input = Console.ReadLine();
                if (input == "Q" || input == "q")
                    return;

                decimal amount;
                if (!decimal.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n" + Pad() + "Invalid input");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n" + Pad() + "Invalid amount");
                    Console.ResetColor(); Console.ReadKey(); continue;
                }
                if (amount > currentAccount.getBalance())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n" + Pad() + "Insuficient balance");
                    Console.ResetColor(); Console.ReadKey(); continue;
                }
                currentAccount.Withdraw(amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n" + Pad() + "Withdraw success");
                Console.ResetColor(); Console.ReadKey(); return;


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n" + Pad() + "Invalid input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

        }
    }

    public void checkBalance()
    {
        Console.Clear();
        spaceVertical();
        Console.ForegroundColor = ConsoleColor.Cyan;
        CenterLine("================================");
        CenterLine("ATM MACHINE");
        CenterLine("================================");
        CenterLine("BALANCE");
        Console.ResetColor();
        Console.Write("\n\n" + Pad() + "Balance : ₱");
        Console.WriteLine(currentAccount.getBalance().ToString("N2"));
        Console.Write("\n\n" + Pad() + "Press any key to return...");
        Console.ReadKey();
    }

    public void Deposit()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("DEPOSIT");
                Console.ResetColor();
                Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
                Console.Write("\n\n" + Pad() + "Ammount : ₱");
                string input = Console.ReadLine();
                if (input == "Q" || input == "q")
                    return;

                decimal amount;
                if (!decimal.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n" + Pad() + "Invalid amount");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
                if (amount <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n" + Pad() + "Invalid amount");
                    Console.ResetColor(); Console.ReadKey(); continue;
                }
                currentAccount.Deposit(amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n" + Pad() + "Deposit success");
                Console.ResetColor(); Console.ReadKey(); return;


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n" + Pad() + "Invalid input");
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
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("PROFILE");
            Console.ResetColor();
            Console.WriteLine("\n\n" + Pad() + "" + currentAccount.getName());
            Console.WriteLine(Pad() + "" + currentAccount.getNumber());
            Console.WriteLine(Pad() + "PIN : " + currentAccount.getPIN());
            Console.WriteLine();
            BlockLine("[1] Change Info");
            BlockLine("[2] Exit");
            ChoicePrompt();
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
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("PROFILE");
            Console.ResetColor();
            Console.WriteLine("\n" + Pad() + "Upadte Profile");
            BlockLine("[1] Name");
            BlockLine("[2] PIN");
            BlockLine("[3] Exit");
            ChoicePrompt();
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
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("UPDATE NAME");
            Console.ResetColor();
            Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
            Console.Write("\n\n" + Pad() + "Name : ");
            string name = Console.ReadLine();
            if (name == "Q" || name == "q")
            {
                return;
            }
            if (name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                currentAccount.setName(name);
                Write("\n\n" + Pad() + "Name updated successfuly", ConsoleColor.Green);
                Console.ReadKey();
                return;
            }
            else
            {
                Write("\n\n" + Pad() + "Invalid name. Numbers and special characters are not allowed", ConsoleColor.Red);
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
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("UPDATE PIN");
            Console.ResetColor();
            Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
            WriteLine("\n" + Pad() + "Enter a 6 digit PIN", ConsoleColor.Gray);
            Console.Write(Pad() + "New PIN :");
            string pin = Console.ReadLine();
            if (pin == "Q" || pin == "q")
            {
                return;
            }
            if (!long.TryParse(pin, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n" + Pad() + "Invalid PIN! Numbers only.");
                Console.ResetColor();
            }
            if (pin.Length == 6 && long.TryParse(pin, out _))
            {
                currentAccount.setPIN(pin);
                Write("\n\n" + Pad() + "PIN updated successfuly", ConsoleColor.Green);
                Console.ReadKey();
                return;
            }
            else
            {
                Write("\n\n" + Pad() + "PIN must contain exactly 6 numbers!", ConsoleColor.Red);
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
            spaceVertical();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterLine("================================");
            CenterLine("ATM MACHINE");
            CenterLine("================================");
            CenterLine("Login");
            Console.ResetColor();

            Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");
            Console.Write("\n\n" + Pad() + "Account Number : ");

            string num = Console.ReadLine();

            if (num == "Q" || num == "q")
            {
                return;
            }

            Console.Write("\n" + Pad() + "Enter PIN      : ");
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
                Console.Write("\n" + Pad() + "Login successful!");
                Console.ResetColor();

                Console.ReadKey();

                userMenu(accounts);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n" + Pad() + "Wrong number or PIN");
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
                spaceVertical();
                Console.ForegroundColor = ConsoleColor.Cyan;
                CenterLine("================================");
                CenterLine("ATM MACHINE");
                CenterLine("================================");
                CenterLine("Create Account");
                Console.ResetColor();
                Console.WriteLine("\n" + Pad() + "Enter [Q] to cancel/exit");

                Account n = new Account(null, null, null);
                string accNum = accountNumber.ToString();

                //Name
                Console.Write("\n\n" + Pad() + "Name      : ");
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
                    Console.Write("\n" + Pad() + "Invalid name. Numbers and special characters are not allowed");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                //PIN
                Console.Write("\n" + Pad() + "Enter PIN : ");
                string pin = Console.ReadLine();
                if (pin == "Q" || pin == "q")
                {
                    return;
                }
                if (!long.TryParse(pin, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Pad() + "Invalid PIN! Numbers only.");
                    Console.ResetColor();
                }
                if (pin.Length == 6 && long.TryParse(pin, out _))
                {
                    n.setPIN(pin);
                    n.setNumber(accNum); //Acc Number
                    accounts.Add(n);
                    Console.Write("\n" + Pad() + "Account Number: " + accNum);
                    accountNumber++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n" + Pad() + "Account created successfuly");
                    Console.ResetColor();
                    Console.Write("\n\n" + Pad() + "Press any key to proceed to login page....");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Pad() + "PIN must contain exactly 6 numbers!");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }


            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Pad() + "Invalid Input");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

        }
    }

    // Width of the centered block (matches the "====" banner).
    private const int BlockWidth = 32;

    // Left margin that centers the block in the current console window.
    private string Pad()
    {
        return new string(' ', Math.Max(0, (Console.WindowWidth - BlockWidth) / 2));
    }

    private void BlockLine(string text)
    {
        Console.WriteLine(Pad() + "  " + text);
    }

    // Blank line, then the ➤ prompt in line with the menu items.
    private void ChoicePrompt()
    {
        Console.Write("\n" + Pad() + "  ➤ ");
    }

    // Centers menu and heading text in the console window.
    private void CenterLine(string text)
    {
        int leftPadding = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
        Console.WriteLine(new string(' ', leftPadding) + text);
    }

    private void CenterWrite(string text)
    {
        int leftPadding = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
        Console.Write(new string(' ', leftPadding) + text);
    }

    private void CenterWrite(string text, ConsoleColor color)
    {
        int leftPadding = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
        Console.ForegroundColor = color;
        Console.Write(new string(' ', leftPadding) + text);
        Console.ResetColor();
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

    public void spaceVertical()
    {
        Console.WriteLine("\n\n\n\n\n");
    }
}