using ProductManeger.DAO;
using ProductManeger.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManeger.BLL
{
    class ProductBLL
    {
        private ProductDAO productDAO;
        public ProductBLL()
        {
            productDAO = new ProductDAO();
        }
        public List<ProductDTO> GetProductList()
        {
            CategoriesDAO cateDAO = new CategoriesDAO();
            List<CategoriesDTO> listCate = cateDAO.GetAll();
            List<ProductDTO> list = productDAO.GetAll();
            foreach (CategoriesDTO cateDto in listCate)
            {
                foreach (ProductDTO dto in list)
                {
                    if(dto.cateId == cateDto.cateId)
                    {
                        dto.cateName = cateDto.cateName;
                    }
                }
            }
            return list;
        }
        public ProductDTO GetPruductById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return productDAO.SearchById(id);
        }
        public void InsertProduct(string name , float price , int quantity , int cateId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Have null or White Space on text name!");
            }
            else
            {
                ProductDTO dto = new ProductDTO(0,name, price,quantity,cateId);
                if (productDAO.Add(dto))
                {
                    //do not thing
                }
                else
                {
                    throw new Exception("Insert Fail!");
                }
            }
        }
        public void UpdateProduct(int id, string name , float price , int quantity , int cateId)
        {
            ProductDTO dto = new ProductDTO(id, name, price, quantity, cateId);
            if (productDAO.Update(dto))
            {
                //do not thing
            }
            else
            {
                throw new Exception("Delete Fail!");
            }
        }
        public void DeleteProduct(int id)
        {
            if (productDAO.Delete(id))
            {
                //do not thing
            }
            else
            {
                throw new Exception("Delete Fail!");
            }
        }
    }
}
