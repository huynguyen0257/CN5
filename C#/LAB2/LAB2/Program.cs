using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            Medicile med = new Medicile();
            med.Accept();
            med.IncreaseQuantity();
            Console.WriteLine("Test the first Print() method");
            med.Print();
            Console.WriteLine("\nTest the second Print() method");
            med.Print("code");
            Console.WriteLine("\nTest the third Print() method");
            med.Print("code", "name");
        }

    }
}
