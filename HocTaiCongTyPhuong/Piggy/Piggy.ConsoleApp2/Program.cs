using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piggy.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 3;
            int[,] square = new int[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"{square[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
