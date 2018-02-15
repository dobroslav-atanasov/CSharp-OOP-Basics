using System;

public class Startup
{
    public static void Main()
    {
        BankAccount account = new BankAccount();
        account.Id = 1;
        account.Deposit(100);
        account.Withdraw(25);

        Console.WriteLine(account.ToString());
    }
}