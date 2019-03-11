using Day003.OOBBasic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day003.OOBBasic.Classes
{
    public class Service : Ishowable
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public int NumberOfProduct { get; set; }
        
        public void ShowInformation()
        {
            Console.WriteLine($"Name: {ServiceName} - Number Of Products: {NumberOfProduct}");
        }
    }
}
