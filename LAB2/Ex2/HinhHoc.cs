using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public class HinhHoc
    {
        protected float mChiVi, mDienTich;
        //Khai bao phuong thuc ao de su dung tinh da hinh
        public virtual void xemChuViDienTich()
        {
            Console.WriteLine("Chu vi = {0},Dien tich ={1}", mChiVi, mDienTich);
        }
    }
}
