using System;

public class Program
{
    static void Main(string[] args)
    {
        int[] givenArray = new int[30];

        Random random = new Random();

        int minRandomValue = 0;
        int maxRandomValue = 2;
        int maxRepeats = 0;
        int repeats = 1;
        int repeatNumber = 0;

        for (int i = 0; i < givenArray.Length; i++)
        {
            givenArray[i] = random.Next(minRandomValue, maxRandomValue + 1);
            Console.Write(givenArray[i]);
        }

        for (int i = 0; i < givenArray.Length - 1; i++)
        {
            if (givenArray[i] == givenArray[i + 1])
            {
                repeatNumber = givenArray[i];
                repeats++;

                if (repeats > maxRepeats)
                    maxRepeats = repeats;
            }
            else
            {
                repeats = 1;
            }
        }

        Console.WriteLine($"число {repeatNumber} повторяется {maxRepeats} раза подряд.");
    }
}