using System;

public class StringSwap
{
    public static void Main(string[] args)
    {
        int gold;
        int critalPrise = 10;
        int cristals;

        Console.WriteLine($"Добро пожаловать в кристалШоп. Мы продаем кристалы за {critalPrise} монет/т.");

        Console.Write("Сколько у Вас зхолота: ");
        gold = Convert.ToInt32(Console.ReadLine());
        Console.Write("Сколько кристалов Вы покупаете: ");
        cristals = Convert.ToInt32(Console.ReadLine());

        gold -= cristals * critalPrise;

        Console.WriteLine($"Вы купили {cristals}, осталось {gold} золота.");
    }
}