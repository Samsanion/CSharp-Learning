using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowText1 = "1";
            const string CommandShowText2 = "2";
            const string CommandRandomNumber = "3";
            const string CommandClearConsol = "4";
            const string CommandExit = "5";

            Random random = new Random();
            int randomNumber;

            bool isWork = true;
            string userInput;

            while (isWork)
            {
                Console.WriteLine($"{CommandShowText1} Показать текст 1");
                Console.WriteLine($"{CommandShowText2} Показать текст 2");
                Console.WriteLine($"{CommandRandomNumber} Вывести рандомное число");
                Console.WriteLine($"{CommandClearConsol} Очистить консоль");
                Console.WriteLine($"{CommandExit} Выход");

                Console.Write("Ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowText1:
                        Console.WriteLine("Текст 1");
                        break;

                    case CommandShowText2:
                        Console.WriteLine("Текст 2");
                        break;

                    case CommandRandomNumber:
                        randomNumber = random.Next();
                        Console.WriteLine($"Ваше рандомное число {randomNumber}");
                        break;

                    case CommandClearConsol:
                        Console.Clear();
                        break;

                    case CommandExit:
                        isWork = false;
                        Console.WriteLine("Программа завершена.");
                        break;

                    default:
                        Console.WriteLine("Такой Команды нет.");
                        break;
                }
            }
        }
    }
}