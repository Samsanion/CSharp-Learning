using System;

public class Program
{
    public static void Main(string[] args)
    {
        string name = "Черджиев";
        string surname = "Дмитрий";

        Console.WriteLine($"До: {surname} {name}");

        name = name + surname;
        surname = name.Substring(0, name.Length - surname.Length);
        name = name.Substring(surname.Length);

        Console.WriteLine($"После: {surname} {name}");
    }
}