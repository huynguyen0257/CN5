using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.CollectionDemo
{
    public class Items
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public void Show()
        {
            Console.WriteLine($"ID: {ID} - Name: {Name} - Weight: {Weight} - Price: {Price}");
        }
    }
}
