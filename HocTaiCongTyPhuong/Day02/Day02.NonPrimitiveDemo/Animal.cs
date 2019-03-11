using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.NonPrimitiveDemo
{
    public struct Bird
    {
        public int WingSize { get; set; }
    }
    public class Animal
    {
        public int YOB { get; set; }
        public string Name { get; set; }
        public AnimalTypeEnum Type { get; set; }

        public Animal()
        {

        }
        public Animal(int yob , string name , AnimalTypeEnum type)
        {
            this.YOB = yob;
            this.Name = name;
            this.Type = type;
        }
    }



    public enum AnimalTypeEnum
    {
        Pig = 1,
        Dog = 2,
        Cat = 3
    }
}
