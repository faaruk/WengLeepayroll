namespace WengLeePayroll
{
    partial class ConvertSalariedTemplateToTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertSalariedTemplateToTime));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonLastest5 = new WengLeePayroll.ButtonLastest();
            this.btnSave = new WengLeePayroll.ButtonLastest();
            this.cmbPayPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.labelGradient2 = new WengLeePayroll.LabelGradient();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(696, 203);
            this.dataGridView1.TabIndex = 27;
            // 
            // buttonLastest5
            // 
            this.buttonLastest5.BackColor = System.Drawing.Color.White;
            this.buttonLastest5.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest5.FlatAppearance.BorderSize = 5;
            this.buttonLastest5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest5.Location = new System.Drawing.Point(5, 540);
            this.buttonLastest5.Name = "buttonLastest5";
            this.buttonLastest5.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest5.TabIndex = 26;
            this.buttonLastest5.Text = "Delete";
            this.buttonLastest5.UseVisualStyleBackColor = false;
            this.buttonLastest5.Click += new System.EventHandler(this.buttonLastest5_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 5;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnSave.Location = new System.Drawing.Point(284, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(239, 40);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Convert Template to Time";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbPayPeriod
            // 
            this.cmbPayPeriod.DisplayMember = "EmpID";
            this.cmbPayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayPeriod.FormattingEnabled = true;
            this.cmbPayPeriod.Location = new System.Drawing.Point(94, 289);
            this.cmbPayPeriod.Name = "cmbPayPeriod";
            this.cmbPayPeriod.Size = new System.Drawing.Size(184, 21);
            this.cmbPayPeriod.TabIndex = 34;
            this.cmbPayPeriod.ValueMember = "EmpID";
            this.cmbPayPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPayPeriod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Pay Period:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 337);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.Size = new System.Drawing.Size(698, 197);
            this.dataGridView2.TabIndex = 35;
            // 
            // labelGradient2
            // 
            this.labelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.Black;
            this.labelGradient2.Location = new System.Drawing.Point(0, -4);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelGradient2.Size = new System.Drawing.Size(699, 57);
            this.labelGradient2.TabIndex = 36;
            this.labelGradient2.Text = "Salaried Time";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConvertSalariedTemplateToTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 584);
            this.Controls.Add(this.labelGradient2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.cmbPayPeriod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonLastest5);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertSalariedTemplateToTime";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SalariedEmpTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonLastest btnSave;
        private ButtonLastest buttonLastest5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbPayPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private LabelGradient labelGradient2;
    }
}