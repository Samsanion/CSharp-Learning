using System;

public class Program
{
    static void Main(string[] args)
    {
        int[] givenArray = new int[10];

        Random random = new Random();

        int minRandomValue = 0;
        int maxRandomValue = 10;
        int indexLastElementArray = givenArray.Length - 1;
        for (int i = 0; i < givenArray.Length; i++)
        {
            givenArray[i] = random.Next(minRandomValue, maxRandomValue);
            Console.Write(givenArray[i] + " ");
        }

        Console.WriteLine("\n\n");

        if (givenArray[0] > givenArray[1])
            Console.Write("" + givenArray[0] + " ");

        for (int i = 1; i < givenArray.Length - 1; i++)
        {
            if (givenArray[i] > givenArray[i - 1] && givenArray[i] > givenArray[i + 1])
                Console.Write(givenArray[i] + " ");
        }

        if (givenArray[givenArray.Length - 1] > givenArray[indexLastElementArray - 1])
            Console.Write(givenArray[givenArray.Length - 1]);
    }
}