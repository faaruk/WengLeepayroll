namespace WengLeePayroll
{
    partial class frmPayPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPeriod));
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayPeriod = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dteFrom = new System.Windows.Forms.DateTimePicker();
            this.dteTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLastest2 = new WengLeePayroll.ButtonLastest();
            this.buttonLastest1 = new WengLeePayroll.ButtonLastest();
            this.buttonLastest5 = new WengLeePayroll.ButtonLastest();
            this.labelGradient2 = new WengLeePayroll.LabelGradient();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pay Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(140, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Comments:";
            // 
            // txtPayPeriod
            // 
            this.txtPayPeriod.Location = new System.Drawing.Point(140, 124);
            this.txtPayPeriod.Name = "txtPayPeriod";
            this.txtPayPeriod.Size = new System.Drawing.Size(190, 20);
            this.txtPayPeriod.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 219);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(504, 225);
            this.dataGridView1.TabIndex = 18;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DisplayMember = "EmpID";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(140, 147);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(89, 21);
            this.cmbStatus.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Pay Period From:";
            // 
            // dteFrom
            // 
            this.dteFrom.CustomFormat = "MM/dd/yyyy";
            this.dteFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteFrom.Location = new System.Drawing.Point(140, 101);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.Size = new System.Drawing.Size(92, 20);
            this.dteFrom.TabIndex = 23;
            // 
            // dteTo
            // 
            this.dteTo.CustomFormat = "MM/dd/yyyy";
            this.dteTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteTo.Location = new System.Drawing.Point(267, 101);
            this.dteTo.Name = "dteTo";
            this.dteTo.Size = new System.Drawing.Size(92, 20);
            this.dteTo.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "To:";
            // 
            // buttonLastest2
            // 
            this.buttonLastest2.BackColor = System.Drawing.Color.White;
            this.buttonLastest2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest2.FlatAppearance.BorderSize = 5;
            this.buttonLastest2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.buttonLastest2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonLastest2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest2.Location = new System.Drawing.Point(13, 450);
            this.buttonLastest2.Name = "buttonLastest2";
            this.buttonLastest2.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest2.TabIndex = 21;
            this.buttonLastest2.Text = "Edit";
            this.buttonLastest2.UseVisualStyleBackColor = false;
            this.buttonLastest2.Click += new System.EventHandler(this.buttonLastest2_Click);
            // 
            // buttonLastest1
            // 
            this.buttonLastest1.BackColor = System.Drawing.Color.White;
            this.buttonLastest1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest1.FlatAppearance.BorderSize = 5;
            this.buttonLastest1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.buttonLastest1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonLastest1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest1.Location = new System.Drawing.Point(140, 173);
            this.buttonLastest1.Name = "buttonLastest1";
            this.buttonLastest1.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest1.TabIndex = 0;
            this.buttonLastest1.Text = "Save";
            this.buttonLastest1.UseVisualStyleBackColor = false;
            this.buttonLastest1.Click += new System.EventHandler(this.buttonLastest1_Click);
            // 
            // buttonLastest5
            // 
            this.buttonLastest5.BackColor = System.Drawing.Color.White;
            this.buttonLastest5.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest5.FlatAppearance.BorderSize = 5;
            this.buttonLastest5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.buttonLastest5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonLastest5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest5.Location = new System.Drawing.Point(125, 450);
            this.buttonLastest5.Name = "buttonLastest5";
            this.buttonLastest5.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest5.TabIndex = 22;
            this.buttonLastest5.Text = "Delete";
            this.buttonLastest5.UseVisualStyleBackColor = false;
            this.buttonLastest5.Click += new System.EventHandler(this.buttonLastest3_Click);
            // 
            // labelGradient2
            // 
            this.labelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.Black;
            this.labelGradient2.Location = new System.Drawing.Point(-6, -6);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelGradient2.Size = new System.Drawing.Size(514, 57);
            this.labelGradient2.TabIndex = 30;
            this.labelGradient2.Text = "Pay Periods List";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPayPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(508, 496);
            this.Controls.Add(this.labelGradient2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dteTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dteFrom);
            this.Controls.Add(this.buttonLastest5);
            this.Controls.Add(this.buttonLastest2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtPayPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonLastest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmPayPeriod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Periods List";
            this.Load += new System.EventHandler(this.frmPayPeriod_Load);
            this.Shown += new System.EventHandler(this.frmPayPeriod_Shown);
            this.Resize += new System.EventHandler(this.frmPayPeriod_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonLastest buttonLastest1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPayPeriod;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private ButtonLastest buttonLastest2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dteFrom;
        private System.Windows.Forms.DateTimePicker dteTo;
        private System.Windows.Forms.Label label5;
        private ButtonLastest buttonLastest5;
        private LabelGradient labelGradient2;
    }
}