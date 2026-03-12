using System;

public class Program
{
    static void Main(string[] args)
    {
        string userName;
        string userNout;
        string frameLine = "";
        string nameLine;

        Console.Write("Ваше имя: ");
        userName = Console.ReadLine();
        Console.Write("Символ рамки: ");
        userNout = Console.ReadLine();

        nameLine = userNout + userName + userNout;

        for (int i = 0; i < nameLine.Length; i++)
        {
            frameLine += userNout;
        }

        Console.WriteLine($"{frameLine}\n{nameLine}\n{frameLine}");
    }
}