using System;

public class Program
{
    static void Main(string[] args)
    {
        int[] givenArray = new int[10];

        Random random = new Random();

        int minRandomValue = 0;
        int maxRandomValue = 30;
        int temp;

        for (int i = 0; i < givenArray.Length; i++)
        {
            givenArray[i] = random.Next(minRandomValue, maxRandomValue + 1);
            Console.Write(givenArray[i] + " ");
        }

        for (int i = 0; i < givenArray.Length; i++)
        {
            for (int j = 0; j < givenArray.Length; j++)
            {
                if (givenArray[j] > givenArray[i])
                {
                    temp = givenArray[i];
                    givenArray[i] = givenArray[j];
                    givenArray[j] = temp;
                }
            }
        }

        Console.WriteLine();

        for (int i = 0; i < givenArray.Length; i++)
        {
            Console.Write(givenArray[i] + " ");
        }
    }
}