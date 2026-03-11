using System;

namespace CS_Light
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiac;
            string age;
            string workPlase;
            string textAboutUser;

            Console.Write("Как Вас зовут: ");
            name = Console.ReadLine();
            Console.Write("Ваш возраст: ");
            age = Console.ReadLine();
            Console.Write("Ваш знак зодиака: ");
            zodiac = Console.ReadLine();
            Console.Write("Ваше место работы: ");
            workPlase = Console.ReadLine();

            textAboutUser = "Вас зовут " + name + " Вам " + age + ", Вы " + zodiac + " и работаете на " + workPlase + "е.";

            Console.WriteLine(textAboutUser);
        }
    }
}
