using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandOutputAllDossiers = "2";
            const string CommandRemoveDossier = "3";
            const string CommandExit = "4";

            const string Separator = "\n=========================";

            Dictionary<string, List<string>> jobTitles = new Dictionary<string, List<string>>();

            string userImput;

            bool isWorks = true;

            while (isWorks)
            {
                Console.WriteLine("Добро пожаловать в сеть архива \"РОБКО Индастриз (ТМ)\"");
                Console.WriteLine("Интерфейс центрально компютера\n");
                Console.WriteLine($"{CommandAddDossier} - [Добавить досье]");
                Console.WriteLine($"{CommandOutputAllDossiers} - [Вывести все досье]");
                Console.WriteLine($"{CommandRemoveDossier} - [Удалить досье]");
                Console.WriteLine($"{CommandExit} - [Выход]");

                Console.WriteLine(Separator);

                Console.Write("Ввод: ");
                userImput = Console.ReadLine();

                switch (userImput)
                {
                    case CommandAddDossier:
                        AddDossier(jobTitles);
                        break;

                    case CommandOutputAllDossiers:
                        OutputAllDossiers(jobTitles);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier(jobTitles);
                        break;

                    case CommandExit:
                        isWorks = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("[Ошибка повторите ввод]");
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, List<string>> jobTitles)
        {
            string userInput;

            Console.Clear();

            Console.Write("Введите должность сотрудника: ");
            userInput = Console.ReadLine();

            if (jobTitles.ContainsKey(userInput) == false)
            {
                jobTitles.Add(userInput, new List<string>());
            }

            AddNameEmploee(jobTitles, userInput);

            Console.Clear();
            Console.WriteLine("Сотрудник добавлен.");

            ShowPauseScreen();
        }

        static void AddNameEmploee(Dictionary<string, List<string>> jobTitles, string userInput)
        {
            string userInputFullName;

            Console.Write("Введите ФИО сотрудника: ");
            userInputFullName = Console.ReadLine();

            jobTitles[userInput].Add(userInputFullName);
        }

        static void OutputAllDossiers(Dictionary<string, List<string>> jobTitles)
        {
            Console.Clear();

            foreach (var staff in jobTitles)
            {
                Console.WriteLine($"{staff.Key}:");

                foreach (var fullName in staff.Value)
                {
                    Console.WriteLine($"  {fullName}");
                }
            }

            ShowPauseScreen();
        }

        static void OutputJobTitleDossiers(Dictionary<string, List<string>> jobTitles, string jobTitle)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 2);

            List<string> workers = jobTitles[jobTitle];

            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"  {i + 1} {workers[i]}");
            }

            Console.SetCursorPosition(0, 0);
        }

        static void RemoveDossier(Dictionary<string, List<string>> jobTitles)
        {
            string jobTitle;
            string userImput;
            int removeElement;

            bool isWork = true;

            List<string> workList;

            Console.Clear();

            Console.Write("Введите должность сотрудника для удаления: ");
            jobTitle = Console.ReadLine();

            if (jobTitles.ContainsKey(jobTitle))
            {
                workList = jobTitles[jobTitle];

                while (isWork)
                {
                    OutputJobTitleDossiers(jobTitles, jobTitle);

                    Console.Write("Введите айди сотрудника для удаления: ");
                    userImput = Console.ReadLine();

                    if (int.TryParse(userImput, out removeElement) && (removeElement > 0 && removeElement <= workList.Count))
                    {
                        removeElement -= 1;

                        workList.RemoveAt(removeElement);

                        if (workList.Count == 0)
                        {
                            jobTitles.Remove(jobTitle);
                        }

                        Console.Clear();
                        Console.WriteLine("Сотрудник удален.");

                        isWork = false;
                    }
                    else
                    {
                        Console.WriteLine($"Введите чило от 1 до {workList.Count}");

                        ShowPauseScreen();
                    }
                }
            }
            else
            {
                Console.WriteLine("Должность не найдена.");
            }

            ShowPauseScreen();
        }

        static void ShowPauseScreen()
        {
            const string Separator = "\n=========================";

            Console.CursorVisible = false;

            Console.WriteLine(Separator);
            Console.Write("Нажмите любую кнопку для прордолжения.");
            Console.ReadLine();

            Console.CursorVisible = true;
            Console.Clear();
        }
    }
}