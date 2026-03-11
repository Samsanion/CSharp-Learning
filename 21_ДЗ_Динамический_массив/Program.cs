using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            int[] givenArray = new int[0];

            int sum = 0;
            int numberEntered;
            string userImput;

            bool isWork = true;

            while (isWork)
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine($"\n\n------------------------------------------");
                Console.WriteLine("Введенные значения: ");

                if (givenArray.Length > 0)
                {
                    foreach (int i in givenArray)
                    {
                        Console.Write(i + " ");
                    }
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{CommandSum} -  Для суммирования всех знвчений");
                Console.WriteLine($"{CommandExit} - Для выхода");
                Console.Write("Введите число для добавления или команду: ");
                userImput = Console.ReadLine();

                switch (userImput)
                {
                    case CommandSum:
                        foreach (int i in givenArray)
                        {
                            sum += i;
                        }

                        Console.Write($"\nСумма введенных значений: {sum}");
                        sum = 0;
                        Console.ReadKey();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        if (int.TryParse(userImput, out numberEntered))
                        {
                            int[] tempArray = new int[givenArray.Length + 1];

                            for (int i = 0; i < givenArray.Length; i++)
                            {
                                tempArray[i] = givenArray[i];
                            }

                            tempArray[tempArray.Length - 1] = numberEntered;
                            givenArray = tempArray;
                        }
                        else
                        {
                            Console.WriteLine("Такой команды не существует");
                            Console.ReadKey();
                        }
                        break;
                }

                Console.Clear();
            }
        }
    }
}