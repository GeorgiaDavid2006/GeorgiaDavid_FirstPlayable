using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace GeorgiaDavid_FirstPlayable
{
    internal class Program
    {
        static string[] map;

        static int horizontalInput;
        static int verticalInput;

        static int playerPosX;
        static int playerPosY;

        static int enemyPosX;
        static int enemyPosY;

        static bool isGameActive;

        static void Main(string[] args)
        {
            string path = @"Map.txt";

            map = File.ReadAllLines(path);

            DrawMap();

            DrawPlayer();
        }
        static void DrawMap()
        {
            for (int border = 0; border < map[0].Length + 2; border++)
            {
                if (border == 0 || border == map[0].Length + 1)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write("-");
                }
            }

            Console.Write("\n");

            for (int row = 0; row < map.GetLength(0); row++)
            {
                Console.Write("|");
                for (int column = 0; column < map[0].Length; column++)
                {
                    Console.Write(map[row][column]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            for (int border = 0; border < map[0].Length + 2; border++)
            {
                if (border == 0 || border == map[0].Length + 1)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();

        }

        static void DrawPlayer()
        {
            Console.SetCursorPosition(playerPosX, playerPosY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O");
        }

        static void DrawEnemy()
        {
            Console.SetCursorPosition(enemyPosX, enemyPosY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("O");
        }

        static void PlayerInput()
        {
            horizontalInput = 0;
            verticalInput = 0;

            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A) horizontalInput -= 1;

            if (inputKey.Key == ConsoleKey.D) horizontalInput += 1;

            if (inputKey.Key == ConsoleKey.W) verticalInput -= 1;

            if (inputKey.Key == ConsoleKey.S) verticalInput += 1;
        }
    }
}