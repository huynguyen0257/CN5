using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NetDataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetAllNhanVien().Tables["NhanVien"];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DataMember = "NhanVien";
        }

        DataSet GetAllNhanVien()
        {
            DataSet data = new DataSet();

            // Sử dụng SqlConnection
            // sau khi sài xong là bỏ
            int Id = 2;
            string sql = "select * from NhanVien Where Id = @id";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", Id);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                Adapter.Fill(data,"NhanVien");

                connection.Close();
            }
            // SqlCommand
            // SqlDataAdapter


            return data;
        }
    }
}
