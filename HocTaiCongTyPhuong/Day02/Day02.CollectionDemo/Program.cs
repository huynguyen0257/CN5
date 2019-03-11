using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Items> cart = new List<Items>();
            var random = new Random();
            int numberOfItems = 10;
            
            for (int i = 0; i < numberOfItems; i++)
            {
                float weight = random.Next(20);
                float price = random.Next(49, 99);
                string itemName = $"Item {random.Next(3000, 9000)}";
                Items item = new Items() { ID = i ,Name = itemName, Weight = weight, Price = price };

                cart.Add(item);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Add Successful: {i}");
            }
            for (int i = 0; i < numberOfItems; i++)
            {
                Items ist = cart.ElementAt(i);
                Console.ForegroundColor = ConsoleColor.Green;
                ist.Show();
            }

            var cartWithItemGreeterThan6 = cart.Where(x => x.ID > 6);
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in cartWithItemGreeterThan6)
            {
                item.Show();
            }
        }
    }
}
