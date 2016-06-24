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
    public partial class frmDesignation : Form
    {
        string PayId = "";
        public frmDesignation()
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

                string strCDepartment = txtPayPeriod.Text;

                if (PayId == "")
                {
                    SaveData objSD = new SaveData();
                    objSD.SaveDesignations(strCDepartment);
                    MessageBox.Show("Save Successful.");
                }
                else
                {
                    SaveData objSD = new SaveData();
                    objSD.UpdateDesignations(PayId, strCDepartment);
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
            dt = objRD.GetDesignations();
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 340;

        }

        private void FillStaticOption()
        {
            Dictionary<string, string> ComboOptions = new Dictionary<string, string>();

            ComboOptions.Clear();
            ComboOptions.Add("1", "Active");
            ComboOptions.Add("0", "Inactive");

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

            txtPayPeriod.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();

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
                DataTable dt = objRD.GetDesignationsCount(PayId);
                string cnt = dt.Rows[0][0].ToString();
                if (cnt != "0")
                {
                    MessageBox.Show("This Designation is in use, Please check in employee list. Can't be deleted.");
                    return;
                }
                var confirmResult = MessageBox.Show("Are you sure to delete the Designation - " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveData objSD = new SaveData();
                    objSD.DeleteDesignations(PayId);
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
    }
}
