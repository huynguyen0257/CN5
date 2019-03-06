using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Doi tuong HCN
            HinhChuNhat hcn = new HinhChuNhat(8,4);
            hcn.TinhChuVi_DienTich();
            hcn.xemChuViDienTich();
            //Hinh Tron
            HinhTron ht = new HinhTron(10);
            ht.TinhChuVi_DienTich();
            ht.xemChuViDienTich();
            Console.WriteLine("---------------***--------------");
            Console.WriteLine("Su dung tinh da hinh");
            //Khai bao mang chua cac doi tuong HinhHoc
            HinhHoc[] danhSachHinh = new HinhHoc[2];
            //luu doi tuong vao mang HinhHoc
            danhSachHinh[0] = ht;
            danhSachHinh[1] = hcn;
            foreach (var hh in danhSachHinh)
            {
                hh.xemChuViDienTich();
            }
        }
    }
}
