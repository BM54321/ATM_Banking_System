using System;

namespace ATMSystem;

public class Account
{
    private string AccountName;
    private string AccountNumber;
    private string PIN;
    private decimal Balance;

    public Account(string name, string number, string pin)
    {
        AccountName = name;
        AccountNumber = number;
        PIN = pin;
        Balance = 0;
    }
    public Account(string name, string number, string pin, decimal balance)
    {
        AccountName = name;
        AccountNumber = number;
        PIN = pin;
        Balance = balance;
    }

    //===========Name===========
    public string getName()
    {
        return AccountName;
    }
    public void setName(string name)
    {
        AccountName = name;
    }

    //===========Number===========
    public string getNumber()
    {
        return AccountNumber;
    }
    public void setNumber(string number)
    {
        AccountNumber = number;
    }

    //===========PIN===========
    public string getPIN()
    {
        return PIN;
    }
    public void setPIN(string pin)
    {
        PIN = pin;
    }

    //===========Balance===========
    public decimal getBalance()
    {
        return Balance;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
    public void Transfer(Account receiver, decimal amount)
    {
        Balance -= amount;
        receiver.Receive(amount);

    }
    private void Receive(decimal amount)
    {
        Balance += amount;
    }

}