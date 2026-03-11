using System;
using System.Xml.Schema;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[15];
            int randomMax = 10;
            int randomMin = 0;

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(randomMin, randomMax + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\n\n");

            ShuffleArray(array);
        }

        static void ShuffleArray(int[] array)
        {
            int shaffeldElement;
            int randomIndex;
            Random random = new Random();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                randomIndex = random.Next(i);
                shaffeldElement = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = shaffeldElement;
            }

            foreach (var i in array)
            {
                Console.Write(i + " ");
            }
        }
    }
}