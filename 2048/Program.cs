using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Program
    {
        static string direction;
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
        }
    }
}
