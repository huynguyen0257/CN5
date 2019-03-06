using StudentManagement;
using StudentManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStudents.BLL
{
    class StudentBLL
    {
        private StudentDAO studentDAO;
        public StudentBLL()
        {
            studentDAO = new StudentDAO();
        }
        public List<Student> GetStudentList()
        {
            return studentDAO.GetAll();
        }
        public Student GetStudentById(int id)
        {
            if (id < 0) // Xu ly nghiep vu, do ton chi phi query
            {
                return null;
            }
            return studentDAO.SearchById(id);
        }
        public void InsertStudent(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Have null or White Space on text name!");
            }
            else
            {
                Student dto = new Student();
                dto.Name = name;
                dto.Address = address;
                if (studentDAO.Add(dto))
                {
                    //do not thing
                }
                else
                {
                    throw new Exception("Insert Fail!");
                }
            }
        }
        public void UpdateStudent(int id , string name , string address)
        {
            Student dto = new Student();
            dto.Id = id;
            dto.Name = name;
            dto.Address = address;
            if (studentDAO.Update(dto))
            {
                //do not thing!
            }
            else
            {
                throw new Exception("Update Fail!");
            }
        }
        public void DeleteStudent(int id)
        {
            if (studentDAO.Delete(id))
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
