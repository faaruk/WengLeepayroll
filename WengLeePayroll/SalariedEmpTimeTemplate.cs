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
    public partial class SalariedEmpTimeTemplate : Form
    {
        
        string TemplateAutoId = "";
        public SalariedEmpTimeTemplate()
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
            dt = objRD.GetSalariedTemplate();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 165;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            
        }
        private void mfillCombo()
        {
            try
            {
                ReadData objRD = new ReadData();
                DataTable dt = objRD.GetMasterEmployeeList();
                comboBox1.DisplayMember = "EmpName";
                comboBox1.ValueMember = "EmpID";
                comboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
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
                if (comboBox1.SelectedValue != null)
                {
                    strEmpID = comboBox1.SelectedValue.ToString();
                }
                else {
                    MessageBox.Show("Please select an Employee");
                    return;
                }
                string strRegularHours = txtReg.Text;
                if (strRegularHours.Trim() == "") strRegularHours = "0";
                string strOT1 = txtOT1.Text;
                if (strOT1.Trim() == "") strOT1 = "0";
                string strOT2 = txtOT2.Text;
                if (strOT2.Trim() == "") strOT2 = "0";

                SaveData objSD = new SaveData();
                objSD.SaveSalariedData(Int32.Parse(strEmpID), strRegularHours, strOT1, strOT2, strprocessDate1);
                txtReg.Text = "";
                txtOT1.Text = "";
                txtOT2.Text="";
                getImportedFileList();
                MessageBox.Show("Save Successful.");
                comboBox1.Focus();
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
                string strEmpID = "0";
                if (comboBox1.SelectedValue != null)
                {
                    strEmpID = comboBox1.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select an Employee");
                    return;
                }
                string strRegularHours = txtReg.Text;
                if (strRegularHours.Trim() == "") strRegularHours = "0";
                string strOT1 = txtOT1.Text;
                if (strOT1.Trim() == "") strOT1 = "0";
                string strOT2 = txtOT2.Text;
                if (strOT2.Trim() == "") strOT2 = "0";
                if (TemplateAutoId== "")
                {
                    SaveData objSD = new SaveData();
                    objSD.SaveSalariedTemplate(Int32.Parse(strEmpID), strRegularHours, strOT1, strOT2);
                    MessageBox.Show("Save Successful.");
                }
                else{
                    SaveData objSD = new SaveData();
                    objSD.UpdateSalariedTemplate(Int32.Parse(TemplateAutoId), Int32.Parse(strEmpID), strRegularHours, strOT1, strOT2);
                    MessageBox.Show("Update Successful.");
                }
                TemplateAutoId = "";
                btnSave.Text = "Save";
                txtReg.Text = "";
                txtOT1.Text = "";
                txtOT2.Text = "";
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
            string strStatus = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.FindString(strStatus);
            txtReg.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtOT1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtOT2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

            btnSave.Text = "Update";
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
             int i = dataGridView1.SelectedCells[0].RowIndex;
             TemplateAutoId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (TemplateAutoId != "")
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the Template for - " + dataGridView1.Rows[i].Cells[2].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeleteSalariedTemplate(Int32.Parse(TemplateAutoId));
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

        private void SalariedEmpTimeTemplate_Resize(object sender, EventArgs e)
        {
            labelGradient2.Width = this.Width;
            labelGradient2.Left = 0;
        }
        
    }
    
}
