using System;

public class Program
{
    static void Main(string[] args)
    {
        int picturesInRow = 3;
        int picturesInAlboum = 52;
        int fullRow;
        int restPictures;

        fullRow = picturesInAlboum / picturesInRow;
        restPictures = picturesInAlboum % picturesInRow;

        Console.WriteLine($"Выведется {fullRow} рядов, не влезло {restPictures} иображений");
    }
}