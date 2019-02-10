using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    class ManageProduct
    {
        //Khai bao event de xuat thong bao sau khi product da bi xoa
        public event WarningDelegete EventAddProduct;
        //Khai bao danh sach de luu cac mat hang
        private ArrayList ProductList = new ArrayList();
        //Khai bao property de danh sach mat hang
        public ArrayList GetProductList
        {
            get
            {
                return ProductList;
            }
        }

        //Khai bao phuong thuc tim product theo ID
        public Product Find(int ProductID)
        {
            foreach (Product p in ProductList)
            {
                if (p.ProductID == ProductID)
                    return p;
            }
            return null;
        }

        //Khai bao phuong thuc them mot product vao array list
        public void AddNew(Product p)
        {
            ProductList.Add(p);
        }

        //Khai bao phuong thuc xoa product
        public void Remove(int ProductID)
        {
            Product p = Find(ProductID);
            if (p != null)
            {
                ProductList.Remove(p);
                //phat su kien khi them product
                EventAddProduct("Product ID = " + p.ProductID + " removed successful.");
            }
        }
    }
}
