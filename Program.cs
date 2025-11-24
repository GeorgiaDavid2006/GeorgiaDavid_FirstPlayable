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

        static int playerPosX = 1;
        static int playerPosY = 1;

        static int oldPlayerPosX;
        static int oldPlayerPosY;

        static int enemyPosX = 10;
        static int enemyPosY = 1;

        static int playerHealth = 5;
        static int enemyHealth = 5;

        static bool isGameActive = true;

        static void Main(string[] args)
        {
            string path = @"Map.txt";

            map = File.ReadAllLines(path);

            DrawMap();
            DrawPlayer();
            DrawEnemy();

            while (isGameActive == true)
            {
                PlayerInput();
                DrawPlayer();
                DrawEnemy();
            }
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
                    Console.Write("═");
                }
            }

            Console.Write("\n");

            for (int row = 0; row < map.GetLength(0); row++)
            {
                Console.Write("║");
                for (int column = 0; column < map[0].Length; column++)
                {
                    Console.Write(map[row][column]);
                }
                Console.Write("║");
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
                    Console.Write("═");
                }
            }
            Console.WriteLine();

        }
        static void RestoreTile()
        {

        }

        static void DrawPlayer()
        {
            Console.CursorVisible = false;
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
            oldPlayerPosX = playerPosX;
            oldPlayerPosY = playerPosY;

            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A) playerPosX -= 1;

            if (inputKey.Key == ConsoleKey.D) playerPosX += 1;

            if (inputKey.Key == ConsoleKey.W) playerPosY -= 1;

            if (inputKey.Key == ConsoleKey.S) playerPosY += 1;

            if(playerPosX <= 1)
            {
                playerPosX = 1;
            }

            if (playerPosY <= 1)
            {
                playerPosY = 1;
            }

            if (playerPosX >= 30)
            {
                playerPosX = 30;
            }

            if (playerPosY >= 12)
            {
                playerPosY = 12;
            }
        }

        static void ShowHUD()
        {
            Console.WriteLine("Player Health: " + playerHealth);
            Console.WriteLine("Enemy Health: " + enemyHealth);
        }

        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
        }
    }
}