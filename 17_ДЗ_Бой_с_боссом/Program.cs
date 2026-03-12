using System;

public class Program
{
    static void Main(string[] args)
    {
        const string CommandAttack = "1";
        const string CommandFireBall = "2";
        const string CommandExplosion = "3";
        const string CommandHeal = "4";

        const int HiroManna = 50;
        const int HiroHealth = 100;

        int minRandomBossAttack = 20;
        int maxRandomBossAttack = 50;
        Random random = new Random();

        int bossHealth = 300;
        int bossAttack = random.Next(minRandomBossAttack, maxRandomBossAttack);

        int heroHealth = HiroHealth;
        int heroManna = HiroManna;
        int heroMannaRegen = 10;

        int heroAttack = 10;
        int damageHeroFireBall = 30;
        int fireBallManna = 20;
        int damageHeroExplosion = 50;
        int heroHeal = 50;
        int amauntHeals = 4;

        bool wasShotBall = false;
        string userInput;

        Console.WriteLine("Перед Вами босс..");
        Console.WriteLine($"Его Здоровье {bossHealth}\nЕго атака {bossAttack}");

        while (bossHealth > 0 && heroHealth > 0)
        {
            Console.WriteLine($"Здоровье Босса {bossHealth}");
            Console.WriteLine($"Твое Здоровье {heroHealth}");

            Console.WriteLine("------------------------------------");

            Console.WriteLine("Ваши умения: ");
            Console.WriteLine($"{CommandAttack} - Обычная Атака");
            Console.WriteLine($"{CommandFireBall} - Огненный шар");
            Console.WriteLine($"{CommandExplosion} - Взрыв");
            Console.WriteLine($"{CommandHeal} - Хилл");
            Console.Write("\nВаше действие: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandAttack:
                    bossHealth -= heroAttack;

                    if (heroManna < HiroManna)
                        heroManna += heroMannaRegen;
                    break;

                case CommandFireBall:
                    bossHealth -= damageHeroFireBall;
                    heroManna -= fireBallManna;
                    wasShotBall = true;
                    break;

                case CommandExplosion:

                    if (wasShotBall)
                    {
                        bossHealth -= damageHeroExplosion;
                        wasShotBall = false;
                    }
                    else
                    {
                        Console.Write("Вы забыли кинуть Огненный шар..");
                        break;
                    }

                    break;

                case CommandHeal:
                    heroManna += heroMannaRegen;
                    amauntHeals--;

                    if (amauntHeals == 0)
                        break;
                    else if (heroHealth + heroHeal > HiroHealth)
                        heroHealth = heroHeal;
                    else
                        heroHealth += heroHeal;
                    break;

                default:
                    Console.Write("Вы ошиблись, ");
                    break;
            }

            Console.WriteLine("Атака Босса!!\n\n");
            heroHealth -= bossAttack;
        }

        if (bossHealth <= 0 && heroHealth <= 0)
            Console.WriteLine("Вы победили, но какой ценой");
        else if (bossHealth <= 0)
            Console.WriteLine("Чудище убито");
        else if (heroHealth <= 0)
            Console.WriteLine("Вы убиты..");
    }
}