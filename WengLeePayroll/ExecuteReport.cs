using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



namespace WengLeePayroll
{
    public partial class ExecuteReport : Form
    {
        DataTable dtGlobal = new DataTable();
        public ExecuteReport()
        {
            InitializeComponent();
        }

        private void ExecuteReport_Load(object sender, EventArgs e)
        {
            mfillCombo();
            FillStaticOption();
            ReadData objRD = new ReadData();
            DataTable dt = objRD.GetPayPeriodTitleToProcess();
            this.Text = "Process Hours for Pay Date: " + dt.Rows[0][1].ToString() + ". Pay Period: " + dt.Rows[0][2].ToString();
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.reportViewer1.Width = this.Width - 30;
            this.reportViewer1.Height = this.Height - 30;
        }


        public void SavePDF(string savePath)
        {
            byte[] Bytes = reportViewer1.LocalReport.Render(format: "PDF", deviceInfo: "");

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
        }
        private void mfillCombo()
        {
            try
            {
                ReadData objRD = new ReadData();
                DataTable dt = objRD.GetEmployeeList();
                dtGlobal = dt;
                comboBox1.DisplayMember = "EmpName";
                comboBox1.ValueMember = "EmpID";
                comboBox1.DataSource = dt;

                comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

                listBox1.DisplayMember = "EmpName";
                listBox1.ValueMember = "EmpID";
                listBox1.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBox1.DroppedDown = false;
        }
        private void FillStaticOption()
        {
            Dictionary<string, string> ComboOptions = new Dictionary<string, string>();
            ComboOptions.Add("0", "<All>");
            ComboOptions.Add("1", "Single Page");
            ComboOptions.Add("2", "Double Page");
            cmbPrintOption.DataSource = new BindingSource(ComboOptions, null);
            cmbPrintOption.DisplayMember = "Value";
            cmbPrintOption.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("0", "<Default>");
            ComboOptions.Add("1", "ID");
            ComboOptions.Add("2", "Full Name");
            ComboOptions.Add("3", "First Name");
            ComboOptions.Add("4", "Last Name");
            cmbSortBy.DataSource = new BindingSource(ComboOptions, null);
            cmbSortBy.DisplayMember = "Value";
            cmbSortBy.ValueMember = "Key";

            ComboOptions.Clear();
            ComboOptions.Add("0", "Ascending");
            ComboOptions.Add("1", "Descending");
            cmbSortOption.DataSource = new BindingSource(ComboOptions, null);
            cmbSortOption.DisplayMember = "Value";
            cmbSortOption.ValueMember = "Key";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = false;
                string tmpStr = "";
                string sValue = "";
                foreach (object element in listBox1.SelectedItems)
                {
                    DataRowView row = (DataRowView)element;
                    DataRow rowx = ((DataRowView)row).Row;
                    sValue = rowx[0].ToString();
                    tmpStr += sValue + ",";
                    
                }
                if (tmpStr.Length > 0)
                {
                    tmpStr = tmpStr.Remove(tmpStr.Length - 1);
                }
                string strEmpID = tmpStr;// "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                ReadData objRD = new ReadData();
                DataSet ds = objRD.GetAttendanceResult(strEmpID, cmbPrintOption.SelectedValue.ToString(), cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString());
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.Report1.rdlc";
                //this.reportViewer1.LocalReport.ReportPath = "TimeCard.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                //this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.Width = this.Width - 30;
                this.reportViewer1.Height = this.Height - 40;
                this.reportViewer1.RefreshReport();

                //SavePDF(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = false;
                string tmpStr = "";
                string sValue = "";
                foreach (object element in listBox1.SelectedItems)
                {
                    DataRowView row = (DataRowView)element;
                    DataRow rowx = ((DataRowView)row).Row;
                    sValue = rowx[0].ToString();
                    tmpStr += sValue + ",";
                }
                if (tmpStr.Length > 0)
                {
                    tmpStr = tmpStr.Remove(tmpStr.Length - 1);
                }
                string strEmpID = tmpStr;// "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                ReadData objRD = new ReadData();
                DataSet ds = objRD.GetAttendanceSummaryResult(strEmpID, "0", cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString());
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.SummaryTimeCard.rdlc";

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                //this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.Width = this.Width - 30;
                this.reportViewer1.Height = this.Height - 40;
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            string tmpStr = "";
            string sValue = "";
            foreach (object element in listBox1.SelectedItems)
            {
                DataRowView row = (DataRowView)element;
                DataRow rowx = ((DataRowView)row).Row;
                sValue = rowx[0].ToString();
                tmpStr += sValue + ",";

            }
            if (tmpStr.Length > 0)
            {
                tmpStr = tmpStr.Remove(tmpStr.Length - 1);
            }
            if (tmpStr != "0")
            {
                button3.Text = tmpStr;
            }
            else { button3.Text = "All"; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string searchString2;
            //listBox1.ClearSelected();
            //searchString2 = textBox1.Text;
            //listBox1.SelectionMode = SelectionMode.MultiExtended;
            //int x = -1;

            //if (searchString2.Length != 0)
            //{
            //    do
            //    {
            //        x = listBox1.FindString(searchString2, x);
            //        if (x != -1)
            //        {
            //            if (listBox1.SelectedIndices.Count > 0)
            //            {
            //                if (x == listBox1.SelectedIndices[0])
            //                    return;
            //            }
            //            listBox1.SetSelected(x, true);
            //        }
            //    }
            //    while (x != -1);
            //}
            

            DataRow[] drArr = dtGlobal.Select("EmpName like '%" + textBox1.Text + "%'");

            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("EmpID", typeof(System.Int32));
            dtNew.Columns.Add("EmpName", typeof(System.String));
            for (int i = 0; i < drArr.Length; i++)
                dtNew.Rows.Add(drArr[i].ItemArray);
            listBox1.DataSource = dtNew;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExecuteReport_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cmbSortBy_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cmbSortOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSortOption_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cmbPrintOption_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void reportViewer1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void reportViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = false;
        }


        //private void runRptViewer()
        //{
        //    this.reportViewer1.Reset();
        //    this.reportViewer1.LocalReport.ReportPath = "Report.rdlc";
        //    reportViewer1.LocalReport.DataSources.Clear();
        //    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
        //    this.reportViewer1.LocalReport.Refresh();
        //}
    }
}
