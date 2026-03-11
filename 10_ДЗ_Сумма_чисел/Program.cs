using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limitDowm = 0;
            int limitUp = 101;

            Random random = new Random();
            int number = random.Next(limitDowm, limitUp);

            int sum = 0;
            int divisor1 = 3;
            int divisor2 = 5;

            for (int i = 0; i <= number; i++)
            {
                if (i % divisor1 == 0 || i % divisor2 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Ответ: {sum}");
        }
    }
}