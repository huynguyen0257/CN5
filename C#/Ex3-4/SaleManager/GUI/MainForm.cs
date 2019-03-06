using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManager.GUI
{
    public partial class MainForm : Form
    {
        private SqlConnection conn;
        public MainForm()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            //Tạo Connection
            string connStr = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            conn = new SqlConnection(connStr);

            //Tao câu query
            string query = "Select * from items";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed 
                    || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                Adapter.Fill(dt);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                conn.Close();
            }
            dgvHienThiDuLieu.DataSource = dt;
            dgvHienThiDuLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string query = "insert items values (@id,@name,@price,@quantity)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDouble(txtPrice.Text));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
            if (conn.State == ConnectionState.Closed
                    || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            try
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    loadData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm");
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "update items set ItemName=@name, Unitprice=@price, quantity=@quantity Where id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDouble(txtPrice.Text));
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtQuantity.Text));
            if (conn.State == ConnectionState.Closed
                    || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            try
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    loadData();
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhập sản phẩm");
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete item Where id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
            if (conn.State == ConnectionState.Closed
                    || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            try
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    loadData();
                }
                else
                {
                    MessageBox.Show("Lỗi xóa sản phẩm");
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void dgvHienThiDuLieu_Click(object sender, EventArgs e)
        {
            if (dgvHienThiDuLieu.SelectedRows.Count > 0)
            {
                txtID.Text = dgvHienThiDuLieu.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvHienThiDuLieu.SelectedRows[0].Cells[1].Value.ToString();
                txtPrice.Text = dgvHienThiDuLieu.SelectedRows[0].Cells[2].Value.ToString();
                txtQuantity.Text = dgvHienThiDuLieu.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void dgvHienThiDuLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvHienThiDuLieu.SelectedRows.Count > 0)
            //{
            //    int index = dgvHienThiDuLieu.CurrentRow.Index;
            //    DataGridViewRow row = dgvHienThiDuLieu.Rows[index];

            //    txtID.Text = row.Cells[0].Value.ToString();
            //    txtName.Text = row.Cells[1].Value.ToString();
            //    txtPrice.Text = row.Cells[2].Value.ToString();
            //    txtQuantity.Text = row.Cells[3].Value.ToString();
            //}
            int index = dgvHienThiDuLieu.CurrentRow.Index;
            DataGridViewRow row = dgvHienThiDuLieu.Rows[index];

            txtID.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString();
            txtQuantity.Text = row.Cells[3].Value.ToString();
        }
    }
}
