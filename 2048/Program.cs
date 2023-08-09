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
                        if (map[i, j] < 8)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else if(map[i, j] < 16)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if(map[i, j] < 32)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
        static void Init()
        {
            Console.CursorVisible = false;
            CreateNewNumber();
        }
        static void Main(string[] args)
        {
            Init();
            while (true)
            {
                DrawMap();
                UpdateCellsPositions();
                if (CheckLosse())
                {
                    break;
                }
                CreateNewNumber();
            }
            Console.WriteLine("Ви програли");
            Console.ReadKey();
        }

        static void UpdateLeft()
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 1; i < map.GetLength(0); i++)
                {
                    if (map[j, i] == map[j, i - 1])
                    {
                        map[j, i - 1] = map[j, i] * 2;
                        map[j, i] = 0;
                    }
                    else if (map[j, i - 1] == 0)
                    {
                        map[j, i - 1] = map[j, i];
                        map[j, i] = 0;
                    }
                }
            }
        }
        static void UpdateUp()
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = 1; i < map.GetLength(0); i++)
                {
                    if (map[i, j] == map[i - 1, j])
                    {
                        map[i - 1, j] = map[i, j] * 2;
                        map[i, j] = 0;
                    }
                    else if (map[i - 1, j] == 0)
                    {
                        map[i - 1, j] = map[i, j];
                        map[i, j] = 0;
                    }
                }
            }
        }
        static void UpdateDown()
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = map.GetLength(0) - 2; i >= 0; i--)
                {
                    if (map[i, j] == map[i + 1, j])
                    {
                        map[i + 1, j] = map[i, j] * 2;
                        map[i, j] = 0;
                    }
                    else if (map[i + 1, j] == 0)
                    {
                        map[i + 1, j] = map[i, j];
                        map[i, j] = 0;
                    }
                }
            }
        }
        static void UpdateRight()
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                for (int i = map.GetLength(0) - 2; i >= 0; i--)
                {
                    if (map[j, i] == map[j, i + 1])
                    {
                        map[j, i + 1] = map[j, i] * 2;
                        map[j, i] = 0;
                    }
                    else if (map[j, i + 1] == 0)
                    {
                        map[j, i + 1] = map[j, i];
                        map[j, i] = 0;
                    }
                }
            }
        }

        static void UpdateCellsPositions()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    for (int i = 0; i < 4; i++)
                    {
                        UpdateLeft();
                    }
                    break;

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    for (int i = 0; i < 4; i++)
                    {
                        UpdateUp();
                    }
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    for (int i = 0; i < 4; i++)
                    {
                        UpdateRight();
                    }
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    for (int i = 0; i < 4; i++)
                    {
                        UpdateDown();
                    }
                    break;
            }
        }
    }
}
