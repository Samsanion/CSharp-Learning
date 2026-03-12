using System;

public class Program
{
    static void Main(string[] args)
    {
        int minRandom = 10;
        int maxRandom = 25;

        int startSearchRange = 50;
        int endSearchRange = 150;

        Random random = new Random();
        int numberN = random.Next(minRandom, maxRandom + 1);

        Console.WriteLine($"Числа от {startSearchRange} до {endSearchRange} кратные {numberN}");

        for (int i = 0; i <= endSearchRange; i += numberN)
        {
            if (i >= startSearchRange)
                Console.WriteLine(i);
        }
    }
}