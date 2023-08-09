using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal static class Control
    {
        public static string GetKey(ConsoleKey inputKey)
        {
            string direction;
            switch (inputKey)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    direction = "left";
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    direction = "up";
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    direction = "right";
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    direction = "down";
                    break;
                default:
                    direction = "";
                    break;
            }
            return direction;
        }
    }
}
