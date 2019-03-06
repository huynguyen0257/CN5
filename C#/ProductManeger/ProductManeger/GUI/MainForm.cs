using ProductManeger.BLL;
using ProductManeger.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManeger.GUI
{
    public partial class MainForm : Form
    {
        ProductBLL productBLL;
        CategoriesBLL categoriesBLL;
        public MainForm()
        {
            InitializeComponent();
            productBLL = new ProductBLL();
            categoriesBLL = new CategoriesBLL();
            txtId.ReadOnly = true;
            txtCateId.ReadOnly = true;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            cmbCategories.DataSource = categoriesBLL.GetCategoriesList();
            cmbCategories.DisplayMember = "cateName";
            cmbCategories.ValueMember = "cateId";
            dataGridView1.DataSource = productBLL.GetProductList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = categoriesBLL.GetCategoriesList();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.ReadOnly = true;
            int index = dataGridView1.CurrentRow.Index;
            txtId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtQuantity.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            //cmbCategories.SelectedText = dataGridView1.Rows[index].Cells[4].Value.ToString();
            cmbCategories.SelectedIndex = cmbCategories.FindStringExact(dataGridView1.Rows[index].Cells[5].Value.ToString());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = ""; 
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtName.Focus();
            txtId.ReadOnly = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                float price = float.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                int cateId = int.Parse(cmbCategories.SelectedValue.ToString());
                productBLL.InsertProduct(name, price, quantity, cateId);
                MessageBox.Show("Insert successful!");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                float price = float.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                int cateId = int.Parse(cmbCategories.SelectedValue.ToString());
                productBLL.UpdateProduct(id, name, price, quantity, cateId);
                MessageBox.Show("Update succcessful!");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int search = int.Parse(txtSearch.Text);
                ProductDTO dto = productBLL.GetPruductById(search);
                if(dto == null)
                {
                    MessageBox.Show("Product's Id does not existed!");
                }
                else
                {
                    txtId.Text = dto.id.ToString();
                    txtName.Text = dto.name;
                    txtPrice.Text = dto.price.ToString();
                    txtQuantity.Text = dto.quantity.ToString();
                    string cateName = categoriesBLL.GetCategoriesById(dto.cateId).cateName;
                    cmbCategories.SelectedIndex = cmbCategories.FindStringExact(cateName);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                productBLL.DeleteProduct(id);
                MessageBox.Show("Delete successful!");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Cate_Click(object sender, EventArgs e)
        {
            txtCateId.Text = "";
            txtCateName.Text = "";
            txtCateId.Focus();
            txtCateId.ReadOnly = false;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentRow.Index;
            txtCateId.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            txtCateName.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
        }

        private void btnInsert_Cate_Click(object sender, EventArgs e)
        {
            if (!txtCateId.ReadOnly)
            {
                try
                {
                    int cateId = int.Parse(txtCateId.Text);
                    string cateName = txtCateName.Text;
                    categoriesBLL.InsertCategories(cateId, cateName);
                    MessageBox.Show("insert successful!");
                    loadData();
                    txtCateId.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }

        private void btnUpdate_Cate_Click(object sender, EventArgs e)
        {
            if (txtCateId.ReadOnly)
            {
                try
                {
                    int id = int.Parse(txtCateId.Text);
                    string name = txtCateName.Text;
                    categoriesBLL.UpdateCategories(id, name);
                    MessageBox.Show("Update successful!");
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please choose category before update!");
            }
        }

        private void btnDelete_Cate_Click(object sender, EventArgs e)
        {
            if (txtCateId.ReadOnly)
            {
                try
                {
                    int id = int.Parse(txtCateId.Text);
                    categoriesBLL.DeleteCategories(id);
                    MessageBox.Show("Delete successful!");
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please choose category before update!");
            }
        }

        private void btnSearch_Cate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCateSearch.Text);
            try
            {
                CategoriesDTO dto = categoriesBLL.GetCategoriesById(id);
                txtCateId.Text = dto.cateId.ToString();
                txtCateName.Text = dto.cateName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
