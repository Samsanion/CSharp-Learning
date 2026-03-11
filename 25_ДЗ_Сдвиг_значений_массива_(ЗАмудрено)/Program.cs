using System;
using System.Security.Policy;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userString = 1;
            int temp = 0;
            int tempZero = 0;

            int[] givenArray = new int[] { 1, 2, 3 };

            Console.WriteLine("Насколько позиций сдвинуть массив");
            //userString = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userString; i++)
            {
                for (int j = 0; j < givenArray.Length; j++)
                {
                    if (j == 0)
                    {
                        tempZero = givenArray[0];
                        givenArray[j] = givenArray[j + 1];
                    }
                    else if (j < givenArray.Length - 1)
                    {
                        temp = givenArray[j];
                        givenArray[j] = givenArray[j + 1];
                        givenArray[j + 1] = temp;
                    }
                    else if (j == givenArray.Length - 1)
                    {
                        givenArray[j] = tempZero;
                    }
                }
            }

            foreach (var item in givenArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}