using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace WengLeePayroll
{
    public partial class frmPayPeriod : Form
    {
        string PayId = "";
        public frmPayPeriod()
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
        private void buttonLastest1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime processDate = dateTimePicker1.Value;
                string strPayDate = processDate.ToShortDateString();
                DateTime fromDate = dteFrom.Value;
                string strfromDate = fromDate.ToShortDateString();
                DateTime ToDate = dteTo.Value;
                string strToDate = ToDate.ToShortDateString();
                string strPayPeriod = txtPayPeriod.Text;
                string strStatus =cmbStatus.SelectedValue.ToString();
                
                if (PayId == "")
                {
                    SaveData objSD = new SaveData();
                    objSD.SavePayPeriod(strfromDate, strToDate,strPayDate, strPayPeriod, strStatus);
                    MessageBox.Show("Save Successful.");
                }
                else{
                    SaveData objSD = new SaveData();
                    objSD.UpdatePayPeriod(PayId, strfromDate, strToDate, strPayDate, strPayPeriod, strStatus);
                    MessageBox.Show("Update Successful.");
                }
                PayId = "";
                buttonLastest1.Text = "Save";
                txtPayPeriod.Text = "";
                showdata();
                dateTimePicker1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }
        private void showdata()  
        {
            DataTable dt = new DataTable();
            ReadData objRD = new ReadData();
            dt = objRD.GetPayPeriod();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 50;
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
        }

        private void frmPayPeriod_Load(object sender, EventArgs e)
        {
            FillStaticOption();
            showdata();
        }

        private void buttonLastest2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            PayId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            dateTimePicker1.Value =DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            dteFrom.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
            dteTo.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            txtPayPeriod.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

            string strStatus = dataGridView1.Rows[i].Cells[6].Value.ToString();
            cmbStatus.SelectedIndex = cmbStatus.FindString(strStatus);
            buttonLastest1.Text = "Update";
            //if (strStatus == "1")
            //{
            //    cmbStatus.SelectedIndex = cmbStatus.FindString("1");
            //}
            //else { cmbStatus.SelectedIndex = cmbStatus.FindString("0"); }
        }

        private void buttonLastest3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            PayId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (PayId != "")
            {
                ReadData objRD = new ReadData();
                DataTable dt = objRD.GetPayPeriodCount(PayId);
                string cnt = dt.Rows[0][0].ToString();
                if (cnt != "0")
                {
                    MessageBox.Show("This pay period is in use, Please check in import data list. Can't be deleted.");
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure to delete the pay period - " + dataGridView1.Rows[i].Cells[2].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeletePayPeriod(PayId);
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
            PayId = "";
        }

        private void frmPayPeriod_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void frmPayPeriod_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 380;
            labelGradient2.Width = this.Width + 10;
            buttonLastest2.Top = dataGridView1.Top + dataGridView1.Height + 2;
            buttonLastest5.Top = dataGridView1.Top + dataGridView1.Height + 2;
        }
    }
}
