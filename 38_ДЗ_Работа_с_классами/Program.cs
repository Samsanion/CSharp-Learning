using System;

public class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Xomo", 10000);

        player.ShouInfo();

        player.DecreaseBalance(500);

        player.IncreaseBalance(400);
    }
}

public class Player
{
    private string _name;

    private int _balance;

    public Player(string name, int balance)
    {
        _name = name;
        _balance = balance;
    }

    public void ShouInfo()
    {
        Console.WriteLine($"Добро пожаловать {_name}");
        ShouBalance();
    }

    public void IncreaseBalance(int value)
    {
        _balance += value;
    }

    public void DecreaseBalance(int value)
    {
        _balance -= value;
    }

    private void ShouBalance() => Console.WriteLine($"Ваш баланс: {_balance}");
}