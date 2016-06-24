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

using Excel = Microsoft.Office.Interop.Excel;

namespace WengLeePayroll
{
    public partial class Form1 : Form
    {
        public Form1()
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
        private void Form1_Load(object sender, EventArgs e)
        {
            
            getImportedFileList();
        }
        private void getImportedFileList()
        {
            InitializeListView();
            LoadList();
        }
        private void mfillCombo()
        {
            try
            {
                ReadData objRD = new ReadData();
                DataTable dt = objRD.GetPayPeriodForCombo();
                cmbPayPeriod.DataSource = null;
                cmbPayPeriod.Items.Clear();
                cmbPayPeriod.DisplayMember = "Period";
                cmbPayPeriod.ValueMember = "PeriodId";
                cmbPayPeriod.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }
        // Initialize ListView
        private void InitializeListView()
        {
            lvImportedFiles.Columns.Clear();

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
            lvImportedFiles.Columns.Add("File Name", 270, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("Pay Date", 87, HorizontalAlignment.Left);
            
            lvImportedFiles.Columns.Add("From Date", 87, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("To Date", 87, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("PeriodId", 0, HorizontalAlignment.Left);
            lvImportedFiles.Columns.Add("Import Completed?", 125, HorizontalAlignment.Center);
            lvImportedFiles.Columns.Add("Import Date", 87, HorizontalAlignment.Left);
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

            DataSet ds = objRD.GetImportedFileNames();
            DataTable dtable = ds.Tables[0];

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
                    ListViewItem lvi = new ListViewItem(drow["FileName"].ToString());

                    lvi.SubItems.Add(drow["ProcessDate"].ToString());
                    
                    lvi.SubItems.Add(drow["FromDate"].ToString());
                    lvi.SubItems.Add(drow["ToDate"].ToString());
                    lvi.SubItems.Add(drow["PeriodId"].ToString());
                    lvi.SubItems.Add(drow["isImportCompleted"].ToString());
                    lvi.SubItems.Add(drow["InsertDate"].ToString());
                    // Add the list items to the ListView
                    lvImportedFiles.Items.Add(lvi);
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveData objSD = new SaveData();
            string strPayPperiodID = "";
            if (cmbPayPeriod.SelectedValue != null)
            {
                strPayPperiodID = cmbPayPeriod.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Please select a Pay period.");
                return;
            }

            buttonLastest1.Enabled = false;
            
            try
            {
                DateTime processDate = dateTimePicker1.Value;
                string strprocessDate1 = processDate.ToShortDateString();

                string strFilePath = ""; string onlyFileName = ""; string FileName = "";
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Please select an Excel file.";
                //fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = fdlg.FileName;
                    onlyFileName = System.IO.Path.GetFileName(fdlg.FileName);
                    FileName = System.IO.Path.GetFileNameWithoutExtension(fdlg.FileName);
                    //MessageBox.Show(onlyFileName);
                    //MessageBox.Show(FileName);
                }
                if (strFilePath == "")
                {
                    buttonLastest1.Enabled = true;
                    return;
                }

                SaveData objSDDelete = new SaveData();
                objSDDelete.DeleteTempData();

                Excel.Application xlApp = new Excel.Application();
                //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"E:\Activities\Cindy Tang\Excel\1106_Employee Time Card Reportgg.xls");
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@strFilePath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                int emptxtrow = 0; int empid = 0; int coderow = 0; int datarow = 0;
                int CodeCol = 0; int attDateCol = 0; int attDayCol = 0; int ActionCol = 0; int StartCol = 0; int StopCol = 0;
                int HoursCol = 0; int RegCol = 0; int OT1Col = 0; int OT2Col = 0; int PaidCol = 0; int UnpaidCol = 0;
                string strDefaultLevel = ""; string strDefaultLevelValue = ""; string strName = ""; string strDate_P = "";
                bool isDataStarted = false;
                progressBar1.Maximum = rowCount;
                for (int i = 1; i <= rowCount; i++)
                {
                    label1.Text = "Processing " + i + " of " + rowCount + " rows";
                    progressBar1.Value = i;
                    if (xlRange.Cells[i, 1].Value2 != null)
                    {
                        if (xlRange.Cells[i, 1].Value2.ToString() == "Employee Number")
                        { //MessageBox.Show(xlRange.Cells[i, 1].Value2.ToString()); 
                            if (xlRange.Cells[i, 10].Value2 != null)
                            {
                                strDefaultLevel = xlRange.Cells[i, 10].Value2.ToString();
                            }
                            empid = 0;
                            emptxtrow = i;
                            strName = "";
                        }
                    }
                    if (emptxtrow != 0)
                    {
                        if (i == emptxtrow + 1)
                        {
                            if (xlRange.Cells[i, 3].Value2 != null)
                            {
                                strName = xlRange.Cells[i, 3].Value2.ToString();
                            }
                            if (xlRange.Cells[i, 10].Value2 != null)
                            {
                                strDefaultLevelValue = xlRange.Cells[i, 10].Value2.ToString();
                                if (strDefaultLevelValue == "<Unassigned>")
                                { strDefaultLevelValue = ""; }
                            }
                        }
                        if (strName == "")
                        {
                            if ((xlRange.Cells[i, 3].Value2 != null)&&(xlRange.Cells[i, 3].Value2.ToString() != "Name"))
                            {
                                strName = xlRange.Cells[i, 3].Value2.ToString();
                                //Because Name and Level value are in same row
                                if (xlRange.Cells[i, 10].Value2 != null)
                                {
                                    strDefaultLevelValue = xlRange.Cells[i, 10].Value2.ToString();
                                    if (strDefaultLevelValue == "<Unassigned>")
                                    { strDefaultLevelValue = ""; }
                                }
                            }
                        }
                        if (empid == 0)
                        {
                            if ((xlRange.Cells[i, 1].Value2 != null)&&(xlRange.Cells[i, 1].Value2.ToString() != "Employee Number"))
                            {
                                empid = Int32.Parse(xlRange.Cells[i, 1].Value2.ToString());
                                coderow = i;
                            }
                        }
                        //if (i == emptxtrow + 2)
                        //{
                        //    if (xlRange.Cells[i, 1].Value2 != null)
                        //    {
                        //        empid = Int32.Parse(xlRange.Cells[i, 1].Value2.ToString());
                        //        //MessageBox.Show(empid.ToString());
                        //        coderow = i;
                        //    }
                        //}
                    }
                    if (i == coderow + 2)
                    {
                        if (xlRange.Cells[i, 1].Value2 != null)
                        {
                            if (xlRange.Cells[i, 1].Value2.ToString() == "Code")
                            {
                                isDataStarted = true;
                                datarow = i;
                                for (int j = 1; j <= colCount; j++)
                                {
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Code"))
                                    { CodeCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Date"))
                                    { attDateCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Day"))
                                    { attDayCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Action"))
                                    { ActionCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Start"))
                                    { StartCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Stop"))
                                    { StopCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Hours"))
                                    { HoursCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Reg"))
                                    { RegCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "OT1"))
                                    { OT1Col = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "OT2"))
                                    { OT2Col = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Paid"))
                                    { PaidCol = j; }
                                    if ((xlRange.Cells[i, j].Value2 != null) && (xlRange.Cells[i, j].Value2.ToString() == "Unpaid"))
                                    { UnpaidCol = j; }
                                }
                            }
                        }
                    }
                    if (i >= datarow + 1)
                    {
                        if (isDataStarted == true)
                        {
                            if (xlRange.Cells[i, 1].Value2 != null)
                            {
                                if (xlRange.Cells[i, 1].Value2.ToString() == empid.ToString())
                                { isDataStarted = false; }
                            }
                            if (isDataStarted == true)
                            {
                                if (xlRange.Cells[i, 1].Value2 != null)
                                {
                                    string strCode = xlRange.Cells[i, CodeCol].Value2.ToString();
                                    string strDate = xlRange.Cells[i, attDateCol].Value2.ToString();
                                    if (strDate.Trim() != "")
                                    { strDate_P = strDate; }
                                    string strDay = xlRange.Cells[i, attDayCol].Value2.ToString();
                                    string strAction = xlRange.Cells[i, ActionCol].Value2.ToString();
                                    string strStart = xlRange.Cells[i, StartCol].Value2.ToString();
                                    string strStop = xlRange.Cells[i, StopCol].Value2.ToString();
                                    string strHours = xlRange.Cells[i, HoursCol].Value2.ToString();
                                    if (strHours.Trim() == "") strHours = "0";
                                    string strRegularHours = xlRange.Cells[i, RegCol].Value2.ToString();
                                    if (strRegularHours.Trim() == "") strRegularHours = "0";
                                    string strOT1 = xlRange.Cells[i, OT1Col].Value2.ToString();
                                    if (strOT1.Trim() == "") strOT1 = "0";
                                    string strOT2 = xlRange.Cells[i, OT2Col].Value2.ToString();
                                    if (strOT2.Trim() == "") strOT2 = "0";
                                    string strPaid = "";
                                    if (PaidCol != 0)
                                    {
                                        strPaid = xlRange.Cells[i, PaidCol].Value2.ToString();
                                    }
                                    if (strPaid.Trim() == "") strPaid = "0";
                                    string strUnPaid = "";
                                    if (UnpaidCol != 0)
                                    {
                                        strUnPaid = xlRange.Cells[i, UnpaidCol].Value2.ToString();
                                    }
                                    if (strUnPaid.Trim() == "") strUnPaid = "0";
                                    if (strDefaultLevelValue.Trim() == "") strDefaultLevelValue = "0";
                                    
                                    objSD.SaveTempData(empid, strCode, strDate, strDay, strAction, strStart, strStop, strHours, strRegularHours, strOT1, strOT2, strPaid, strUnPaid, strDefaultLevel, strName, strDefaultLevelValue, strprocessDate1, FileName, strDate_P, Int32.Parse(strPayPperiodID));
                                    
                                    //strDate_P=strDate;
                                    //MessageBox.Show("Emp Id: " + empid.ToString() + " Code: " + strCode + " Date: " + strDate 
                                    //    + " Day: " + strDay + " Action: " + strAction + " Start: " + strStart + " Stop: " + strStop);
                                }
                            }

                            //if (xlRange.Cells[i, 1].Value2.ToString() == empid.ToString())
                            //{ isDataStarted = false; }   
                        }
                    }

                    //for (int j = 1; j <= colCount; j++)
                    //{
                    //    if (xlRange.Cells[i, j].Value2 != null)
                    //        Console.WriteLine(xlRange.Cells[i, j].Value2.ToString());

                    //    //MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
                    //}
                    //
                    //Application.DoEvents();
                }
                SaveData objCopy = new SaveData();
                objCopy.CopyToArchive();
                DataTable dtNewEmp= objCopy.ImportEmpFromAttendanceSheetIfNew();
                if (dtNewEmp.Rows.Count > 0)
                {
                    panel1.Visible = true;
                    dataGridView1.DataSource = dtNewEmp;
                }
                mfillCombo();
                getImportedFileList();
                MessageBox.Show("Successfully processed.","Confirmation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.", "Error");
            }
            buttonLastest1.Enabled = true;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            mfillCombo();
            InitializeListView();
            LoadList();
        }

        private void lvImportedFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvImportedFiles_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection sel = lvImportedFiles.SelectedIndices;

            if (sel.Count == 1)
            {
                ListViewItem selItem = lvImportedFiles.Items[sel[0]];
                string TemplateAutoId = selItem.SubItems[4].Text;
                if (TemplateAutoId != "")
                {
                    var confirmResult = MessageBox.Show("Are you sure to delete the imported data for file - " + selItem.SubItems[0].Text + ".xls for the pay date - " + selItem.SubItems[1].Text + "?",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        SaveData objSD = new SaveData();
                        objSD.DeleteAttendanceData(TemplateAutoId);
                        mfillCombo();
                        getImportedFileList();
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
            else
            {
                MessageBox.Show("Please select a row to Delete.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}