using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GeorgiaDavid_FirstPlayable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\MapData.txt";

            string readText = File.ReadAllText(path);
            
        }
    }
}
