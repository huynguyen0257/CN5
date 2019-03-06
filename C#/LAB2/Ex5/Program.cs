using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    class Program
    {
        static void PrintProduct(ArrayList al)
        {
            foreach (Product p in al)
            {
                Console.WriteLine("ProductID : " + p.ProductID);
                Console.WriteLine("ProductName : " + p.ProductName);
                Console.WriteLine("UnitPrice : " + p.UnitPrice);
                Console.WriteLine("Quanity : " + p.Quantity);
                Console.WriteLine("Subtotal : " + p.SubTotal);
                Console.WriteLine("---------------------***----------------------");
            }
        }

        //I'm fixxing here
        static void DisplayMessageForRemoveProduct(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            //Tao doi tuong Product su dung Object Initializer
            Product objCaple = new Product
            {
                ProductID = 1, ProductName = "caphe",
                Quantity = 12 , UnitPrice = 3
            };
            Product objMilk = new Product
            {
                ProductID = 2 , ProductName = "milk",
                UnitPrice = 23 , Quantity = 4
            };

            //Khai bao doi tuong manageProduct de thuc hien them, xoa ,tim product
            ManageProduct mp = new ManageProduct();

            //dang ky su kien khi xoa mat hang trong danh sach
            //khi su kien EventAddProduct cua doi tuong mp phat sinh no se goi
            //den phuong thuc DisplayMessageForRemoveProduct de xuat thong bao
            mp.EventAddProduct += DisplayMessageForRemoveProduct;
            //Them cac mat hang vao ArrayList thong qua phuong thuc AddNew
            mp.AddNew(objCaple);
            mp.AddNew(objMilk);

            Console.WriteLine("*******************Danh sach cac mat hang**********************");
            //Xem danh sach cac mat hang
            PrintProduct(mp.GetProductList);
            //Tim mat hang co ProductID = 1
            Console.WriteLine("*******************Tim mat hang theo ProductID**********************");
            Console.Write("Enter ProductID : ");
            int proID = Convert.ToInt32(Console.ReadLine());
            Product p = mp.Find(proID);
            if (p!=null)
            {
                //xoa mat hang nay khi tim thay
                mp.Remove(p.ProductID);
                Console.Write("Press Enter to review Product List: ");
                Console.ReadLine();
                PrintProduct(mp.GetProductList);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
            //Console.ReadKey();
        }
    }
}
