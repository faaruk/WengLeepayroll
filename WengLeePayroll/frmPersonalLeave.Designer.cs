namespace WengLeePayroll
{
    partial class frmPersonalLeave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonalLeave));
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayPeriod = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dteRequestDate = new System.Windows.Forms.DateTimePicker();
            this.rdoDatewise = new System.Windows.Forms.RadioButton();
            this.rdoByHour = new System.Windows.Forms.RadioButton();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dteToDate = new System.Windows.Forms.DateTimePicker();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbWC = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.labelGradient2 = new WengLeePayroll.LabelGradient();
            this.buttonLastest5 = new WengLeePayroll.ButtonLastest();
            this.buttonLastest4 = new WengLeePayroll.ButtonLastest();
            this.buttonLastest1 = new WengLeePayroll.ButtonLastest();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Leave Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 133);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Comments:";
            // 
            // txtPayPeriod
            // 
            this.txtPayPeriod.Location = new System.Drawing.Point(146, 207);
            this.txtPayPeriod.Multiline = true;
            this.txtPayPeriod.Name = "txtPayPeriod";
            this.txtPayPeriod.Size = new System.Drawing.Size(477, 68);
            this.txtPayPeriod.TabIndex = 17;
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
            this.dataGridView1.Location = new System.Drawing.Point(9, 327);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(614, 218);
            this.dataGridView1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Employee:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "EmpID";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(146, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 31;
            this.comboBox1.ValueMember = "EmpID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Leave Type:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DisplayMember = "EmpID";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(146, 157);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(118, 21);
            this.cmbStatus.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Request Date:";
            // 
            // dteRequestDate
            // 
            this.dteRequestDate.CustomFormat = "MM/dd/yyyy";
            this.dteRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRequestDate.Location = new System.Drawing.Point(146, 84);
            this.dteRequestDate.Name = "dteRequestDate";
            this.dteRequestDate.Size = new System.Drawing.Size(92, 20);
            this.dteRequestDate.TabIndex = 35;
            // 
            // rdoDatewise
            // 
            this.rdoDatewise.AutoSize = true;
            this.rdoDatewise.BackColor = System.Drawing.Color.Transparent;
            this.rdoDatewise.Checked = true;
            this.rdoDatewise.Location = new System.Drawing.Point(140, 60);
            this.rdoDatewise.Name = "rdoDatewise";
            this.rdoDatewise.Size = new System.Drawing.Size(63, 17);
            this.rdoDatewise.TabIndex = 37;
            this.rdoDatewise.TabStop = true;
            this.rdoDatewise.Text = "By Date";
            this.rdoDatewise.UseVisualStyleBackColor = false;
            this.rdoDatewise.CheckedChanged += new System.EventHandler(this.rdoDatewise_CheckedChanged);
            // 
            // rdoByHour
            // 
            this.rdoByHour.AutoSize = true;
            this.rdoByHour.BackColor = System.Drawing.Color.Transparent;
            this.rdoByHour.Location = new System.Drawing.Point(241, 60);
            this.rdoByHour.Name = "rdoByHour";
            this.rdoByHour.Size = new System.Drawing.Size(63, 17);
            this.rdoByHour.TabIndex = 38;
            this.rdoByHour.Text = "By Hour";
            this.rdoByHour.UseVisualStyleBackColor = false;
            this.rdoByHour.CheckedChanged += new System.EventHandler(this.rdoByHour_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(252, 135);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(32, 17);
            this.lblToDate.TabIndex = 40;
            this.lblToDate.Text = "To:";
            // 
            // dteToDate
            // 
            this.dteToDate.CustomFormat = "MM/dd/yyyy";
            this.dteToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteToDate.Location = new System.Drawing.Point(288, 133);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(92, 20);
            this.dteToDate.TabIndex = 39;
            this.dteToDate.ValueChanged += new System.EventHandler(this.dteToDate_ValueChanged);
            // 
            // txtHours
            // 
            this.txtHours.BackColor = System.Drawing.SystemColors.Window;
            this.txtHours.Enabled = false;
            this.txtHours.Location = new System.Drawing.Point(568, 139);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(55, 20);
            this.txtHours.TabIndex = 41;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHours_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(507, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Hours:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Workers Comp:";
            // 
            // cmbWC
            // 
            this.cmbWC.DisplayMember = "EmpID";
            this.cmbWC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWC.FormattingEnabled = true;
            this.cmbWC.Location = new System.Drawing.Point(146, 182);
            this.cmbWC.Name = "cmbWC";
            this.cmbWC.Size = new System.Drawing.Size(118, 21);
            this.cmbWC.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(387, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "NB: a day is counted as 8 hours";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.BackColor = System.Drawing.Color.Transparent;
            this.lblDays.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(387, 135);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(49, 17);
            this.lblDays.TabIndex = 47;
            this.lblDays.Text = "Days:";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtDays.Enabled = false;
            this.txtDays.Location = new System.Drawing.Point(437, 133);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(61, 20);
            this.txtDays.TabIndex = 46;
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblPayPeriod.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayPeriod.Location = new System.Drawing.Point(270, 161);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(353, 42);
            this.lblPayPeriod.TabIndex = 48;
            this.lblPayPeriod.Text = "Leave Type:";
            this.lblPayPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.labelGradient2.Size = new System.Drawing.Size(638, 57);
            this.labelGradient2.TabIndex = 30;
            this.labelGradient2.Text = "Manage Time Off";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLastest5
            // 
            this.buttonLastest5.BackColor = System.Drawing.Color.White;
            this.buttonLastest5.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest5.FlatAppearance.BorderSize = 5;
            this.buttonLastest5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest5.Location = new System.Drawing.Point(121, 551);
            this.buttonLastest5.Name = "buttonLastest5";
            this.buttonLastest5.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest5.TabIndex = 22;
            this.buttonLastest5.Text = "Delete";
            this.buttonLastest5.UseVisualStyleBackColor = false;
            this.buttonLastest5.Click += new System.EventHandler(this.buttonLastest3_Click);
            // 
            // buttonLastest4
            // 
            this.buttonLastest4.BackColor = System.Drawing.Color.White;
            this.buttonLastest4.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest4.FlatAppearance.BorderSize = 5;
            this.buttonLastest4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest4.Location = new System.Drawing.Point(7, 551);
            this.buttonLastest4.Name = "buttonLastest4";
            this.buttonLastest4.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest4.TabIndex = 21;
            this.buttonLastest4.Text = "Edit";
            this.buttonLastest4.UseVisualStyleBackColor = false;
            this.buttonLastest4.Click += new System.EventHandler(this.buttonLastest2_Click);
            // 
            // buttonLastest1
            // 
            this.buttonLastest1.BackColor = System.Drawing.Color.White;
            this.buttonLastest1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest1.FlatAppearance.BorderSize = 5;
            this.buttonLastest1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest1.Location = new System.Drawing.Point(144, 281);
            this.buttonLastest1.Name = "buttonLastest1";
            this.buttonLastest1.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest1.TabIndex = 0;
            this.buttonLastest1.Text = "Add";
            this.buttonLastest1.UseVisualStyleBackColor = false;
            this.buttonLastest1.Click += new System.EventHandler(this.buttonLastest1_Click);
            // 
            // frmPersonalLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(629, 595);
            this.Controls.Add(this.lblPayPeriod);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbWC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dteToDate);
            this.Controls.Add(this.rdoByHour);
            this.Controls.Add(this.rdoDatewise);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dteRequestDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelGradient2);
            this.Controls.Add(this.buttonLastest5);
            this.Controls.Add(this.buttonLastest4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtPayPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonLastest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalLeave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmPayPeriod_Load);
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
        private ButtonLastest buttonLastest4;
        private ButtonLastest buttonLastest5;
        private LabelGradient labelGradient2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteRequestDate;
        private System.Windows.Forms.RadioButton rdoDatewise;
        private System.Windows.Forms.RadioButton rdoByHour;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dteToDate;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}