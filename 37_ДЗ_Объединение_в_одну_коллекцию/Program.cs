using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = { "1", "2", "1" };
            string[] array2 = { "3", "2" };

            List<string> rezaltList = new List<string>();

            Integration(array1, rezaltList);
            Integration(array2, rezaltList);

            OutputInformation(rezaltList);
        }

        static void Integration(string[] workingArray, List<string> rezaltList)
        {
            foreach (var itemArray in workingArray)
            {
                if (rezaltList.Contains(itemArray) == false)
                {
                    rezaltList.Add(itemArray);
                }
            }
        }

        static void OutputInformation(List<string> rezaltList)
        {
            foreach (var item in rezaltList)
            {
                Console.Write($"{item} ");
            }
        }
    }
}