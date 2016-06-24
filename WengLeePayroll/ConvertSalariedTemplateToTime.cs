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
    public partial class ConvertSalariedTemplateToTime : Form
    {

        string TemplateAutoId = "";
        public ConvertSalariedTemplateToTime()
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
            dt = objRD.GetSalariedTemplateActiveEmp();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 165;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            //DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            //dgvCmb.ValueType = typeof(bool);
            //dgvCmb.Name = "Chk";
            //dgvCmb.HeaderText = "Convert?";
            //dataGridView1.Columns.Add(dgvCmb);
            //dataGridView1.Rows[2].Cells[3].Value = true;
            var doWork = new DataGridViewCheckBoxColumn();
            doWork.Name = "ConvertTime"; //Added so you can find the column in a row
            doWork.HeaderText = "Convert?";
            doWork.FalseValue = "0";
            doWork.TrueValue = "1";

            //Make the default checked
            doWork.CellTemplate.Value = true;
            doWork.CellTemplate.Style.NullValue = true;

            dataGridView1.Columns.Insert(1, doWork);

        }
        private void GetSavedTime()
        {
            string strPayPeriod = "0";
            if (cmbPayPeriod.SelectedValue != null)
            {
                strPayPeriod = cmbPayPeriod.SelectedValue.ToString();
            }
            else
            {
                return;
            }
            DataTable dt = new DataTable();
            ReadData objRD = new ReadData();
            dt = objRD.GetSalariedDataByPayPeriod(strPayPeriod);
            dataGridView2.DataSource = dt;
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView2.Columns[0].Visible = false;
        }
        private void mfillCombo()
        {
            try
            {
                ReadData objRD = new ReadData();
                DataTable dt = objRD.GetPayPeriodForComboForSalaried();
                cmbPayPeriod.DisplayMember = "Period";
                cmbPayPeriod.ValueMember = "PeriodId";
                cmbPayPeriod.DataSource = dt;
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



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strPayPeriod = "0";
                if (cmbPayPeriod.SelectedValue != null)
                {
                    strPayPeriod = cmbPayPeriod.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Pay Period.");
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;//If editing is enabled, skip the new row

                    //The Cell's Value gets it wrong with the true default, it will return         
                    //false until the cell changes so use FormattedValue instead.
                    if (Convert.ToBoolean(row.Cells["ConvertTime"].FormattedValue))
                    {
                        string strEmpID = row.Cells[2].FormattedValue.ToString();
                        string strReg = row.Cells[4].FormattedValue.ToString();
                        if (strReg.Trim() == "") strReg = "0";
                        string strOT1 = row.Cells[5].FormattedValue.ToString();
                        if (strOT1.Trim() == "") strOT1 = "0";
                        string strOT2 = row.Cells[6].FormattedValue.ToString();
                        if (strOT2.Trim() == "") strOT2 = "0";

                        SaveData objSD = new SaveData();
                        objSD.SaveSalariedDataByPayPeriod(Int32.Parse(strEmpID), strReg, strOT1, strOT2, strPayPeriod);

                    }
                }
                GetSavedTime();
                MessageBox.Show("Convert Successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void buttonLastest4_Click(object sender, EventArgs e)
        {
            try
            {
                string strPayPeriod = "0";
                if (cmbPayPeriod.SelectedValue != null)
                {
                    strPayPeriod = cmbPayPeriod.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please select Pay Period.");
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;//If editing is enabled, skip the new row

                    //The Cell's Value gets it wrong with the true default, it will return         
                    //false until the cell changes so use FormattedValue instead.
                    if (Convert.ToBoolean(row.Cells["ConvertTime"].FormattedValue))
                    {
                        string strEmpID = row.Cells[2].FormattedValue.ToString();
                        string strReg = row.Cells[4].FormattedValue.ToString();
                        string strOT1 = row.Cells[5].FormattedValue.ToString();
                        string strOT2 = row.Cells[6].FormattedValue.ToString();
                        SaveData objSD = new SaveData();
                        objSD.SaveSalariedDataByPayPeriod(Int32.Parse(strEmpID), strReg, strOT1, strOT2, strPayPeriod);
                        
                    }
                }

                MessageBox.Show("Convert Successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
            int i = dataGridView2.SelectedCells[0].RowIndex;
            TemplateAutoId = dataGridView2.Rows[i].Cells[0].Value.ToString();
            if (TemplateAutoId != "")
            {
                var confirmResult = MessageBox.Show("Are you sure to delete Time for - " + dataGridView2.Rows[i].Cells[2].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeleteSalariedTime(Int32.Parse(TemplateAutoId));
                    GetSavedTime();
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

        private void cmbPayPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSavedTime();
        }

    }

}
