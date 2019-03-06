using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    class Medicile
    {
        private string code, name, manufacture, date, expireDate;
        private int price, quantity, batchNumber;

        public Medicile()
        {
            code = null;
            name = null;
            manufacture = null;
            date = null;
            expireDate = null;
            price = 0;
            quantity = 0;
            batchNumber = 0;
        }
        public Medicile(string code, string name, string manufacture, int price, int quantity, string date, string expireDate,
            int batchNumber)
        {
            this.code = code;
            this.name = name;
            this.manufacture = manufacture;
            this.price = price;
            this.quantity = quantity;
            this.date = date;
            this.expireDate = expireDate;
            this.batchNumber = batchNumber;
        }

        public void Accept()
        {
            do
            {
                Console.Write("Enter the medicile code :");
                code = Console.ReadLine();
                Console.Write("Enter the medicile name :");
                name = Console.ReadLine();
                Console.Write("Enter the manufacture name :");
                manufacture = Console.ReadLine();
                Console.Write("Enter the unit price :");
                price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the quantity on hand :");
                quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the manufactured date :");
                date = Console.ReadLine();
                Console.Write("Enter the expiry date :");
                expireDate = Console.ReadLine();
                Console.Write("Enter the batch number :");
                batchNumber = Convert.ToInt32(Console.ReadLine());
            } while (code == null || name == null || manufacture == null || date == null || expireDate == null);
        }

        public void IncreaseQuantity()
        {
            quantity += 50;
        }

        public void Print()
        {
            Console.WriteLine("\n********* The Medicile detail *********");
            Console.WriteLine("Medicile code: " + code);
            Console.WriteLine("Medicile name: " + name);
            Console.WriteLine("Manufacture name: " + manufacture);
            Console.WriteLine("The unit price: " + price);
            Console.WriteLine("The quantity on hand: " + quantity);
            Console.WriteLine("The manufacture date: " + date);
            Console.WriteLine("The expiry date: " + expireDate);
            Console.WriteLine("The batch number: " + batchNumber);
        }

        public void Print(string code)
        {
            Console.WriteLine("The medicile code: " + code);
            Console.WriteLine("The quantity on hand: " + quantity);
        }

        public void Print(string code , string name)
        {
            Console.WriteLine("The Medicile code: " + code);
            Console.WriteLine("The Medicile name: " + name);
            Console.WriteLine("The expiry date: " + expireDate);
            Console.WriteLine("The manufactured date: " + date);
        }
    }
}
