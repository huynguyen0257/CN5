using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day1
{
    public partial class frmCafe : Form
    {
        public frmCafe()
        {
            InitializeComponent();
        }

        private void frmCafe_Load(object sender, EventArgs e)
        {
            List<MatHang> dsMatHang = new List<MatHang>();

            dsMatHang.Add(new MatHang { id = "001", name = "Cafe" });
            dsMatHang.Add(new MatHang { id = "002", name = "Pepsi" });
            dsMatHang.Add(new MatHang { id = "003", name = "Coca" });
            dsMatHang.Add(new MatHang{id = "004", name = "Vinamild"});
            dsMatHang.Add(new MatHang { id = "005", name = "Dr. Thanh" });

            cmbMatHang.DataSource = dsMatHang;
            cmbMatHang.DisplayMember = "name";
            cmbMatHang.ValueMember = "id";
            txtDonGia.Text = "12000";
        }

        private void cmbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMatHang.SelectedValue.ToString() == "001")
            {
                txtDonGia.Text = "12000";
            }
            if (cmbMatHang.SelectedValue.ToString() == "002")
            {
                txtDonGia.Text = "15000";
            }
            if (cmbMatHang.SelectedValue.ToString() == "003")
            {
                txtDonGia.Text = "20000";
            }
            if (cmbMatHang.SelectedValue.ToString() == "004")
            {
                txtDonGia.Text = "17000";
            }
            if (cmbMatHang.SelectedValue.ToString() == "005")
            {
                txtDonGia.Text = "10000";
            }
        }
    }
}
