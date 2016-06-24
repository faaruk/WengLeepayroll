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
    public partial class ManageUser : Form
    {
        
        string TemplateAutoId = "";
        public ManageUser()
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
            mfillCombo();
            getImportedFileList();
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
            dt = objRD.GetUsers();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;

            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].Width = 50;
            dataGridView1.Columns[10].Width = 50;
            dataGridView1.Columns[11].Width = 50;
            
        }
        private void mfillCombo()
        {
            try
            {
                Dictionary<string, string> ComboOptions = new Dictionary<string, string>();

                ComboOptions.Clear();
                ComboOptions.Add("1", "Admin");
                ComboOptions.Add("2", "Data Entry");
                ComboOptions.Add("3", "Report Viewer");
                comboBox1.DataSource = new BindingSource(ComboOptions, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";

                ComboOptions.Clear();
                ComboOptions.Add("1", "Active");
                ComboOptions.Add("0", "Inactive");
                cmbStatus.DataSource = new BindingSource(ComboOptions, null);
                cmbStatus.DisplayMember = "Value";
                cmbStatus.ValueMember = "Key";


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserLevel = "0";
                if (comboBox1.SelectedValue != null)
                {
                    strUserLevel = comboBox1.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select User level");
                    return;
                }
                string strUserName = txtUserName.Text;
                if (txtUserName.Text.Length != 0)
                {
                    strUserName = txtUserName.Text;
                }
                else
                {
                    MessageBox.Show("Please enter user name.");
                    return;
                }

                string strStatus = cmbStatus.SelectedValue.ToString();

                
                string strPassword = txtPassword.Text;
                string strFullName = txtFullName.Text;

                string strAddress1 = txtAddress1.Text;
                string strAddress2 = txtAddress2.Text;
                string strCity = txtCity.Text;
                string strState = txtState.Text;
                string strZip = txtZip.Text;
                string strPhone = txtPhone.Text;
                string strEmail = txtEmail.Text;

                if (TemplateAutoId== "")
                {
                    if (txtPassword.Text.Length != 0)
                    {
                        strPassword= txtPassword.Text;
                    }
                    else
                    {
                        MessageBox.Show("Please enter password.");
                        return;
                    }
                    SaveData objSD = new SaveData();
                    objSD.SaveUsers(strUserName, strPassword, strStatus, strFullName, strAddress1, strAddress2, strCity, strState, strZip, strPhone, strEmail, strUserLevel);
                    MessageBox.Show("Save Successful.");
                }
                else
                {
                    SaveData objSD = new SaveData();
                    objSD.UpdateUsers(Int32.Parse(TemplateAutoId), strUserName, strPassword, strStatus, strFullName, strAddress1, strAddress2, strCity, strState, strZip, strPhone, strEmail, strUserLevel);
                    MessageBox.Show("Update Successful.");
                }
                TemplateAutoId = "";
                btnSave.Text = "Save";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";

                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtCity.Text = "";

                txtState.Text = "";
                txtZip.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                getImportedFileList();
                comboBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void buttonLastest4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            TemplateAutoId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            string strUserLevel = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.FindString(strUserLevel);
            string strStatus = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cmbStatus.SelectedIndex = cmbStatus.FindString(strStatus);

            txtUserName.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtFullName.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtAddress1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtAddress2.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtCity.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtState.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            txtZip.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
            btnSave.Text = "Update";
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
             int i = dataGridView1.SelectedCells[0].RowIndex;
             TemplateAutoId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (TemplateAutoId != "")
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the User - " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeleteUser(Int32.Parse(TemplateAutoId));
                    showdata();
                    MessageBox.Show("Delete Successful.");
                }
                //else
                //{
                //    // If 'No', do something here.
                //}

            }
            else {
                MessageBox.Show("Please select a row to Delete.");
            }
            TemplateAutoId = "";
        }

               
    }
    
}
