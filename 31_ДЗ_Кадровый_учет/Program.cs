using System;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandOutputAllDossiers = "2";
            const string CommandRemoveDossier = "3";
            const string CommandSearchLastName = "4";
            const string CommandExit = "5";

            const string Separator = "\n=========================";

            string[] fullNames = { "Петров Петр Петрович", "1 1 1", "1 1 1", "Петров Иван Сергеевич" };
            string[] jobTitles = { "Директор", "Уборщик", "Менеджер", "Уборщик" };

            string userImput;

            bool isWorks = true;

            while (isWorks)
            {
                Console.WriteLine("Добро пожаловать в сеть архива \"РОБКО Индастриз (ТМ)\"");
                Console.WriteLine("Интерфейс центрально компютера\n");
                Console.WriteLine($"{CommandAddDossier} - [Добавить досье]");
                Console.WriteLine($"{CommandOutputAllDossiers} - [Вывести все досье]");
                Console.WriteLine($"{CommandRemoveDossier} - [Удалить досье]");
                Console.WriteLine($"{CommandSearchLastName} - [Поиск по фамилии]");
                Console.WriteLine($"{CommandExit} - [Выход]");

                Console.WriteLine(Separator);

                Console.Write("Ввод: ");
                userImput = Console.ReadLine();

                switch (userImput)
                {
                    case CommandAddDossier:
                        AddDossier(ref fullNames, ref jobTitles);
                        break;

                    case CommandOutputAllDossiers:
                        OutputAllDossiers(fullNames, jobTitles);
                        break;

                    case CommandRemoveDossier:
                        RemoveDossier(ref fullNames, ref jobTitles);
                        break;

                    case CommandSearchLastName:
                        SearchLastName(fullNames);
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
        static void AddDossier(ref string[] fullNames, ref string[] jobTitles)
        {
            Console.Clear();

            fullNames = AddArrayElement(fullNames, "Фамилию Имя Отчество");
            jobTitles = AddArrayElement(jobTitles, "Должность");

            Console.Clear();
            Console.WriteLine("Сотрудник добавлен.");

            ShowPauseScreen();

        }

        static void OutputAllDossiers(string[] fullNames, string[] jobTitles)
        {
            Console.Clear();

            for (int i = 0; i < jobTitles.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {fullNames[i]} - {jobTitles[i]}");
            }

            ShowPauseScreen();
        }

        static void RemoveDossier(ref string[] fullNames, ref string[] jobTitles)
        {
            Console.Clear();

            bool isWork = true;
            string userImput = "";
            int removeElement = 0;

            while (isWork)
            {
                Console.Write("Введите номер досье, которое хотите удалить: ");
                userImput = Console.ReadLine();

                if (int.TryParse(userImput, out removeElement) && (removeElement > 0 && removeElement <= fullNames.Length))
                {
                    removeElement -= 1;

                    fullNames = DeleteElementArray(fullNames, removeElement);
                    jobTitles = DeleteElementArray(jobTitles, removeElement);

                    Console.Clear();
                    Console.WriteLine("Сотрудник удален.");

                    isWork = false;

                    ShowPauseScreen();
                }
                else
                {
                    Console.WriteLine($"Введите чило от 1 до {fullNames.Length}");

                    ShowPauseScreen();
                }
            }
        }

        static void SearchLastName(string[] fullNames)
        {
            string searchSurname;
            string[] fullName = { };
            bool isFound = false;

            Console.Clear();

            Console.Write("Фамилия для поиска: ");
            searchSurname = Console.ReadLine();

            foreach (string name in fullNames)
            {
                fullName = name.Split(' ');

                if (string.Equals(fullName[0], searchSurname, StringComparison.OrdinalIgnoreCase))
                {
                    isFound = true;
                    Console.WriteLine(name);
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Сотрудников с такой фамилией не найдено.");
            }

            ShowPauseScreen();
        }

        static string[] AddArrayElement(string[] paddedArray, string reqest = "")
        {
            string[] temporaryArray = new string[paddedArray.Length + 1];

            for (int i = 0; i < paddedArray.Length; i++)
            {
                temporaryArray[i] = paddedArray[i];
            }

            Console.Write($"Введите {reqest} сотрудника: ");
            temporaryArray[temporaryArray.Length - 1] = Console.ReadLine();

            return temporaryArray;
        }

        static string[] DeleteElementArray(string[] mutableArray, int deliteIndex)
        {
            string[] temporaryArray = new string[mutableArray.Length - 1];

            for (int i = 0; i < deliteIndex; i++)
            {
                temporaryArray[i] = mutableArray[i];
            }

            for (int i = deliteIndex + 1; i < mutableArray.Length; i++)
            {
                temporaryArray[i - 1] = mutableArray[i];
            }

            return temporaryArray;
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