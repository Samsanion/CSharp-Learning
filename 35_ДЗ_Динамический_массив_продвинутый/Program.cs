using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "s";
            const string CommandExit = "e";

            List<int> givenList = new List<int>();

            string userImput;

            bool isWork = true;

            while (isWork)
            {
                ListOutput(givenList);

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{CommandSum} -  Для суммирования всех знвчений");
                Console.WriteLine($"{CommandExit} - Для выхода");
                Console.Write("Введите число для добавления или команду: ");
                userImput = Console.ReadLine();

                switch (userImput)
                {
                    case CommandSum:
                        SummationElementsList(givenList);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        ImputProcessing(givenList, userImput);
                        break;
                }

                Console.Clear();
            }
        }

        private static void ListOutput(List <int> givenList)
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"\n\n------------------------------------------");
            Console.WriteLine("Введенные значения: ");

            foreach (int i in givenList)
            {
                Console.Write(i + " ");
            }
        }

        private static void SummationElementsList(List<int> givenList)
        {
            int sum = 0;

            foreach (int term in givenList)
            {
                sum += term;
            }

            givenList.Clear();

            Console.Write($"\nСумма введенных значений: {sum}");

            Console.ReadKey();
        }

        private static void ImputProcessing (List <int> givenList,string userImput)
        {
            int numberEntered;

            if (int.TryParse(userImput, out numberEntered))
            {
                givenList.Add(numberEntered);
            }
            else
            {
                Console.WriteLine("Такой команды не существует");
                Console.ReadKey();
            }
        }
    }
}