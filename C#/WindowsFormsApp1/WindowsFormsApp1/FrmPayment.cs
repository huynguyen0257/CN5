using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPayment : Form
    {
        List<TraSua> list = new List<TraSua>();

        public FrmPayment()
        {
            InitializeComponent();
            list.Add(new TraSua { Code = "TS01", Name = "Trà trân châu", UnitPrice = 10000 });
            list.Add(new TraSua { Code = "TS02", Name = "Trà hồng đào", UnitPrice = 20000 });
            list.Add(new TraSua { Code = "TS03", Name = "Trà ô long", UnitPrice = 24000 });
            list.Add(new TraSua { Code = "TS04", Name = "Trà lài", UnitPrice = 25000 });
            list.Add(new TraSua { Code = "TS05", Name = "Trà matcha", UnitPrice = 52000 });
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            cmbTraSua.DataSource = list;
            cmbTraSua.DisplayMember = "Name";
            cmbTraSua.ValueMember = "Code";

            rdKhongGiam.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTraSua_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = cmbTraSua.SelectedValue.ToString();
            foreach (var item in list)
            {
                if (item.Code.Equals(code))
                {
                    txtDonGia.Text = item.UnitPrice.ToString();
                    return;
                }
            }
        }

        private double GiamGia()
        {
            double giamgia = 0.0;
            if (rdGiamGia.Checked == true)
            {
                return 0.1;
            }
            return giamgia;
        }

        private double TangThem()
        {
            double tangthem = 0.0;
            if (chkTopping.Checked == true) tangthem += 5000;
            if (chkPhoMai.Checked == true) tangthem += 5000;
            return tangthem;
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSoLuong.Focus();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtAmount.Clear();
            rdKhongGiam.Checked = true;
            chkTopping.Checked = false;
            chkPhoMai.Checked = false;
            cmbTraSua.Refresh();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string info = "Ngày: "+ DateTime.Now.ToString("dd/MM/yyyy") +"\nTổng tiền thanh toán = " + txtAmount.Text;
            MessageBox.Show(info, "Thông báo", MessageBoxButtons.OK); //Lua chon thu 5 trong 21 lua chon
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                int soluong = int.Parse(txtSoLuong.Text);
                double dongia = Double.Parse(txtDonGia.Text);

                double ThanhTien = (soluong * (dongia + TangThem())) * (1 - GiamGia());

                txtAmount.Text = String.Format("{0:0,0}", ThanhTien);
            }
            
        }

        private void FrmPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Muốn tắt không", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

        public bool KiemTraDuLieu()
        {
            errorProvider1.Clear();
            if (String.IsNullOrWhiteSpace(txtSoLuong.Text) || txtSoLuong.Text.Equals("0"))
            {
                errorProvider1.SetError(txtSoLuong, "Không được để trống");
                return false;
            }
            return true;
        }
    }
}
