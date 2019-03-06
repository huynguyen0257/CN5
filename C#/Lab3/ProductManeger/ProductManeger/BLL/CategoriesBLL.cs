using ProductManeger.DAO;
using ProductManeger.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManeger.BLL
{
    class CategoriesBLL
    {
        CategoriesDAO categoriesDAO;
        public CategoriesBLL()
        {
            categoriesDAO = new CategoriesDAO();
        }

        public List<CategoriesDTO> GetCategoriesList()
        {
            return categoriesDAO.GetAll();
        }
        public CategoriesDTO GetCategoriesById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return categoriesDAO.SearchById(id);
        }
        public void InsertCategories(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Have null or White Space on text name!");
            }
            else
            {
                CategoriesDTO dto = new CategoriesDTO();
                dto.cateName = name;
                dto.cateId = id;
                if (categoriesDAO.Add(dto))
                {
                    //do not thing
                }
                else
                {
                    throw new Exception("Insert Fail!");
                }
            }
        }
        public void UpdateCategories(int id, string name)
        {
            CategoriesDTO dto = new CategoriesDTO();
            dto.cateId = id;
            dto.cateName = name;
            if (categoriesDAO.Update(dto))
            {
                //do not thing
            }
            else
            {
                throw new Exception("Delete Fail!");
            }
        }
        public void DeleteCategories(int id)
        {
            if (categoriesDAO.Delete(id))
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
