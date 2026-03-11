using System;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int minRand = 0;
            int maxRand = 10;
            int replacementMaxValue = 0;

            int maxValueArray = 0;

            int[,] givenArray = new int[10, 10];

            Console.WriteLine($"Исходный массив:\n");

            for (int i = 0; i < givenArray.GetLength(0); i++)
            {
                for (int j = 0; j < givenArray.GetLength(1); j++)
                {
                    givenArray[i, j] = rand.Next(minRand, maxRand + 1);
                    Console.Write(givenArray[i, j] + " ");
                }

                Console.WriteLine();
            }

            foreach (int valueArray in givenArray)
            {
                if (valueArray > maxValueArray)
                    maxValueArray = valueArray;
            }

            Console.WriteLine($"\n\nНаибольший элемент {maxValueArray}");
            Console.WriteLine($"Измененный массив:\n\n");

            for (int i = 0; i < givenArray.GetLength(0); i++)
            {
                for (int j = 0; j < givenArray.GetLength(1); j++)
                {
                    if (givenArray[i, j] == maxValueArray)
                        givenArray[i, j] = replacementMaxValue;

                    Console.Write(givenArray[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}