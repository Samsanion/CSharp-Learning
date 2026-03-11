using System;

public class Program
{
    static void Main(string[] args)
    {
        Player player = new Player('@', 5, 5);

        Renderer.Drow(player);

        Console.ReadKey(true);
    }
}

public class Player
{
    public Player(char simbol, int positionX,int positionY)
    {
        Simbol = simbol;
        PositionX = positionX - 1;
        PositionY = positionY - 1;
    }

    public char Simbol { get; private set;}
    public int PositionX { get; private set;}
    public int PositionY { get; private set;}
}

public class Renderer
{
    public static void Drow (Player player)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(player.PositionX, player.PositionY);
        Console.Write(player.Simbol);
    }
} 