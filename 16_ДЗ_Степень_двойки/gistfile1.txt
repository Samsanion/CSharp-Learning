using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minRandomAmount = 0;
            int maxRandomAmount = 100;
            Random random = new Random();

            int baseDegree = 2;
            int degree = 1;
            int intermediateValue = 1;

            int givenNumber = random.Next(minRandomAmount, maxRandomAmount);

            while (intermediateValue <= givenNumber)
            {
                intermediateValue *= baseDegree * degree;
                degree++;
            }

            Console.WriteLine($"Для числа {givenNumber} ответом будет число: {intermediateValue}.\nЭто {baseDegree} в степени {degree}");
        }
    }
}