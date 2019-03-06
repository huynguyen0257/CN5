using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class HinhChuNhat : HinhHoc
    {
        private float mChieuDai, mChieuRong;
        public HinhChuNhat()
        {
            mChieuDai = 4;
            mChieuRong = 2;
        }
        public HinhChuNhat(float chieuDai , float chieuRong)
        {
            mChieuRong = chieuRong;
            mChieuDai = chieuDai;
        }
        public void TinhChuVi_DienTich()
        {
            mChiVi = (mChieuRong + mChieuDai) * 2;
            mDienTich = mChieuDai * mChieuRong;
        }
        //Overide phuong thuc xemChuViDienTich
        public override void xemChuViDienTich()
        {
            Console.WriteLine("Thong tin Hinh Chu Nhat");
            base.xemChuViDienTich();
        }
    }
}
