using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5._2
{
    public delegate int delegateForNhapSo();
    public delegate int delegateForBinhPhuong(int a);
    public delegate float delegateForCanBac2(int a);
    class Program
    {
        public static int NhapSo()
        {
            Console.Write("Nhap so :");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int BinhPhuong(int a)
        {
            return a * a;
        }
        public static float CanBac2(int a)
        {
            return (float)Math.Sqrt(a);
        }
        static void Main(string[] args)
        {
            delegateForNhapSo dnp = new delegateForNhapSo(NhapSo);
            delegateForBinhPhuong dbp = new delegateForBinhPhuong(BinhPhuong);
            delegateForCanBac2 dcb2 = new delegateForCanBac2(CanBac2);
            int value_Nhapso = dnp();
            int value_Binhphuong = dbp(value_Nhapso);
            float value_Canbac2 = dcb2(value_Nhapso);
            Console.WriteLine("Value of NhapSo method : " + value_Nhapso);
            Console.WriteLine("Value of BinhPhuong method : " + value_Binhphuong);
            Console.WriteLine("Value of CanBac2 method : " + value_Canbac2);
        }
    }
}
