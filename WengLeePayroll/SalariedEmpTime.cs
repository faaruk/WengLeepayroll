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
    public partial class SalariedEmpTime : Form
    {
        public SalariedEmpTime()
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
            InitializeListView();
            LoadList();
        }
        // Initialize ListView
        private void InitializeListView()
        {
            //Clear View
            lvImportedFiles.Clear();

            // Set the view to show details.
            lvImportedFiles.View = View.Details;

            // Allow the user to edit item text.
            lvImportedFiles.LabelEdit = true;

            // Allow the user to rearrange columns.
            lvImportedFiles.AllowColumnReorder = true;

            // Select the item and subitems when selection is made.
            lvImportedFiles.FullRowSelect = true;

            // Display grid lines.
            lvImportedFiles.GridLines = true;

            // Sort the items in the list in ascending order.
            //lvImportedFiles.Sorting = SortOrder.Ascending;

            // Attach Subitems to the ListView
            lvImportedFiles.Columns.Add("Pay Date", 180, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("Emp ID", 80, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("Emp Name", 200, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("Regular", 100, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("OT 1", 100, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("OT 2", 100, HorizontalAlignment.Left);

            //lvImportedFiles.Columns.Add("Price", 70, HorizontalAlignment.Left);
            //lvImportedFiles.Columns.Add("Publi-Date", 100, HorizontalAlignment.Left);

            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.

            //_lvwItemComparer = new ListViewItemComparer();
            //this.lvImportedFiles.ListViewItemSorter = _lvwItemComparer;
        }
        // Load Data from the DataSet into the ListView
        private void LoadList()
        {
            // Get the table from the data set
            ReadData objRD = new ReadData();

            DataTable dtable = objRD.GetSalariedData();

            // Clear the ListView control
            lvImportedFiles.Items.Clear();

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    ListViewItem lvi = new ListViewItem(drow["PayDate"].ToString());
                    lvi.SubItems.Add(drow["EmpID"].ToString());
                    lvi.SubItems.Add(drow["Name"].ToString());
                    lvi.SubItems.Add(drow["Reg"].ToString());
                    lvi.SubItems.Add(drow["OT1"].ToString());
                    lvi.SubItems.Add(drow["OT2"].ToString());

                    // Add the list items to the ListView
                    lvImportedFiles.Items.Add(lvi);
                }
            }
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
                DateTime processDate = dateTimePicker1.Value;
                string strprocessDate1 = processDate.ToShortDateString();
                string strEmpID = "0";
                if (comboBox1.SelectedValue != null)
                {
                    strEmpID = comboBox1.SelectedValue.ToString();
                }
                else {
                    MessageBox.Show("Please an Employee");
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
    }
}
