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
        static int[,] map = new int[4, 4]
        {
            {512, 0, 1024, 10 },
            {0, 32, 0, 128 },
            {0, 2048, 0, 0 },
            {0, 0, 64, 256 },
        };


        static bool CheckLosse()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static int RandomNumber()
        {
            int number = 2;
            if(random.Next(0, 100) > 75 )
            {
                number = 4;
            }
            return number;
        }

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
            map[x, y] = RandomNumber();
        }
        static void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                    {
                        Console.Write(new string(' ', 4));

                    }
                    else
                    {
                        int length = map[i, j].ToString().Length;
                        string space = new string(' ', 4 - length);
                        if (map[i, j] < 32)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (map[i, j] < 64)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (map[i, j] < 128)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (map[i, j] < 512)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (map[i, j] < 1024)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write(space + map[i, j]);
                        Console.ResetColor();
                    }
                    Console.Write("|");
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
                if (CheckLosse())
                {
                    break;
                }
                CreateNewNumber();
            }
            Console.WriteLine("Ви програли");
            Console.ReadKey();
        }
    }
}
