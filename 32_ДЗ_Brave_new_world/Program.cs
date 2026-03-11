using System;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[,] map = ReadMap("map.txt");

            int pacmanX = 1;
            int pacmanY = 1;
            int score = 0;

            bool isWork = true;

            Console.CursorVisible = false;

            while (isWork)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                DrawMap(map);

                DrowSkore(map, score);

                DrowPlayer(pacmanX, pacmanY);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                int nextPacmanPositionX;
                int nextPacmanPositionY;

                char nextCell;

                CalculationNextPosition(pressedKey, pacmanX, pacmanY, map,out nextPacmanPositionX,out nextPacmanPositionY,out nextCell);

                TryCollectScore(nextCell, ref score, map, nextPacmanPositionX, nextPacmanPositionY);

                TryMove(nextCell, nextPacmanPositionX, nextPacmanPositionY, ref pacmanX, ref pacmanY);
            }
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }

        private static void DrowPlayer(int pacmanX, int pacmanY)
        {
            char player = '@';

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(pacmanX, pacmanY);
            Console.Write(player);
        }

        private static void DrowSkore(char[,] map, int score)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(map.GetLength(0) + 1, 0);
            Console.Write($"Score: {score}");
        }

        private static void CalculationNextPosition(ConsoleKeyInfo pressdKey,int pacmanX, int pacmanY, char[,] map, out int nextPacmanPositionX,out int nextPacmanPositionY, out char nextCell)
        {
            int[] direction = GetDirection(pressdKey);

            nextPacmanPositionX = pacmanX + direction[0];
            nextPacmanPositionY = pacmanY + direction[1];

            nextCell = map[nextPacmanPositionX, nextPacmanPositionY];

        }

        private static void TryMove(char nextCell, int nextPacmanPositionX, int nextPacmanPositionY, ref int pacmanX, ref int pacmanY)
        {
            char wall = '#';

            if (nextCell != wall)
            {
                pacmanX = nextPacmanPositionX;
                pacmanY = nextPacmanPositionY;
            }
        }

        private static void TryCollectScore(char nextCell, ref int score, char[,] map, int nextPacmanPositionX, int nextPacmanPositionY)
        {
            char scoreItem = '.';

            if (nextCell == scoreItem)
            {
                score++;
                map[nextPacmanPositionX, nextPacmanPositionY] = ' ';
            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressdKey)
        {
            int[] direction = { 0, 0 };

            if (pressdKey.Key == ConsoleKey.UpArrow)
                direction[1] = -1;
            else if (pressdKey.Key == ConsoleKey.DownArrow)
                direction[1] = +1;
            else if (pressdKey.Key == ConsoleKey.LeftArrow)
                direction[0] = -1;
            else if (pressdKey.Key == ConsoleKey.RightArrow)
                direction[0] = +1;

            return direction;
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }
    }
}