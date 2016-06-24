using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace WengLeePayroll
{
    public partial class ManageEmployee : Form
    {

        string TemplateAutoId = "";
        public ManageEmployee()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.Silver,
                                                                       Color.Tan,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void SalariedEmpTime_Load(object sender, EventArgs e)
        {
            try
            {
                mfillCombo();
                FillStaticOption();
                getImportedFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }
        private void getImportedFileList()
        {
            showdata();
        }
        // Initialize ListView

        // Load Data from the DataSet into the ListView
        private void showdata()
        {
            DataTable dt = new DataTable();
            ReadData objRD = new ReadData();
            dt = objRD.GetEmployees();
            dataGridView1.DataSource = dt;
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[1].Width = 60;
            //dataGridView1.Columns[2].Width = 165;
            //dataGridView1.Columns[3].Width = 50;
            //dataGridView1.Columns[4].Width = 50;
            //dataGridView1.Columns[5].Width = 50;

        }
        private void mfillCombo()
        {
            ReadData objRD = new ReadData();
            DataTable dt = objRD.GetDegination();
            cmbDesignation.DisplayMember = "DesignationDesc";
            cmbDesignation.ValueMember = "DesignationId";
            cmbDesignation.DataSource = dt;

            dt = objRD.GetDepartment();
            cmbDepartment.DisplayMember = "DepartmentDesc";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = dt;

            dt = objRD.GetClock();
            cmbClock.DisplayMember = "ClockDesc";
            cmbClock.ValueMember = "ClockId";
            cmbClock.DataSource = dt;

        }
        private void FillStaticOption()
        {
            Dictionary<string, string> ComboOptions = new Dictionary<string, string>();

            ComboOptions.Clear();
            ComboOptions.Add("1", "Active");
            ComboOptions.Add("0", "Inactive");
            cmbStatus.DataSource = new BindingSource(ComboOptions, null);
            cmbStatus.DisplayMember = "Value";
            cmbStatus.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("M", "Married");
            ComboOptions.Add("S", "Single");
            cmdMaritarialStatus.DataSource = new BindingSource(ComboOptions, null);
            cmdMaritarialStatus.DisplayMember = "Value";
            cmdMaritarialStatus.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("M", "Male");
            ComboOptions.Add("F", "Female");
            cmbGender.DataSource = new BindingSource(ComboOptions, null);
            cmbGender.DisplayMember = "Value";
            cmbGender.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("0", "Hourly");
            ComboOptions.Add("1", "Fixed");
            cmbEmployementType.DataSource = new BindingSource(ComboOptions, null);
            cmbEmployementType.DisplayMember = "Value";
            cmbEmployementType.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("1", "Enrolled");
            ComboOptions.Add("0", "Declined");
            cmbHealthInsurance.DataSource = new BindingSource(ComboOptions, null);
            cmbHealthInsurance.DisplayMember = "Value";
            cmbHealthInsurance.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("1", "Active");
            ComboOptions.Add("0", "Inactive");
            ComboOptions.Add("2", "Both");
            cmbSearchInStatus.DataSource = new BindingSource(ComboOptions, null);
            cmbSearchInStatus.DisplayMember = "Value";
            cmbSearchInStatus.ValueMember = "Key";

            
        }
        private void txtReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtOT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtOT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime processDate = System.DateTime.Today;
                string strprocessDate1 = processDate.ToShortDateString();
                string strEmpID = "0";
                if (cmbDepartment.SelectedValue != null)
                {
                    strEmpID = cmbDepartment.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select an Employee");
                    return;
                }
                string strRegularHours = txtDependents.Text;
                if (strRegularHours.Trim() == "") strRegularHours = "0";
                string strOT1 = txtOT1.Text;
                if (strOT1.Trim() == "") strOT1 = "0";
                string strOT2 = txtOT2.Text;
                if (strOT2.Trim() == "") strOT2 = "0";

                SaveData objSD = new SaveData();
                objSD.SaveSalariedData(Int32.Parse(strEmpID), strRegularHours, strOT1, strOT2, strprocessDate1);
                txtDependents.Text = "";
                txtOT1.Text = "";
                txtOT2.Text = "";
                getImportedFileList();
                MessageBox.Show("Save Successful.");
                cmbDepartment.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonLastest4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            TemplateAutoId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtId.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtFirstName.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

            string strDropDown = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cmbGender.SelectedIndex = cmbGender.FindString(strDropDown);
            strDropDown = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cmdMaritarialStatus.SelectedIndex = cmdMaritarialStatus.FindString(strDropDown);
            dteBirth.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            
            strDropDown = dataGridView1.Rows[i].Cells[7].Value.ToString();
            cmbDepartment.SelectedIndex = cmbDepartment.FindString(strDropDown);
            strDropDown = dataGridView1.Rows[i].Cells[8].Value.ToString();
            cmbDesignation.SelectedIndex = cmbDesignation.FindString(strDropDown);
            strDropDown = dataGridView1.Rows[i].Cells[9].Value.ToString();
            cmbClock.SelectedIndex = cmbClock.FindString(strDropDown);

            dteJoin.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            dteStartTime.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            //txtDependents.Text = dataGridView1.Rows[i].Cells[12].Value.ToString();

            strDropDown = dataGridView1.Rows[i].Cells[11].Value.ToString();
            cmbStatus.SelectedIndex = cmbStatus.FindString(strDropDown);
            strDropDown = dataGridView1.Rows[i].Cells[12].Value.ToString();
            cmbEmployementType.SelectedIndex = cmbEmployementType.FindString(strDropDown);
            txtTerminiationDate.Text = dataGridView1.Rows[i].Cells[13].Value.ToString();

            strDropDown = dataGridView1.Rows[i].Cells[14].Value.ToString();
            cmbHealthInsurance.SelectedIndex = cmbHealthInsurance.FindString(strDropDown);
            dteHIEligibilityDate.Text = dataGridView1.Rows[i].Cells[15].Value.ToString();
            txtHIJoinDate.Text = dataGridView1.Rows[i].Cells[16].Value.ToString();
            txtDriversLicense.Text = dataGridView1.Rows[i].Cells[17].Value.ToString();
            txtDriversLicenseDateOfExpiration.Text = dataGridView1.Rows[i].Cells[18].Value.ToString();
            txtSSN.Text = dataGridView1.Rows[i].Cells[19].Value.ToString();

            btnSave.Text = "Update";
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            TemplateAutoId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (TemplateAutoId != "")
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the Employee - " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeleteEmployee(TemplateAutoId);
                    showdata();
                    MessageBox.Show("Delete Successful.");
                }
                //else
                //{
                //    // If 'No', do something here.
                //}

            }
            else
            {
                MessageBox.Show("Please select a row to Delete.");
            }
            TemplateAutoId = "";
        }

        private void buttonLastest1_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            int rowIndex = 1;  //this one is depending on the position of cell or column
            //string first_row_data=dataGridView1.Rows[0].Cells[0].Value.ToString() ;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResulet = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[rowIndex].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dataGridView1.Rows[rowIndex].Selected = true;
                        rowIndex++;
                        valueResulet = false;
                    }
                }
                if (valueResulet != false)
                {
                    MessageBox.Show("Record is not avalable for this Name " + txtSearch.Text, "Not Found");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string strSearchInStatus = "2";
            if (cmbSearchInStatus.SelectedValue != null)
            {
                strSearchInStatus = cmbSearchInStatus.SelectedValue.ToString();
            }
            DataTable dt = new DataTable();
            ReadData objRD = new ReadData();
            dt = objRD.SearchEmployees(txtSearch.Text, strSearchInStatus);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
        }

        private void ManageEmployee_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 465;
            labelGradient1.Width = this.Width + 10;
            buttonLastest4.Top =dataGridView1.Top+ dataGridView1.Height + 2;
            cmdDelete.Top = dataGridView1.Top + dataGridView1.Height + 2;
            panel1.Top = dataGridView1.Top + dataGridView1.Height + 2;
            this.Invalidate();
        }

        private void ManageEmployee_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strEmpID = "0"; string strFirstName = "0"; string strLastName = "0"; string strDepartmentID = "0"; string strGender = "0"; string strMaritial = "0"; string strDesignation = "0";
                string strJobStatus = "0"; string strEmploymentType = ""; string strClock = ""; string strLastDay = "";
                if (txtId.Text.Length != 0)
                {
                    strEmpID = txtId.Text;
                }
                else
                {
                    MessageBox.Show("Please select enter Employee Id.");
                    return;
                }
                if (txtFirstName.Text.Length != 0)
                {
                    strFirstName = txtFirstName.Text;
                }
                else
                {
                    MessageBox.Show("Please enter First Name.");
                    return;
                }
                if (txtLastName.Text.Length != 0)
                {
                    strLastName = txtLastName.Text;
                }
                else
                {
                    MessageBox.Show("Please enter Last Name.");
                    return;
                }
                if (txtTerminiationDate.Text.Length != 0)
                {
                    strLastDay = txtTerminiationDate.Text;
                }

                if (cmbGender.SelectedValue != null)
                {
                    strGender = cmbGender.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Gender");
                    return;
                }
                if (cmdMaritarialStatus.SelectedValue != null)
                {
                    strMaritial = cmdMaritarialStatus.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Maritarial Status");
                    return;
                }
                if (cmbDepartment.SelectedValue != null)
                {
                    strDepartmentID = cmbDepartment.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select a Department");
                    return;
                }
                if (cmbDesignation.SelectedValue != null)
                {
                    strDesignation = cmbDesignation.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Designation");
                    return;
                }
                if (cmbStatus.SelectedValue != null)
                {
                    strJobStatus = cmbStatus.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Job Status");
                    return;
                }
                if (cmbEmployementType.SelectedValue != null)
                {
                    strEmploymentType = cmbEmployementType.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Employment Type");
                    return;
                }
                strClock = "3";
                //if (cmbClock.SelectedValue != null)
                //{
                //    strClock = cmbClock.SelectedValue.ToString();
                //}
                //else
                //{
                //    MessageBox.Show("Please select Clock Type");
                //    return;
                //}
                
                

                DateTime processDate = dteBirth.Value;
                string strBirthDate = processDate.ToShortDateString();
                processDate = dteJoin.Value; ;
                string strJoinDate = processDate.ToShortDateString();
                processDate = dteStartTime.Value; ;
                string strStartTime = processDate.ToString();

                string strDependents = txtDependents.Text;
                if (strDependents.Trim() == "") strDependents = "0";
                string strOT1 = txtOT1.Text;
                if (strOT1.Trim() == "") strOT1 = "0";
                string strOT2 = txtOT2.Text;
                if (strOT2.Trim() == "") strOT2 = "0";
                
                string HealthInsurance = "0"; string HIEligibilityDate = ""; string HIJoinDate = ""; string DriversLicense = ""; string DriversLicenseDateOfExpiration = ""; string SSN;
                if (cmbHealthInsurance.SelectedValue != null)
                {
                    HealthInsurance = cmbHealthInsurance.SelectedValue.ToString();
                }
                processDate = dteHIEligibilityDate.Value;
                HIEligibilityDate = processDate.ToShortDateString();
                HIJoinDate = txtHIJoinDate.Text;
                DriversLicense = txtDriversLicense.Text;
                DriversLicenseDateOfExpiration = txtDriversLicenseDateOfExpiration.Text;
                SSN = txtSSN.Text;

                if (TemplateAutoId == "")
                {
                    SaveData objSD = new SaveData();
                    objSD.SaveEmployee(strEmpID, strStartTime, strJoinDate, strJobStatus, strGender, strBirthDate, strMaritial, strDependents, strFirstName,
                    strLastName, strDepartmentID, strDesignation, strClock, strEmploymentType, strLastDay,
                    HealthInsurance, HIEligibilityDate, HIJoinDate, DriversLicense, DriversLicenseDateOfExpiration, SSN);
                    MessageBox.Show("Save Successful.");
                }
                else
                {
                    SaveData objSD = new SaveData();

                    objSD.UpdateEmployee(TemplateAutoId, strEmpID, strStartTime, strJoinDate, strJobStatus, strGender, strBirthDate, strMaritial, strDependents, strFirstName,
                    strLastName, strDepartmentID, strDesignation, strClock, strEmploymentType, strLastDay,
                    HealthInsurance, HIEligibilityDate, HIJoinDate, DriversLicense, DriversLicenseDateOfExpiration, SSN);
                    MessageBox.Show("Update Successful.");
                }
                TemplateAutoId = "";
                btnSave.Text = "Save";
                txtId.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtTerminiationDate.Text = "";
                txtDependents.Text = "";

                getImportedFileList();
                cmbDepartment.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }
       

        private void ManageEmployee_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void cmbSearchInStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSearchInStatus = "2";
            if (cmbSearchInStatus.SelectedValue != null)
            {
                strSearchInStatus = cmbSearchInStatus.SelectedValue.ToString();
            }
            DataTable dt = new DataTable();
            ReadData objRD = new ReadData();
            dt = objRD.SearchEmployees(txtSearch.Text, strSearchInStatus);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
        }

    }

}
