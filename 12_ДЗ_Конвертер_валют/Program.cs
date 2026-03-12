using System;

public class Program
{
    static void Main(string[] args)
    {
        const string CommandConvertRubToUsd = "1";
        const string CommandConvertRubToEur = "2";
        const string CommandConvertEurToUsd = "3";
        const string CommandConvertEurToRub = "4";
        const string CommandConvertUsdToRub = "5";
        const string CommdndConvertUsdToEur = "6";
        const string CommandShouBalace = "7";
        const string CommandClearConsol = "8";
        const string CommandExit = "9";

        double convertRubToUsd = 0.013;
        double convertRubToEur = 0.011;
        double convertEurToUsd = 1.16;
        double convertEurToRub = 91.43;
        double convertUsdDToRub = 78.52;
        double convertUsdToEur = 0.86;

        double balsnceRub = 1000;
        double balsnceEur = 150;
        double balsnceUsd = 400;

        int userImputAmoutCurrency;
        string userInput;

        bool isWork = true;

        while (isWork)
        {
            Console.WriteLine("Выберите команду для обмена валют:");
            Console.WriteLine($"{CommandConvertRubToUsd} Обменять рубли на доллары");
            Console.WriteLine($"{CommandConvertRubToEur} Обменять рубли на евро");
            Console.WriteLine($"{CommandConvertEurToUsd} Обменять евро на доллары");
            Console.WriteLine($"{CommandConvertEurToRub} Обменять евро на рубли");
            Console.WriteLine($"{CommandConvertUsdToRub} Обменять доллары на рубли");
            Console.WriteLine($"{CommdndConvertUsdToEur} Обменять доллары на евро");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{CommandShouBalace} Показать баланс");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{CommandClearConsol} Очистить консоль");
            Console.WriteLine($"{CommandExit} Выход\n");

            Console.Write("Ваш выбор: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandConvertRubToUsd:
                    Console.Write("Введите сумму которую хотите обменять: ");
                    userImputAmoutCurrency = Convert.ToInt32(Console.ReadLine());

                    if (balsnceRub > userImputAmoutCurrency)
                    {
                        balsnceUsd += userImputAmoutCurrency * convertRubToUsd;
                        balsnceRub -= userImputAmoutCurrency;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Нажмите клавишу для продолжения..");
                        Console.ReadKey();
                        break;
                    }

                case CommandConvertRubToEur:
                    Console.Write("Введите сумму которую хотите обменять: ");
                    userImputAmoutCurrency = Convert.ToInt32(Console.ReadLine());
                    if (balsnceRub > userImputAmoutCurrency)
                    {
                        balsnceEur += userImputAmoutCurrency * convertRubToEur;
                        balsnceRub -= userImputAmoutCurrency;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Нажмите клавишу для продолжения..");
                        Console.ReadKey();
                        break;
                    }

                case CommandConvertEurToUsd:
                    Console.Write("Введите сумму которую хотите обменять: ");
                    userImputAmoutCurrency = Convert.ToInt32(Console.ReadLine());
                    if (balsnceEur > userImputAmoutCurrency)
                    {
                        balsnceUsd += userImputAmoutCurrency * convertEurToUsd;
                        balsnceEur -= userImputAmoutCurrency;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Нажмите клавишу для продолжения..");
                        Console.ReadKey();
                        break;
                    }

                case CommandConvertEurToRub:
                    Console.Write("Введите сумму которую хотите обменять: ");
                    userImputAmoutCurrency = Convert.ToInt32(Console.ReadLine());
                    if (balsnceEur > userImputAmoutCurrency)
                    {
                        balsnceRub += userImputAmoutCurrency * convertEurToRub;
                        balsnceEur -= userImputAmoutCurrency;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Нажмите клавишу для продолжения..");
                        Console.ReadKey();
                        break;
                    }

                case CommandConvertUsdToRub:
                    Console.Write("Введите сумму которую хотите обменять: ");
                    userImputAmoutCurrency = Convert.ToInt32(Console.ReadLine());
                    if (balsnceUsd > userImputAmoutCurrency)
                    {
                        balsnceRub += userImputAmoutCurrency * convertUsdDToRub;
                        balsnceUsd -= userImputAmoutCurrency;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Нажмите клавишу для продолжения..");
                        Console.ReadKey();
                        break;
                    }

                case CommdndConvertUsdToEur:
                    Console.Write("Введите сумму которую хотите обменять: ");
                    userImputAmoutCurrency = Convert.ToInt32(Console.ReadLine());
                    if (balsnceUsd > userImputAmoutCurrency)
                    {
                        balsnceEur += userImputAmoutCurrency * convertUsdToEur;
                        balsnceUsd -= userImputAmoutCurrency;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств. Нажмите клавишу для продолжения..");
                        Console.ReadKey();
                        break;
                    }

                case CommandShouBalace:
                    Console.WriteLine($"Баланс в рублях: {balsnceRub}");
                    Console.WriteLine($"Баланс в евро: {balsnceEur}");
                    Console.WriteLine($"Баланс в долларах: {balsnceUsd}");
                    Console.WriteLine("Нажмите клавишу для продолжения..");
                    Console.ReadKey();
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