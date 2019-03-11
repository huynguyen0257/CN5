using Day003.OOBBasic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day003.OOBBasic
{
    class Program
    {
        public static List<string> addresses = new List<string>() {
            "Tổng văn trân",
            "Hà thị khiêm",
            "Lý Thường Kiệt",
            "Tân kỳ tân quý",
            "Tân sơn",
            "Tạ Quang Bửu",
            "Lạc Long Quân"
        };
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Random rd = new Random();
            Brand brand01 = new Brand() {
                Id = 1,
                Name = "Uri",
            };
            List<Stores> listStores = new List<Stores>();
            for (int i = 0; i < 100; i++)
            {
                var addressIndex = rd.Next(0, addresses.Count);
                Stores store = new Stores()
                {
                    Address = $"Số nhà: {rd.Next(1000)} , {addresses.ElementAt(addressIndex)}",
                    Name = $"Store {rd.Next(100000)}",
                    Id = i
                };
                listStores.Add(store);
            }
            brand01.Stores.AddRange(listStores);
            brand01.ShowInformation();
        }
    }
}
