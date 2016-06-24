namespace WengLeePayroll
{
    partial class ManageEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEmployee));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtDependents = new System.Windows.Forms.TextBox();
            this.txtOT1 = new System.Windows.Forms.TextBox();
            this.txtOT2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dteJoin = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dteBirth = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbClock = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdMaritarialStatus = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dteStartTime = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbEmployementType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTerminiationDate = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new WengLeePayroll.ButtonLastest();
            this.labelGradient1 = new WengLeePayroll.LabelGradient();
            this.cmdDelete = new WengLeePayroll.ButtonLastest();
            this.buttonLastest4 = new WengLeePayroll.ButtonLastest();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbHealthInsurance = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dteHIEligibilityDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDriversLicense = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtHIJoinDate = new System.Windows.Forms.TextBox();
            this.txtDriversLicenseDateOfExpiration = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSearchInStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Department:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DisplayMember = "EmpID";
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(169, 127);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(215, 21);
            this.cmbDepartment.TabIndex = 6;
            this.cmbDepartment.ValueMember = "EmpID";
            // 
            // txtDependents
            // 
            this.txtDependents.Location = new System.Drawing.Point(1000, 693);
            this.txtDependents.Name = "txtDependents";
            this.txtDependents.Size = new System.Drawing.Size(165, 20);
            this.txtDependents.TabIndex = 11;
            this.txtDependents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDependents.Visible = false;
            this.txtDependents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReg_KeyPress);
            // 
            // txtOT1
            // 
            this.txtOT1.Location = new System.Drawing.Point(1224, 669);
            this.txtOT1.Name = "txtOT1";
            this.txtOT1.Size = new System.Drawing.Size(100, 20);
            this.txtOT1.TabIndex = 17;
            this.txtOT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOT1.Visible = false;
            this.txtOT1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOT1_KeyPress);
            // 
            // txtOT2
            // 
            this.txtOT2.Location = new System.Drawing.Point(1224, 692);
            this.txtOT2.Name = "txtOT2";
            this.txtOT2.Size = new System.Drawing.Size(100, 20);
            this.txtOT2.TabIndex = 18;
            this.txtOT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOT2.Visible = false;
            this.txtOT2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOT2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1156, 695);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "OT 2:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1156, 672);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "OT 1:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(870, 695);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "W4 Dependents:";
            this.label5.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(651, 670);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(99, 29);
            this.cmdSave.TabIndex = 22;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(5, 308);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1340, 356);
            this.dataGridView1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Job Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DisplayMember = "EmpID";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(169, 178);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(215, 21);
            this.cmbStatus.TabIndex = 12;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(169, 76);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(215, 20);
            this.txtId.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Id.:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(544, 76);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(214, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(398, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "First Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(958, 76);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(215, 20);
            this.txtLastName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(771, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "Last Name:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(398, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 17);
            this.label9.TabIndex = 38;
            this.label9.Text = "Designation:";
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DisplayMember = "EmpID";
            this.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Location = new System.Drawing.Point(544, 127);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(214, 21);
            this.cmbDesignation.TabIndex = 7;
            this.cmbDesignation.ValueMember = "EmpID";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 17);
            this.label10.TabIndex = 40;
            this.label10.Text = "Date of Hire:";
            // 
            // dteJoin
            // 
            this.dteJoin.CustomFormat = "MM/dd/yyyy";
            this.dteJoin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteJoin.Location = new System.Drawing.Point(169, 152);
            this.dteJoin.Name = "dteJoin";
            this.dteJoin.Size = new System.Drawing.Size(215, 20);
            this.dteJoin.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(771, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 17);
            this.label11.TabIndex = 42;
            this.label11.Text = "Date of Birth:";
            // 
            // dteBirth
            // 
            this.dteBirth.CustomFormat = "MM/dd/yyyy";
            this.dteBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteBirth.Location = new System.Drawing.Point(958, 101);
            this.dteBirth.Name = "dteBirth";
            this.dteBirth.Size = new System.Drawing.Size(215, 20);
            this.dteBirth.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(947, 669);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 17);
            this.label12.TabIndex = 44;
            this.label12.Text = "Clock:";
            this.label12.Visible = false;
            // 
            // cmbClock
            // 
            this.cmbClock.DisplayMember = "EmpID";
            this.cmbClock.FormattingEnabled = true;
            this.cmbClock.Location = new System.Drawing.Point(1000, 667);
            this.cmbClock.Name = "cmbClock";
            this.cmbClock.Size = new System.Drawing.Size(183, 21);
            this.cmbClock.TabIndex = 8;
            this.cmbClock.ValueMember = "EmpID";
            this.cmbClock.Visible = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 17);
            this.label13.TabIndex = 47;
            this.label13.Text = "Gender:";
            // 
            // cmbGender
            // 
            this.cmbGender.DisplayMember = "EmpID";
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(169, 101);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(215, 21);
            this.cmbGender.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(398, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 17);
            this.label14.TabIndex = 49;
            this.label14.Text = "Marital Status:";
            // 
            // cmdMaritarialStatus
            // 
            this.cmdMaritarialStatus.DisplayMember = "EmpID";
            this.cmdMaritarialStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdMaritarialStatus.FormattingEnabled = true;
            this.cmdMaritarialStatus.Location = new System.Drawing.Point(544, 101);
            this.cmdMaritarialStatus.Name = "cmdMaritarialStatus";
            this.cmdMaritarialStatus.Size = new System.Drawing.Size(214, 21);
            this.cmdMaritarialStatus.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(398, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 17);
            this.label15.TabIndex = 51;
            this.label15.Text = "Start Time:";
            // 
            // dteStartTime
            // 
            this.dteStartTime.CustomFormat = "";
            this.dteStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dteStartTime.Location = new System.Drawing.Point(544, 154);
            this.dteStartTime.Name = "dteStartTime";
            this.dteStartTime.Size = new System.Drawing.Size(214, 20);
            this.dteStartTime.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 206);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 17);
            this.label16.TabIndex = 53;
            this.label16.Text = "Payroll Hours Type:";
            // 
            // cmbEmployementType
            // 
            this.cmbEmployementType.DisplayMember = "EmpID";
            this.cmbEmployementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployementType.FormattingEnabled = true;
            this.cmbEmployementType.Location = new System.Drawing.Point(169, 203);
            this.cmbEmployementType.Name = "cmbEmployementType";
            this.cmbEmployementType.Size = new System.Drawing.Size(215, 21);
            this.cmbEmployementType.TabIndex = 14;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(148, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(6, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(140, 19);
            this.label17.TabIndex = 55;
            this.label17.Text = "Type here to Search:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // txtTerminiationDate
            // 
            this.txtTerminiationDate.Location = new System.Drawing.Point(544, 180);
            this.txtTerminiationDate.Name = "txtTerminiationDate";
            this.txtTerminiationDate.Size = new System.Drawing.Size(214, 20);
            this.txtTerminiationDate.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(398, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(141, 17);
            this.label18.TabIndex = 57;
            this.label18.Text = "Termination Date:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(12, 669);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 49);
            this.panel1.TabIndex = 58;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 5;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 40);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // labelGradient1
            // 
            this.labelGradient1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.Black;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelGradient1.Size = new System.Drawing.Size(1350, 57);
            this.labelGradient1.TabIndex = 28;
            this.labelGradient1.Text = "Employee List";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.White;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmdDelete.FlatAppearance.BorderSize = 5;
            this.cmdDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.cmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdDelete.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmdDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.cmdDelete.Location = new System.Drawing.Point(242, 673);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(108, 40);
            this.cmdDelete.TabIndex = 18;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.buttonLastest5_Click);
            // 
            // buttonLastest4
            // 
            this.buttonLastest4.BackColor = System.Drawing.Color.White;
            this.buttonLastest4.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest4.FlatAppearance.BorderSize = 5;
            this.buttonLastest4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.buttonLastest4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonLastest4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest4.Location = new System.Drawing.Point(128, 673);
            this.buttonLastest4.Name = "buttonLastest4";
            this.buttonLastest4.Size = new System.Drawing.Size(108, 40);
            this.buttonLastest4.TabIndex = 17;
            this.buttonLastest4.Text = "Edit";
            this.buttonLastest4.UseVisualStyleBackColor = false;
            this.buttonLastest4.Click += new System.EventHandler(this.buttonLastest4_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(771, 126);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(181, 17);
            this.label19.TabIndex = 60;
            this.label19.Text = "Health Insurance:";
            // 
            // cmbHealthInsurance
            // 
            this.cmbHealthInsurance.DisplayMember = "EmpID";
            this.cmbHealthInsurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHealthInsurance.FormattingEnabled = true;
            this.cmbHealthInsurance.Location = new System.Drawing.Point(958, 126);
            this.cmbHealthInsurance.Name = "cmbHealthInsurance";
            this.cmbHealthInsurance.Size = new System.Drawing.Size(215, 21);
            this.cmbHealthInsurance.TabIndex = 59;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(771, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(181, 17);
            this.label20.TabIndex = 62;
            this.label20.Text = "HI Eligibility Date:";
            // 
            // dteHIEligibilityDate
            // 
            this.dteHIEligibilityDate.CustomFormat = "MM/dd/yyyy";
            this.dteHIEligibilityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteHIEligibilityDate.Location = new System.Drawing.Point(958, 153);
            this.dteHIEligibilityDate.Name = "dteHIEligibilityDate";
            this.dteHIEligibilityDate.Size = new System.Drawing.Size(215, 20);
            this.dteHIEligibilityDate.TabIndex = 61;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(771, 179);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(181, 17);
            this.label21.TabIndex = 64;
            this.label21.Text = "HI Join Date:";
            // 
            // txtDriversLicense
            // 
            this.txtDriversLicense.Location = new System.Drawing.Point(544, 207);
            this.txtDriversLicense.Name = "txtDriversLicense";
            this.txtDriversLicense.Size = new System.Drawing.Size(214, 20);
            this.txtDriversLicense.TabIndex = 65;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(398, 209);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(141, 17);
            this.label22.TabIndex = 66;
            this.label22.Text = "Drivers License:";
            // 
            // txtHIJoinDate
            // 
            this.txtHIJoinDate.Location = new System.Drawing.Point(958, 179);
            this.txtHIJoinDate.Name = "txtHIJoinDate";
            this.txtHIJoinDate.Size = new System.Drawing.Size(215, 20);
            this.txtHIJoinDate.TabIndex = 67;
            // 
            // txtDriversLicenseDateOfExpiration
            // 
            this.txtDriversLicenseDateOfExpiration.Location = new System.Drawing.Point(958, 206);
            this.txtDriversLicenseDateOfExpiration.Name = "txtDriversLicenseDateOfExpiration";
            this.txtDriversLicenseDateOfExpiration.Size = new System.Drawing.Size(215, 20);
            this.txtDriversLicenseDateOfExpiration.TabIndex = 69;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(771, 206);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(181, 17);
            this.label23.TabIndex = 68;
            this.label23.Text = "Dri. Lic. Expiration Date:";
            // 
            // txtSSN
            // 
            this.txtSSN.Location = new System.Drawing.Point(169, 229);
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(215, 20);
            this.txtSSN.TabIndex = 70;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(14, 230);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(155, 17);
            this.label24.TabIndex = 71;
            this.label24.Text = "Last 4 digits of SSN:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbSearchInStatus);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(712, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 58);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cmbSearchInStatus
            // 
            this.cmbSearchInStatus.DisplayMember = "EmpID";
            this.cmbSearchInStatus.FormattingEnabled = true;
            this.cmbSearchInStatus.Location = new System.Drawing.Point(354, 22);
            this.cmbSearchInStatus.Name = "cmbSearchInStatus";
            this.cmbSearchInStatus.Size = new System.Drawing.Size(100, 27);
            this.cmbSearchInStatus.TabIndex = 56;
            this.cmbSearchInStatus.SelectedIndexChanged += new System.EventHandler(this.cmbSearchInStatus_SelectedIndexChanged);
            // 
            // ManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 719);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.txtDriversLicenseDateOfExpiration);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtHIJoinDate);
            this.Controls.Add(this.txtDriversLicense);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dteHIEligibilityDate);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbHealthInsurance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTerminiationDate);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbEmployementType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dteStartTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdMaritarialStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.cmbClock);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dteBirth);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dteJoin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbDesignation);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelGradient1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.buttonLastest4);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOT2);
            this.Controls.Add(this.txtOT1);
            this.Controls.Add(this.txtDependents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDepartment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ManageEmployee";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee List";
            this.MinimumSizeChanged += new System.EventHandler(this.ManageEmployee_MinimumSizeChanged);
            this.Load += new System.EventHandler(this.SalariedEmpTime_Load);
            this.Shown += new System.EventHandler(this.ManageEmployee_Shown);
            this.Resize += new System.EventHandler(this.ManageEmployee_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtDependents;
        private System.Windows.Forms.TextBox txtOT1;
        private System.Windows.Forms.TextBox txtOT2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdSave;
        private ButtonLastest cmdDelete;
        private ButtonLastest buttonLastest4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private LabelGradient labelGradient1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDesignation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dteJoin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dteBirth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbClock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmdMaritarialStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dteStartTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbEmployementType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTerminiationDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private ButtonLastest btnSave;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbHealthInsurance;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dteHIEligibilityDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDriversLicense;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtHIJoinDate;
        private System.Windows.Forms.TextBox txtDriversLicenseDateOfExpiration;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSearchInStatus;
    }
}