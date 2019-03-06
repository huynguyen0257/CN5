using DemoStudents.BLL;
using StudentManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoStudents
{
    public partial class Form1 : Form
    {
        StudentBLL bus;
        public Form1()
        {
            InitializeComponent();
            bus = new StudentBLL();
            dataGridView1.DataSource = bus.GetStudentList();// Can khoi tao laij myAdapter de khi chua load du lieu van insert vao DB duoc
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus.GetStudentList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            try
            {
                bus.InsertStudent(name, address);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.ReadOnly = true;
            int index = dataGridView1.CurrentRow.Index;
            txtId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int carId = int.Parse(txtId.Text);
            string carName = txtName.Text;
            string carAddress = txtAddress.Text;
            if (txtId.ReadOnly)
            {
                try
                {
                    bus.UpdateStudent(carId, carName, carAddress);
                    MessageBox.Show("Update successful!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select Student before update!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int carId = int.Parse(txtId.Text);
                if (txtId.ReadOnly)
                {
                    MessageBox.Show("Click to New button before search");
                }
                else
                {
                    Student dto = bus.GetStudentById(carId);
                    if (dto == null)
                    {
                        MessageBox.Show("Student ID does not existed!");
                    }
                    else
                    {
                        txtName.Text = dto.Name;
                        txtAddress.Text = dto.Address;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input integer on Student ID!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.ReadOnly)
                {
                    MessageBox.Show("Please click new button before delete!");
                }
                else
                {
                    int studentId = int.Parse(txtId.Text);
                    bus.DeleteStudent(studentId);
                    MessageBox.Show("Delete successful!");
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
