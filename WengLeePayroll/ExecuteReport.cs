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
                comboBox1.DisplayMember = "EmpName";
                comboBox1.ValueMember = "EmpID";
                comboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
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
                string strEmpID = "0";
                if (comboBox1.SelectedValue != null)
                {
                    strEmpID = comboBox1.SelectedValue.ToString();
                }
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
                string strEmpID = "0";
                if (comboBox1.SelectedValue != null)
                {
                    strEmpID = comboBox1.SelectedValue.ToString();
                }
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
