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
            Console.Clear();
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
            DrawMap();
            UpdateDirection();
        }

        static void UpdateDirection()
        {
            while (true)
            {
                UpdateCellsPositions(Console.ReadKey().Key);
                DrawMap();
            }
        }

        static void UpdateCellsPositions(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            if (j > 0)
                            {
                                map[i, j - 1] = map[i, j];
                            }
                            if (j == map.GetLength(1) - 1)
                            {
                                map[i, j] = 0;
                            }
                        }
                    }
                    break;

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    for (int i = 0; i < map.GetLength(1); i++)
                    {
                        for (int j = 0; j < map.GetLength(0); j++)
                        {
                            if (j > 0)
                            {
                                map[j - 1, i] = map[j, i];
                            }
                            if (j == map.GetLength(1) - 1)
                            {
                                map[j, i] = 0;
                            }
                        }
                    }
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = map.GetLength(1); j >= 0; j--)
                        {
                            if (j < map.GetLength(1) - 1)
                            {
                                map[i, j + 1] = map[i, j];
                            }
                            if (j == 0)
                            {
                                map[i, j] = 0;
                            }
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    for (int i = 0; i < map.GetLength(1); i++)
                    {
                        for (int j = map.GetLength(0); j >= 0; j--)
                        {
                            if (j < map.GetLength(0) - 1)
                            {
                                map[j + 1, i] = map[j, i];
                            }
                            if (j == 0)
                            {
                                map[j, i] = 0;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
