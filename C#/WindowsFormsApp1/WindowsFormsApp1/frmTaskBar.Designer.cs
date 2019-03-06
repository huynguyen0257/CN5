namespace WindowsFormsApp1
{
    partial class frmTaskBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tkbRed = new System.Windows.Forms.TrackBar();
            this.lable1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tkbGreen = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tkbBlue = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // tkbRed
            // 
            this.tkbRed.Location = new System.Drawing.Point(151, 104);
            this.tkbRed.Maximum = 255;
            this.tkbRed.Name = "tkbRed";
            this.tkbRed.Size = new System.Drawing.Size(282, 45);
            this.tkbRed.TabIndex = 0;
            this.tkbRed.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(27, 104);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(44, 20);
            this.lable1.TabIndex = 1;
            this.lable1.Text = "RED";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "GREEN";
            // 
            // tkbGreen
            // 
            this.tkbGreen.Location = new System.Drawing.Point(151, 164);
            this.tkbGreen.Maximum = 255;
            this.tkbGreen.Name = "tkbGreen";
            this.tkbGreen.Size = new System.Drawing.Size(282, 45);
            this.tkbGreen.TabIndex = 2;
            this.tkbGreen.Scroll += new System.EventHandler(this.tkbGreen_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "BLUE";
            // 
            // tkbBlue
            // 
            this.tkbBlue.LargeChange = 50;
            this.tkbBlue.Location = new System.Drawing.Point(151, 225);
            this.tkbBlue.Maximum = 255;
            this.tkbBlue.Name = "tkbBlue";
            this.tkbBlue.Size = new System.Drawing.Size(282, 45);
            this.tkbBlue.SmallChange = 10;
            this.tkbBlue.TabIndex = 4;
            this.tkbBlue.Scroll += new System.EventHandler(this.tkbBlue_Scroll);
            // 
            // frmTaskBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tkbBlue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tkbGreen);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.tkbRed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTaskBar";
            this.Text = "frmTaskBar";
            ((System.ComponentModel.ISupportInitialize)(this.tkbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tkbRed;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tkbGreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tkbBlue;
    }
}