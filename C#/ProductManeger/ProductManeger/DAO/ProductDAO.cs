using ProductManeger.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManeger.DAO
{
    class ProductDAO
    {
        private DBConnection conn;
        public ProductDAO()
        {
            conn = new DBConnection();
        }

        private ProductDTO GetProductFromDataRow(DataRow row)
        {
            ProductDTO product = new ProductDTO();
            product.id = int.Parse(row["Id"].ToString());
            product.name = row["name"].ToString();
            product.price = float.Parse(row["price"].ToString());
            product.quantity = int.Parse(row["quantity"].ToString());
            product.cateId = int.Parse(row["cateId"].ToString());
            return product;
        }

        public List<ProductDTO> GetAll()
        {
            string query = string.Format("select * from Products");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = conn.ExecuteSelectQuery(query, sqlParameters);
            List<ProductDTO> list = new List<ProductDTO>();

            foreach (DataRow r in dt.Rows)
            {
                ProductDTO product = GetProductFromDataRow(r);
                list.Add(product);
            }
            return list;
        }

        public ProductDTO SearchById(int _id)
        {
            string query = "Select * From Products Where Id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            sqlParameters[0].Value = _id;

            DataTable dt = conn.ExecuteSelectQuery(query, sqlParameters);
            if (dt.Rows.Count>0)
            {
                return GetProductFromDataRow(dt.Rows[0]);
            }
            return null;
        }

        public bool Add(ProductDTO product)
        {
            string query = "Insert into Products values(@name,@price,@quantity,@cateId)";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@name", SqlDbType.NVarChar) { Value = product.name };
            sqlParameters[1] = new SqlParameter("@price", SqlDbType.Float) { Value = product.price };
            sqlParameters[2] = new SqlParameter("@quantity", SqlDbType.Int) { Value = product.quantity };
            sqlParameters[3] = new SqlParameter("@cateId", SqlDbType.Int) { Value = product.cateId };
            try
            {
                conn.ExecuteInsertQuery(query, sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ProductDTO product)
        {
            string query = "Update Products set name = @name, price = @price, quantity = @quantity, cateId = @cateId Where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@name", SqlDbType.NVarChar) { Value = product.name };
            sqlParameters[1] = new SqlParameter("@price", SqlDbType.Float) { Value = product.price };
            sqlParameters[2] = new SqlParameter("@quantity", SqlDbType.Int) { Value = product.quantity };
            sqlParameters[3] = new SqlParameter("@cateId", SqlDbType.Int) { Value = product.cateId };
            sqlParameters[4] = new SqlParameter("@id", SqlDbType.Int) { Value = product.id };
            try
            {
                conn.ExecuteUpdateQuery(query, sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete (int id)
        {
            string query = "Delete Products Where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            try
            {
                conn.ExecuteDeleteQuery(query, sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
