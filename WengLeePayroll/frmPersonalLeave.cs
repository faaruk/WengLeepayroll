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
    public partial class frmPersonalLeave : Form
    {
        string PayId = "";
        public frmPersonalLeave()
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
                string strEmpID = ""; string strLeaveType = "";
                DateTime processDate = dateTimePicker1.Value;
                string strPayDate = processDate.ToShortDateString();
                processDate = dteRequestDate.Value;
                string strReqDate = processDate.ToShortDateString();
                processDate = dteToDate.Value;
                string strLeaveToDate = processDate.ToShortDateString();
                string strComments = txtPayPeriod.Text;
                if (comboBox1.SelectedValue != null)
                {

                    strEmpID = comboBox1.SelectedValue.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Please an Employee");
                    return;
                }
                if (cmbStatus.SelectedValue != null)
                {
                    strLeaveType = cmbStatus.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Please an Employee");
                    return;
                }
                string strHours = txtHours.Text;
                if (strHours.Trim() == "") strHours = "0";
                string PeriodType = "1";
                if (rdoDatewise.Checked == true)
                { PeriodType = "1";  }
                else { 
                    PeriodType = "2"; strLeaveToDate = strPayDate; txtDays.Text = "0";
                    if (double.Parse(strHours) <= 0)
                    {
                        MessageBox.Show("Please enter correct hours.");
                        txtHours.Focus();
                        return;
                    }
                }
                string Wc = "0";
                if (cmbWC.SelectedValue != null)
                {
                    Wc = cmbWC.SelectedValue.ToString();
                }
                if (PayId == "")
                {
                    SaveData objSD = new SaveData();
                    //SavePersonalLeave(string _PeriodType, string _RequestDate, string _EmpAutoID, string _LeaveDate, string _LeaveToDate, string _Days, string _Hours, string _LeaveType, string _WC, string _Comments)
                    objSD.SavePersonalLeave(PeriodType, strReqDate, strEmpID, strPayDate, strLeaveToDate, txtDays.Text, strHours, strLeaveType, Wc, strComments.Replace("'","''"));
                    MessageBox.Show("Save Successful.");
                }
                else
                {
                    SaveData objSD = new SaveData();
                    objSD.UpdatePersonalLeave(PayId, PeriodType, strReqDate, strEmpID, strPayDate, strLeaveToDate, txtDays.Text, strHours, strLeaveType, Wc, strComments.Replace("'","''"));
                    MessageBox.Show("Update Successful.");
                }
                PayId = "";
                buttonLastest1.Text = "Add";
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
            dt = objRD.GetPersonalLeave();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            //dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[12].Width = 240;

        }

        private void FillStaticOption()
        {
            Dictionary<string, string> ComboOptions = new Dictionary<string, string>();
            
            ComboOptions.Clear();
            ComboOptions.Add("1", "Sick/Medical Leave");
            ComboOptions.Add("2", "Casual Leave");
            ComboOptions.Add("3", "Maternity Leave");
            ComboOptions.Add("4", "Parental Leave");
            ComboOptions.Add("5", "Personal Leave");
            cmbStatus.DataSource = new BindingSource(ComboOptions, null);
            cmbStatus.DisplayMember = "Value";
            cmbStatus.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("0", "");
            ComboOptions.Add("1", "WC");
            cmbWC.DataSource = new BindingSource(ComboOptions, null);
            cmbWC.DisplayMember = "Value";
            cmbWC.ValueMember = "Key";

            ReadData objRD = new ReadData();
            DataTable dt = objRD.GetMasterEmployeeListForLeave();
            comboBox1.DisplayMember = "EmpName";
            comboBox1.ValueMember = "EmpID";
            comboBox1.DataSource = dt;

        }

        private void frmPayPeriod_Load(object sender, EventArgs e)
        {
            try
            {
                FillStaticOption();
                showdata();
                txtHours.Text = "8";
                txtDays.Text = "1";
                txtHours.BackColor = Color.LightGray;
                calculateDaysHours();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void buttonLastest2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            PayId = dataGridView1.Rows[i].Cells[0].Value.ToString();
            
            string strDropDown = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.FindString(strDropDown);

            strDropDown = dataGridView1.Rows[i].Cells[2].Value.ToString();
            if (strDropDown == "2") rdoByHour.Checked = true; else rdoDatewise.Checked = true;
            if (strDropDown == "2")
            {
                lblToDate.Visible = false;
                dteToDate.Visible = false;
                lblDays.Visible = false;
                txtDays.Visible = false;
                txtHours.Enabled = true;
                txtHours.BackColor = Color.White;
            }
            else {
                lblToDate.Visible = true;
                dteToDate.Visible = true;
                txtDays.Visible = true;
                lblDays.Visible = true;
                txtHours.Enabled = false;
                txtHours.BackColor = Color.LightGray;
            }

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            if (dataGridView1.Rows[i].Cells[5].Value.ToString() != "")
            {
                dteToDate.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            txtDays.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtHours.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            if (dataGridView1.Rows[i].Cells[8].Value.ToString() != "")
            {
                dteRequestDate.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
            }

            strDropDown = dataGridView1.Rows[i].Cells[9].Value.ToString();
            cmbStatus.SelectedIndex = cmbStatus.FindString(strDropDown);

            strDropDown = dataGridView1.Rows[i].Cells[10].Value.ToString();
            cmbWC.SelectedIndex = cmbWC.FindString(strDropDown);

            txtPayPeriod.Text = dataGridView1.Rows[i].Cells[12].Value.ToString();
            
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
                var confirmResult = MessageBox.Show("Are you sure to delete Leave for - " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeletePersonalLeave(PayId);
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
            PayId = "";
        }

        private void rdoByHour_CheckedChanged(object sender, EventArgs e)
        {
            calculateDaysHours();
            txtHours.Text = "";
            lblToDate.Visible = false;
            dteToDate.Visible = false;
            lblDays.Visible = false;
            txtDays.Visible = false;
            txtHours.Enabled = true;
            txtHours.BackColor = Color.White;
        }

        private void rdoDatewise_CheckedChanged(object sender, EventArgs e)
        {
            calculateDaysHours();
            lblToDate.Visible = true;
            dteToDate.Visible = true;
            txtDays.Visible = true;
            lblDays.Visible = true;
            txtHours.Enabled = false;
            txtHours.BackColor = Color.LightGray;
        }

        private void dteToDate_ValueChanged(object sender, EventArgs e)
        {
            calculateDaysHours();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            calculateDaysHours();
        }

        private void calculateDaysHours()
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dteToDate.Value;

            TimeSpan t = DateTime.Parse(d2.ToShortDateString()).Date - DateTime.Parse(d1.ToShortDateString()).Date;
            int NrOfDays = t.Days;
            int idays = (int)NrOfDays;

            //MessageBox.Show("" + idays + " ");
            if (rdoByHour.Checked == true)
            { NrOfDays = 0; idays = 0; }
            if (NrOfDays < 0)
            { MessageBox.Show("Incorrect date, please check"); return; }
            else
            {
                txtHours.Text = ((idays + 1) * 8).ToString();
                txtDays.Text = ((idays + 1)).ToString();
                ReadData objRD = new ReadData();
                DataTable dt = null;
                if (rdoByHour.Checked == true)
                {
                    dt = objRD.GetgetPayperiodForLeave(d1.ToShortDateString(), d1.ToShortDateString());
                }
                else
                {
                    dt = objRD.GetgetPayperiodForLeave(d1.ToShortDateString(), d2.ToShortDateString());
                }
                if (dt.Rows.Count > 0)
                {
                    lblPayPeriod.Text ="Pay Period(s): " + dt.Rows[0][1].ToString();
                }
                else
                {
                    lblPayPeriod.Text = "These dates are not in any pay period.";
                }


            }

        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
