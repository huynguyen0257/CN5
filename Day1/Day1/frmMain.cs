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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(txtX.Text);
            double y = Convert.ToDouble(txtY.Text);

            double kq = x + y;

            txtKq.Text = kq.ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(txtX.Text);
            double y = Convert.ToDouble(txtY.Text);

            double kq = x - y;

            txtKq.Text = kq.ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(txtX.Text);
            double y = Convert.ToDouble(txtY.Text);

            double kq = x * y;

            txtKq.Text = kq.ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(txtX.Text);
            double y = Convert.ToDouble(txtY.Text);

            double kq = x / y;

            txtKq.Text = kq.ToString();
        }
    }
}
