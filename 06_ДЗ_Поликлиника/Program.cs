using System;

public class Program
{
    public static void Main(string[] args)
    {
        int peoplInLine;
        int timeForPatient = 10;
        int hour;
        int minute;
        int minuteInHour = 60;

        Console.Write("Cколько людей в очереди: ");
        peoplInLine = Convert.ToInt32(Console.ReadLine());

        hour = (peoplInLine * timeForPatient) / minuteInHour;
        minute = (peoplInLine * timeForPatient) % minuteInHour;

        Console.WriteLine($"Вам стоять в очереди {hour} часа и {minute} минут.");
    }
}