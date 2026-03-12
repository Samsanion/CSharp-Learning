using System;

static void Main(string[] args)
{
    int depth = 0;
    var count = 0;
    int maxDepth = 0;
    char openBracket = '(';
    char closeBracket = ')';
    Console.WriteLine($"Введите строку из символов {openBracket} и {closeBracket} ");
    string text = Console.ReadLine();

    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] == openBracket)
        {
            depth++;
        }
        else if (text[i] == closeBracket)
        {
            count++;
            depth--;
        }

        if (depth < 0)
        {
            break;
        }

        if (depth > maxDepth)
        {
            maxDepth = depth;
        }
    }

    if (depth == 0)
    {
        Console.WriteLine($"Строка корректная  {text} \n  Максимальная глубина равняется: {maxDepth}");
    }
    else
    {
        Console.WriteLine($"Ошибка! Не верная строка {text} ");
    }
}