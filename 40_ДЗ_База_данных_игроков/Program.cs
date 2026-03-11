using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Program
{
    static void Main(string[] args)
    {
        const string CommandAddPlayer = "1";
        const string CommandBanPlayer = "2";
        const string CommandUnbanPlayer = "3";
        const string CommandRemovePlayer = "4";
        const string CommandExit = "5";

        string userImput;

        bool isWork = true;

        Database playerDatabase = new Database();

        while (isWork)
        {
            Console.Write("Добавить игрока - {0}\nЗабанить - {1}\nРазбанить - {2}\nУдалить - {3}\nВыход - {4}\nВвод: ",
                            CommandAddPlayer, CommandBanPlayer, CommandUnbanPlayer, CommandRemovePlayer, CommandExit);
            userImput = Console.ReadLine();

            switch (userImput)
            {
                case CommandAddPlayer:
                    playerDatabase.AddPlayer();
                    break;
                case CommandBanPlayer:
                    playerDatabase.BanPlayer();
                    break;
                case CommandUnbanPlayer:
                    playerDatabase.UnbanPlayer();
                    break;
                case CommandRemovePlayer:
                    playerDatabase.RemovePlayer();
                    break;
                case CommandExit:
                    isWork = false;
                    break;
                default:
                    break;
            }
        }
    }

    class Database
    {
        public Dictionary<int, Player> Players = new Dictionary<int, Player>();

        public void AddPlayer()
        {
            string userImput;

            Console.Clear();

            Console.Write("Введите имя Игрока: ");
            userImput = Console.ReadLine();

            Player temporaryObjekt = new Player(userImput);

            Players.Add(temporaryObjekt.GetIndentifier(), temporaryObjekt);
        }

        public void BanPlayer()
        {
            EnterID(out int playerID);

            if (playerID >= 0)
            {
            Players[playerID].BanPlayer();

            OutputExecutionMessage("забанен", playerID);
            }
            else
            {
                OutputErrorMessage("Блокировка");
            }
        }

        public void UnbanPlayer()
        {
            EnterID(out int playerID);

            if (playerID >= 0)
            {
            Players[playerID].UnbanPlayer();

            OutputExecutionMessage("разбанен", playerID);
            }
            else
            {
                OutputErrorMessage("Разблакировка");
            }
        }

        public void RemovePlayer()
        {
            EnterID(out int playerID);

            if (playerID >= 0)
            {
                Players.Remove(playerID);

                OutputExecutionMessage("удален", playerID);
            }
            else
            {
                OutputErrorMessage("Удаление");
            }
        }

        private void EnterID(out int playerID)
        {
            string userImput;

            Console.Write("Введите уникальный ID: ");
            userImput = Console.ReadLine();

            if (int.TryParse(userImput, out playerID) == false)
            {
                Console.WriteLine("Ади неверен!!");
                playerID = -1;
            }
        }

        private void OutputExecutionMessage(string action, int playerID) => Console.WriteLine("Игрок {0} {1}", playerID, action);

        private void OutputErrorMessage(string action) => Console.WriteLine($"{action} не выполнено!!");
    }

    class Player
    {
        public int Indentifier { get; private set; }
        public string Name { get; set; }
        public int Level { get; private set; }
        public bool IsBan { get; private set; }

        private static int _indentifier = 0;

        public Player(string name, int level = 0)
        {
            _indentifier++;
            Indentifier = _indentifier;
            Name = name;
            Level = level;
        }

        public int GetIndentifier()
        {
            return _indentifier;
        }

        public void BanPlayer()
        {
            IsBan = true;
        }

        public void UnbanPlayer()
        {
            IsBan = false;
        }
    }
}
