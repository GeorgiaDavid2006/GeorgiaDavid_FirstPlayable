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
        static void Main(string[] args)
        {
            string path = @"Map.txt";

            map = File.ReadAllLines(path);

            DisplayMap();
        }
        static void DisplayMap()
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
    }
}