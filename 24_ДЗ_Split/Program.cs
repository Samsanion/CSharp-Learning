using System;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userString;
            char[] separators = new char[] { ' ', '.', ',', '!', '?','-','(',')','"'};

            Console.WriteLine("Введите свой декст для разбития:");
            userString = Console.ReadLine();

            string[] subs = userString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sub in subs)
            {
                Console.WriteLine($"Substring: {sub}");
            }
        }
    }
}