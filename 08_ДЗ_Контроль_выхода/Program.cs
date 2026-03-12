using System;

public class Program
{
    static void Main(string[] args)
    {
        string imputPrase;
        string exitPrase = "exit";

        Console.Write("Введите фразу: ");
        imputPrase = Console.ReadLine();

        while (imputPrase != exitPrase)
        {
            Console.Write("Введите фразу: ");
            imputPrase = Console.ReadLine();
        }

        Console.WriteLine("Программа Завершена");
    }
}