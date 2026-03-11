using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userPassword = "123";
            string userImput;
            int countAttemts = 3;

            for (int i = 1; i <= countAttemts; i++)
            {
                Console.Write("Введите пароль: ");
                userImput = Console.ReadLine();

                if (userImput == userPassword)
                {
                    Console.WriteLine("Top Sicret");
                    break;
                }
                else
                {
                    Console.WriteLine($"Вы использовали {i} из {countAttemts} попыток.");
                }
            }
        }
    }
}