using System;

public class Program
{
    static void Main(string[] args)
    {
        int number = ReadInt();

        Console.WriteLine($"Преобразовано успешно: {number}");
    }

    static int ReadInt()
    {
        int number = 0;
        string input = "";
        bool success = false;

        while (success == false)
        {
            Console.Write("Введите строку для преобразования в число: ");
            input = Console.ReadLine();

            success = int.TryParse(input, out number);

            if (success == false)
                Console.WriteLine("Строка не является числом.\n");
        }

        return number;
    }
}