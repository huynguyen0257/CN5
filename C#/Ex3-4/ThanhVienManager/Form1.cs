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

namespace ThanhVienManager
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            LoadDataGridView();
            LoadDataOnCombobox();
            formatDateTimePicker();
        }
        private void LoadDataGridView()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ThanhVienManager.Properties.Settings.dbConnectionString"].ConnectionString;
            conn = new SqlConnection(connStr);

            //Tạo query
            string query = "select * from ThanhViens, Nhoms where NhomId=Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter dAdapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed
                    || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                dAdapt.Fill(ds,"ThanhVien");
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                conn.Close();
            }
            dgvThanhVien.DataSource = ds.Tables["ThanhVien"];
            dgvThanhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Xử lý ẩn các cột hiển thị không cần thiết
            dgvThanhVien.Columns["Name"].Visible = false;
            //dgvThanhVien.Columns[]
            dgvThanhVien.Columns["Address"].Visible = false;
            dgvThanhVien.Columns["Mobile"].Visible = false;
            dgvThanhVien.Columns["NhomId"].Visible = false;
            dgvThanhVien.Columns["Id"].Visible = false;
            dgvThanhVien.Columns["JoinDate"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
        private void LoadDataOnCombobox()
        {
            string query = "Select * from Nhoms";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter dAdapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                if(conn.State == ConnectionState.Closed ||
                    conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                dAdapt.Fill(ds,"Nhom");
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                conn.Close();
            }
            cmbGroup.DataSource = ds.Tables["Nhom"];
            cmbGroup.ValueMember = "Id";
            cmbGroup.DisplayMember = "RoleName";
        }
        private void formatDateTimePicker()
        {
            dtpJoinDate.Format = DateTimePickerFormat.Custom;
            dtpJoinDate.CustomFormat = "dd-MM-yyyy";
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgvThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhVien.SelectedRows.Count > 0)
            {
                txtUsername.Text = dgvThanhVien.SelectedRows[0].Cells["Username"].Value.ToString();
                txtName.Text = dgvThanhVien.SelectedRows[0].Cells["Name"].Value.ToString();
                txtAddress.Text = dgvThanhVien.SelectedRows[0].Cells["Address"].Value.ToString();
                txtMobile.Text = dgvThanhVien.SelectedRows[0].Cells["Mobile"].Value.ToString();
                dtpJoinDate.Value = (DateTime)dgvThanhVien.SelectedRows[0].Cells["JoinDate"].Value;
                cmbGroup.SelectedValue = dgvThanhVien.SelectedRows[0].Cells["NhomId"].Value;

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string mobile = txtMobile.Text;
            string joinDate = dtpJoinDate.Value.ToShortDateString();
            //MessageBox.Show(joinDate.ToShortDateString());
            string nhomId = cmbGroup.SelectedValue.ToString();


            //Create to database
            string query = "insert ThanhViens values (@username,@name,@address,@mobile,@joindate,@nhomId)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@joindate", joinDate);
            cmd.Parameters.AddWithValue("@nhomId", nhomId);
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
                    LoadDataGridView();
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
            string username = txtUsername.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string mobile = txtMobile.Text;
            string joinDate = dtpJoinDate.Value.ToShortDateString();
            //MessageBox.Show(joinDate.ToShortDateString());
            string nhomId = cmbGroup.SelectedValue.ToString();




            string query = "update ThanhViens set mobile=@mobile, Name=@name, address=@address, joindate=@joindate, NhomId=@nhomId Where username=@username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@joindate", joinDate);
            cmd.Parameters.AddWithValue("@nhomId", nhomId)
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
                    LoadDataGridView();
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
            string query = "Delete Thanhviens Where username = @username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
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
                    LoadDataGridView();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtName.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
            txtUsername.Focus();
            cmbGroup.SelectedIndex = 0;
        }
    }
}
