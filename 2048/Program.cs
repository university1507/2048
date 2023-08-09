using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Program
    {
        static Random random = new Random();
        static int[,] map = new int[4, 4];
        static void CreateNewNumber()
        {
            int x = 0;
            int y = 0;

            do
            {
                x = random.Next(0, map.GetLength(0));
                y = random.Next(0, map.GetLength(1));
            }
            while (map[x, y] != 0);

            map[x, y] = 2;
        }
        static void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
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
            while(true)
            {
                DrawMap();
                Console.ReadKey();
                CreateNewNumber();
            }
            
        }
    }
}
