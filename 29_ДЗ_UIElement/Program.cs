using System;
using System.Xml.Schema;

public class Program
{
    static void Main(string[] args)
    {
        const double FullPercent = 100;

        int imputHealthPercent = 40;
        int imputMannaPercent = 30;

        int maxHealth = 10;
        int maxManna = 10;

        double healthPercent = imputHealthPercent / FullPercent;
        double mannaPercent = imputMannaPercent / FullPercent;

        DrawStatusBar(healthPercent, maxHealth, ConsoleColor.DarkGreen, 0);
        DrawStatusBar(mannaPercent, maxManna, ConsoleColor.DarkBlue, 1, '*');
    }

    static void DrawStatusBar(double percentageFilling, int length, ConsoleColor color, int position,
        char filledPart = '#', char spentPart = '_')
    {
        int renderDivider = Convert.ToInt32(length * percentageFilling);

        ConsoleColor defaultColor = Console.BackgroundColor;

        Console.SetCursorPosition(0, position);
        Console.Write('[');
        Console.BackgroundColor = color;
        Console.Write(FillBarStatus(0, renderDivider, filledPart));
        Console.BackgroundColor = defaultColor;

        Console.Write(FillBarStatus(renderDivider, length, spentPart) + ']');
    }

    static string FillBarStatus(int startDrowing, int endDrowing, char symbol)
    {
        string bar = "";

        for (int i = startDrowing; i < endDrowing; i++)
        {
            bar += symbol;
        }

        return bar;
    }
}