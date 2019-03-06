using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4
{
    public partial class Form1 : Form
    {
        SqlDataAdapter dAdapt;
        DataSet myDS ;
        SqlConnection cnObj;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.carsDataSet.Inventory);
            loadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addNewData();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        public void loadData()
        {
            //Load Data from database to the data set and view on dataGrid
            initDataSet();
            try
            {
                dAdapt.Fill(myDS, "Inventory");
                dataGridView1.DataSource = myDS.Tables["Inventory"];
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data " + e.Message);
                dataGridView1.DataSource = null;
            }
        }
        public void initDataSet()
        {
            //Khoi tao DataSet and Connection
            myDS = new DataSet("CarsDatabase");
            cnObj = new SqlConnection(@"uid=sa;pwd=1234;Initial Catalog=Cars;Data Source=DESKTOP-MHPMKMP\SQLEXPRESS");
            //Fill the DataSet with a new DataTable.
            string cnStr = @"uid=sa;pwd=1234;Initial Catalog=Cars;Data Source=DESKTOP-MHPMKMP\SQLEXPRESS";
            dAdapt = new SqlDataAdapter("Select * From Inventory", cnStr);
            //Using SqlCommandBuilder to generate SQL query commands
            //SqlCommandBuilder invBuilder = new SqlCommandBuilder(dAdapt);

        }
        public void updateToDS()
        {
            try
            {
                dAdapt.Update(myDS.Tables["Inventory"]);
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry!     Error!  Canceling request .... " + e.Message);
            }
        }
        public void addNewData()
        {
            //Update Inventory Table with new row.
            DataRow newCar = myDS.Tables["Inventory"].NewRow();
            newCar["CarID"] = int.Parse(this.txtCarId.Text);
            newCar["Make"] = this.txtMake.Text;
            newCar["Color"] = this.txtColor.Text;
            newCar["PetName"] = this.txtPetName.Text;
            myDS.Tables["Inventory"].Rows.Add(newCar);

            string sql = string.Format("Insert Into Inventory" +
                "(CarID , Make , Color , PetName) Values" +
                "('{0}' , '{1}','{2}','{3}')", int.Parse(this.txtCarId.Text), this.txtMake.Text, this.txtColor.Text, this.txtPetName.Text);
            SqlCommand cmd = new SqlCommand(sql, cnObj);
            dAdapt.InsertCommand = cmd;
            //cmd.ExecuteNonQuery(); Connection can phai Open de su dung ham nay!!
            updateToDS();
        }
        public void updateData()
        {
            DataRow[] carRowToUpdate = myDS.Tables["Inventory"].Select(string.Format("CarID = '{0}'", this.txtCarId.Text));
            if (carRowToUpdate.Length != 0)
            {
                carRowToUpdate[0]["PetName"] = this.txtPetName.Text;
                carRowToUpdate[0]["Make"] = this.txtMake.Text;
                carRowToUpdate[0]["Color"] = this.txtColor.Text;
                string sql = "Update Inventory Set PetName = @petname , Make = @make , Color = @color Where CarID = @id";
                SqlCommand cmd = new SqlCommand(sql, cnObj);
                cmd.Parameters.AddWithValue("@petname", this.txtPetName.Text);
                cmd.Parameters.AddWithValue("@make", this.txtMake.Text);
                cmd.Parameters.AddWithValue("@color", this.txtColor.Text);
                cmd.Parameters.AddWithValue("@id", this.txtCarId.Text);
                dAdapt.UpdateCommand = cmd;
            }
            else
            {
                MessageBox.Show("CarID does not existed!");
                txtCarId.Focus();
            }
            updateToDS();
        }
        public void deleteData()
        {
            try
            {
                if (txtCarId.Text != null)
                {
                    Console.Write("Row # to delete: ");
                    int carIdtoDelete = int.Parse(this.txtCarId.Text);
                    DataRow[] rowToDelete = myDS.Tables["Inventory"].Select(string.Format("CarID = '{0}'", this.txtCarId.Text));
                    if (rowToDelete.Length != 0)
                    {
                        string sql = "Delete from Inventory where CarID = @id";
                        SqlCommand cmd = new SqlCommand(sql, cnObj);
                        cmd.Parameters.AddWithValue("@id", carIdtoDelete);
                        dAdapt.DeleteCommand = cmd;
                        rowToDelete[0].Delete();
                        dAdapt.Update(myDS.Tables["Inventory"]);
                    }
                    else
                    {
                        MessageBox.Show("CarId does not existed!");
                        txtCarId.Focus();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry!     Error!  Canceling request: " + e.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            txtCarId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtColor.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtMake.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtPetName.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }
    }
}
