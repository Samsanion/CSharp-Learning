using System;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int product = 1;

            int lineIndex = 1;
            int columIndex = 0;

            int[,] array =
            {
             { 5, 3, 8, 1 },
             { 2, 1, 7, 9 }
             };

            Console.WriteLine($"Матрица массива: ");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[lineIndex, i];
            }

            for (int j = 0; j < array.GetLength(0); j++)
            {
                product *= array[j, columIndex];
            }

            Console.WriteLine($"\n\nСумма элементов первой строки {sum}");
            Console.WriteLine($"Произведение элементов второй строки {product}");
        }
    }
}