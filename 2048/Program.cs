using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Program
    {
        static int[,] map = new int[,]
        {
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
            {0, 2048, 0, 0 },
            {0, 0, 0, 0 },
        };

        static void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int length = map[i, j].ToString().Length;
                    string space = new string(' ', 4 - length);
                    
                    Console.Write(space + map[i, j] + "|");
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', 20));
            }
        }

        static void Main(string[] args)
        {
            UpdateDirection();
        }

        static void UpdateDirection()
        {
            while (true)
            {
                direction = Control.GetKey(Console.ReadKey().Key);
                Console.WriteLine(direction);
            }
            DrawMap();
            Console.ReadKey();
        }
    }
}
