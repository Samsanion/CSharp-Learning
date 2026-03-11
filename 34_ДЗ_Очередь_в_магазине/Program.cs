using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int cashRegistr = 0;

        Queue<int> queue = new Queue<int>();

        FillingQueue(ref queue);

        while (queue.Count > 0)
        {
            Console.WriteLine($"Получено: {queue.Peek()} руб.");
            cashRegistr += queue.Dequeue();

            Console.SetCursorPosition(0, 3);
            Console.WriteLine("===================");
            Console.WriteLine($"В кассе {cashRegistr} рублей.");
            Console.SetCursorPosition(0, 0);

            Console.ReadLine();
            Console.Clear();
        }
    }

    private static void FillingQueue(ref Queue<int> queue)
    {
        int minRandom = 1;
        int maxRandom = 1001;

        int queueLength = 10;

        Random purchaseAmount = new Random();

        for (int i = queueLength; i > 0; i--)
        {
            queue.Enqueue(purchaseAmount.Next(minRandom, maxRandom));
        }
    }
}