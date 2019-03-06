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
    class CategoriesDAO
    {
        private DBConnection conn;
        public CategoriesDAO()
        {
            conn = new DBConnection();
        }
        private CategoriesDTO GetCategoriesFromDataRow(DataRow row)
        {
            CategoriesDTO dto = new CategoriesDTO();
            dto.cateId = int.Parse(row["Id"].ToString());
            dto.cateName = row["name"].ToString();
            return dto;
        }
        public List<CategoriesDTO> GetAll()
        {
            string query = string.Format("select * from Categories");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = conn.ExecuteSelectQuery(query, sqlParameters);
            List<CategoriesDTO> list = new List<CategoriesDTO>();

            foreach (DataRow r in dt.Rows)
            {
                CategoriesDTO categories = GetCategoriesFromDataRow(r);
                list.Add(categories);
            }

            return list;
        }

        public CategoriesDTO SearchById(int _id)
        {
            string query = "Select * From Categories Where Id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            sqlParameters[0].Value = _id;

            DataTable dt = conn.ExecuteSelectQuery(query, sqlParameters);
            if (dt.Rows.Count > 0)
            {
                return GetCategoriesFromDataRow(dt.Rows[0]);
            }
            return null;
        }

        public bool Add(CategoriesDTO dto)
        {
            string query = "Insert into Categories values(@id,@name)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int) { Value = dto.cateId };
            sqlParameters[1] = new SqlParameter("@name", SqlDbType.NVarChar) { Value = dto.cateName };
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

        public bool Update(CategoriesDTO dto)
        {
            string query = "Update Categories set name = @name Where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@name", SqlDbType.NVarChar) { Value = dto.cateName };
            sqlParameters[1] = new SqlParameter("@id", SqlDbType.Int) { Value = dto.cateId };
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

        public bool Delete(int id)
        {
            string query = "Delete Categories Where id = @id";
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
