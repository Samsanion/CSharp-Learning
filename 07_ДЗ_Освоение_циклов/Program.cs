using System;

public class Program
{
    static void Main(string[] args)
    {
        string repitPrase;
        int numberRepit;

        Console.Write("Введите фразу для повторения: ");
        repitPrase = Console.ReadLine();
        Console.Write("Сколько раз вы хотите ее повторить: ");
        numberRepit = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numberRepit; i++)
        {
            Console.WriteLine($"{i + 1}. {repitPrase}");
        }
    }
}