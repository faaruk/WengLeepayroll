namespace WengLeePayroll
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.lvImportedFiles = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPayPeriod = new System.Windows.Forms.ComboBox();
            this.buttonLastest5 = new WengLeePayroll.ButtonLastest();
            this.labelGradient2 = new WengLeePayroll.LabelGradient();
            this.buttonLastest1 = new WengLeePayroll.ButtonLastest();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.labelGradient1 = new WengLeePayroll.LabelGradient();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Pay Period:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(698, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Progress...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 544);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1099, 50);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(40, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select Import File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lvImportedFiles
            // 
            this.lvImportedFiles.Location = new System.Drawing.Point(394, 101);
            this.lvImportedFiles.Name = "lvImportedFiles";
            this.lvImportedFiles.Size = new System.Drawing.Size(718, 391);
            this.lvImportedFiles.TabIndex = 10;
            this.lvImportedFiles.UseCompatibleStateImageBehavior = false;
            this.lvImportedFiles.SelectedIndexChanged += new System.EventHandler(this.lvImportedFiles_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Imported File List";
            // 
            // cmbPayPeriod
            // 
            this.cmbPayPeriod.DisplayMember = "EmpID";
            this.cmbPayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayPeriod.FormattingEnabled = true;
            this.cmbPayPeriod.Location = new System.Drawing.Point(137, 101);
            this.cmbPayPeriod.Name = "cmbPayPeriod";
            this.cmbPayPeriod.Size = new System.Drawing.Size(230, 21);
            this.cmbPayPeriod.TabIndex = 32;
            this.cmbPayPeriod.ValueMember = "EmpID";
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
            this.buttonLastest5.Location = new System.Drawing.Point(394, 498);
            this.buttonLastest5.Name = "buttonLastest5";
            this.buttonLastest5.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest5.TabIndex = 34;
            this.buttonLastest5.Text = "Delete";
            this.buttonLastest5.UseVisualStyleBackColor = false;
            this.buttonLastest5.Click += new System.EventHandler(this.buttonLastest5_Click);
            // 
            // labelGradient2
            // 
            this.labelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.Black;
            this.labelGradient2.Location = new System.Drawing.Point(-2, -3);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelGradient2.Size = new System.Drawing.Size(1120, 57);
            this.labelGradient2.TabIndex = 33;
            this.labelGradient2.Text = "Import Hours";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLastest1
            // 
            this.buttonLastest1.BackColor = System.Drawing.Color.White;
            this.buttonLastest1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest1.FlatAppearance.BorderSize = 5;
            this.buttonLastest1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest1.Location = new System.Drawing.Point(73, 305);
            this.buttonLastest1.Name = "buttonLastest1";
            this.buttonLastest1.Size = new System.Drawing.Size(225, 56);
            this.buttonLastest1.TabIndex = 31;
            this.buttonLastest1.Text = "Browse for Import File";
            this.buttonLastest1.UseVisualStyleBackColor = false;
            this.buttonLastest1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.labelGradient1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(199, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 368);
            this.panel1.TabIndex = 35;
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(767, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelGradient1
            // 
            this.labelGradient1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.Lime;
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.Black;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelGradient1.Size = new System.Drawing.Size(800, 49);
            this.labelGradient1.TabIndex = 34;
            this.labelGradient1.Text = "List of new employee(s) imported";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(795, 296);
            this.dataGridView1.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(368, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 36;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 601);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLastest5);
            this.Controls.Add(this.labelGradient2);
            this.Controls.Add(this.cmbPayPeriod);
            this.Controls.Add(this.buttonLastest1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvImportedFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvImportedFiles;
        private System.Windows.Forms.Label label3;
        private ButtonLastest buttonLastest1;
        private System.Windows.Forms.ComboBox cmbPayPeriod;
        private LabelGradient labelGradient2;
        private ButtonLastest buttonLastest5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private LabelGradient labelGradient1;
        private System.Windows.Forms.Button button3;
    }
}