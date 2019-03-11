using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.NonPrimitiveDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal01 = new Animal();
            animal01.Name = "abc";
            animal01.YOB = 1999;
            animal01.Type = AnimalTypeEnum.Pig;
            Console.WriteLine($"Name: {animal01.Name} - YOB: {animal01.YOB} - Type: {(int)animal01.Type}");

            Bird bird01 = new Bird(); //Struct chi
            bird01.WingSize = 5;
            Console.WriteLine($"WingSize: {bird01.WingSize}");


            int[] arrayIntegers = new int[] { 1, 2, 4, 6, 8 };

        }
    }
}
