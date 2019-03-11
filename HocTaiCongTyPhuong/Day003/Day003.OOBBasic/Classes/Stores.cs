using Day003.OOBBasic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day003.OOBBasic.Classes
{
    public class Stores : Ishowable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Stores()
        {

        }

        public void ShowInformation()
        {
            Console.WriteLine($"Name of store : {Name} - Address : {Address}");
        }
    }
}
