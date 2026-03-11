using System;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int Size = 5;

            int numberOfShifts = 0;
            int temp = 0;

            int[] givenArray = new int[Size] { 1, 2, 3, 4, 5 };

            Console.Write("Исходный массив: ");
            foreach (var item in givenArray)
            {
                Console.Write(item + " ");
            }

            Console.Write("\n\nНасколько позиций сдвинуть массив: ");
            numberOfShifts = Convert.ToInt32(Console.ReadLine()) % givenArray.Length;

            for (int i = 0; i < numberOfShifts; i++)
            {
                for (int j = 0; j < Size - 1; j++)
                {
                    temp = givenArray[j];
                    givenArray[j] = givenArray[j + 1];
                    givenArray[(j + 1)] = temp;
                }
            }

            Console.Write("\nИзмененный массив: ");
            foreach (var item in givenArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}