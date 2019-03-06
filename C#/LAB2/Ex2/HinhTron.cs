using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class HinhTron:HinhHoc
    {
        private float mBanKinh;
        public HinhTron()
        {
            mBanKinh = 0;
        }
        public HinhTron(float banKinh)
        {
            mBanKinh = banKinh;
        }
        public void TinhChuVi_DienTich()
        {
            mDienTich = (float)Math.PI * mBanKinh * mBanKinh;
            mChiVi = 2 * (float)Math.PI * mBanKinh;
        }
        //override phuong thuc xemChuViDienTich
        public override void xemChuViDienTich()
        {
            Console.WriteLine("Thong tin Hinh Tron");
            base.xemChuViDienTich();
        }
    }
}
