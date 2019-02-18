using System;
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
    public partial class frmTaskBar : Form
    {
        public frmTaskBar()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            DoiMauNen();
        }

        private void DoiMauNen()
        {
            this.BackColor = Color.FromArgb(tkbRed.Value, tkbGreen.Value, tkbBlue.Value);
        }

        private void tkbGreen_Scroll(object sender, EventArgs e)
        {
            DoiMauNen();
        }

        private void tkbBlue_Scroll(object sender, EventArgs e)
        {
            DoiMauNen();
        }
    }
}
