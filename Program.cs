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
        static void Main(string[] args)
        {
            string path = @"Map.txt";
            
            string[] map = File.ReadAllLines(path);

            char c = map[0][0];

            
        }
    }
}
