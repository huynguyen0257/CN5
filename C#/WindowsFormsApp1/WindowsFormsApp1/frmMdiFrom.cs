﻿using System;
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
    public partial class frmMdiFrom : Form
    {
        public frmMdiFrom()
        {
            InitializeComponent();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPayment frm = new FrmPayment();

            frm.MdiParent = this;

            frm.Show();
            //frm.ShowDialog(); //Uu tien sử dụng
        }

        private void taskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaskBar ftb = new frmTaskBar();
            ftb.MdiParent = this;
            ftb.Show();
        }

        private void exitAllFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }
    }
}
