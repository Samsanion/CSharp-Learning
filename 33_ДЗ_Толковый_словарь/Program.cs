using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string userInput;

        bool isWork = true;

        Dictionary<string, string> explanatoryDictionary = new Dictionary<string, string>()
        {
            { "Баг", "ошибка, всплывающая в программе (англ. bug — клоп, жучок);"},
            {"Индусский код", "длинный и сложно написанный код, в котором есть лишние строки."},
            {"Падаван", "неуважительное название стажера или джуна."},
            {"Плюшки","бонусы и подарки."}
        };

        while (isWork)
        {
            string exitCommand = "1";

            OutputTableContents(explanatoryDictionary, exitCommand);

            Console.Write("Какое слово вы хотите определить: ");
            userInput = Console.ReadLine();

            if (userInput == exitCommand)
            {
                isWork = false;
            }
            else if (explanatoryDictionary.ContainsKey(userInput))
            {
                Console.WriteLine($"{userInput} - {explanatoryDictionary[userInput]}");
            }
            else
            {
                Console.WriteLine("Такого слова в словаре нет.");
            }

            Console.ReadLine();
            Console.Clear();
        }

    }

    static void OutputTableContents(Dictionary<string, string> explanatoryDictionary, string exitCommand)
    {

        Console.Clear();
        Console.SetCursorPosition(0, 4);
        Console.WriteLine("============================");

        Console.WriteLine("Слова доступные для определения: \n");

        foreach (var word in explanatoryDictionary)
        {
            Console.WriteLine(word.Key);
        }

        Console.WriteLine($"\n{exitCommand} - Выход.");

        Console.SetCursorPosition(0, 0);
    }
}