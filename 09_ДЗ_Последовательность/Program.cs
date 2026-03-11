using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sequenceStep;
            int sequenceLimit;
            int sequenceStart;

            Console.Write("Введите шаг последовательности: ");
            sequenceStep = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите передел последовательности: ");
            sequenceLimit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите начало последовательности: ");
            sequenceStart = Convert.ToInt32(Console.ReadLine());

            for (int i = sequenceStart; i <= sequenceLimit; i += sequenceStep)
            {
                Console.WriteLine(i);
            }
        }
    }
}