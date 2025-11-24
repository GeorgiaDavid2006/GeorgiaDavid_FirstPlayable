using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        static List<(int, int)> goldPositions = new List<(int, int)>();

        static int gold;

        static int minGoldPosX = 1;
        static int maxGoldPosX = 30;

        static int minGoldPosY = 1;
        static int maxGoldPosY = 12;

        static int enemyPosX = 30;
        static int enemyPosY = 1;

        static int playerHealth = 5;
        static int enemyHealth = 5;

        static bool isGameActive = true;
        static bool isEnemyAlive = true;
        static Random randomPos = new Random();

        static void Main(string[] args)
        {
            string path = @"Map.txt";

            map = File.ReadAllLines(path);

            DrawMap();
            ShowHUD();
            DrawPlayer();
            DrawEnemy();
            SpawnGold(5);

            while (isGameActive == true && isEnemyAlive == true)
            {
                Console.SetCursorPosition(0, 0);
                PlayerInput();
                DrawMap();
                ShowHUD();
                DrawPlayer();
                DrawEnemy();
                DrawGold();
                Thread.Sleep(100);
            }

            while (isGameActive == true && isEnemyAlive == false)
            {
                Console.SetCursorPosition(0, 0);
                PlayerInput();
                DrawMap();
                ShowHUD();
                DrawPlayer();
                DrawGold();
                Thread.Sleep(100);
            }

            if (isGameActive == false)
            {
                GameOver();
            }
        }
        static void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.White;

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

            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A) playerPosX -= 1;
            

            if (inputKey.Key == ConsoleKey.D) playerPosX += 1;
            

            if (inputKey.Key == ConsoleKey.W) playerPosY -= 1;
            

            if (inputKey.Key == ConsoleKey.S) playerPosY += 1;
            

            if (playerPosX <= 1)
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

            if(playerPosX == enemyPosX && playerPosY == enemyPosY && isEnemyAlive)
            {
                enemyHealth = enemyHealth - 1;
                enemyPosX = 30;
                enemyPosY = 1;
            }

            if(enemyHealth <= 0)
            {
                isEnemyAlive = false;
            }
            else
            {
                MoveTowardsPlayer();
            }
        }

        static void MoveTowardsPlayer()
        {
            if(enemyPosX < playerPosX)
            {
                enemyPosX += 1;
            }

            else if (enemyPosX > playerPosX)
            {
                enemyPosX -= 1;
            }

            else if (enemyPosY < playerPosY)
            {
                enemyPosY += 1;
            }

            else if (enemyPosY > playerPosY)
            {
                enemyPosY -= 1;
            }

            if (enemyPosX == playerPosX && enemyPosY == playerPosY)
            {
                playerHealth = playerHealth - 1;
                playerPosX = 1;
                playerPosY = 1;
            }

            if (playerHealth <= 0)
            {
                isGameActive = false;
            }

            if (enemyPosX <= 1)
            {
                enemyPosX = 1;
            }

            if (enemyPosY <= 1)
            {
                enemyPosY = 1;
            }

            if (enemyPosX >= 30)
            {
                enemyPosX = 30;
            }

            if (enemyPosY >= 12)
            {
                enemyPosY = 12;
            }
        }

        static void ShowHUD()
        {
            Console.WriteLine("Player Health: " + playerHealth);
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("Enemy Health: " + enemyHealth);
        }

        static void SpawnGold(int amount)
        {
            for (int g = 0; g < amount; g++)
            {
                int randomPosX = randomPos.Next(minGoldPosX, maxGoldPosX);
                int randomPosY = randomPos.Next(minGoldPosY, maxGoldPosY);

                (int, int) spawnPos = (randomPosX, randomPosY);

                goldPositions.Add(spawnPos);
            }
        }

        static void DrawGold()
        {
           for(int g = 0; g < goldPositions.Count; g++)
            {
                Console.SetCursorPosition(goldPositions[g].Item1, goldPositions[g].Item2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("#");
            }
        }

        static void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game Over");
        }
    }
}