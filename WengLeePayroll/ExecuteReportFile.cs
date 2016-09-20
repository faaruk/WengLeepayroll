using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;


namespace WengLeePayroll
{
    public partial class ExecuteReportFile : Form
    {
        DataTable dtGlobal = new DataTable();
        public ExecuteReportFile()
        {
            InitializeComponent();
        }

        private void ExecuteReportFile_Load(object sender, EventArgs e)
        {
            mfillCombo();
            FillStaticOption();
            mfillPayDay();
            this.reportViewer1.Width = this.Width - 30;
            this.reportViewer1.Height = this.Height - 40;
            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = false;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            reportViewer1.SetPageSettings(ps);
            
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
                DataTable dt = objRD.GetEmployeeListArchieve();
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
        private void mfillPayDay()
        {
            try
            {
                ReadData objRD = new ReadData();
                DataTable dt = objRD.GetImportedFileNamesWithPayDate();
                cmbPayDay.DisplayMember = "Period";
                cmbPayDay.ValueMember = "PeriodId";
                cmbPayDay.DataSource = dt;
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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                ReadData objRD = new ReadData();
                DataSet ds = objRD.GetAttendanceResultArchive(strEmpID, cmbPrintOption.SelectedValue.ToString(), cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID);
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.Report1.rdlc";
                //this.reportViewer1.LocalReport.ReportPath = "TimeCard.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                //this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

                //System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                //ps.Landscape = true;
                //ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
                //ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
                //reportViewer1.SetPageSettings(ps);

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
                DataSet ds = objRD.GetAttendanceResult(strEmpID, cmbPrintOption.SelectedValue.ToString(), cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString());
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.Summary.rdlc";

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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                string strPeriodDesc = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodDesc= cmbPayDay.Text;
                }

                ReadData objRD = new ReadData();

                DataSet ds = objRD.GetLateArchiveByPayPeriod(strEmpID, cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID);
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.LateReport.rdlc";
                //this.reportViewer1.LocalReport.ReportPath = "TimeCard.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                ReportParameter p1 = new ReportParameter("ReportTitle", "Pay Period - " + strPeriodDesc + "");
                this.reportViewer1.LocalReport.SetParameters(p1);
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

        private void button4_Click(object sender, EventArgs e)
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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                string strPeriodDesc = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodDesc = cmbPayDay.Text;
                }

                ReadData objRD = new ReadData();

                DataSet ds = objRD.GetLateArchiveByPayPeriod(strEmpID, cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID);
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.AttendanceStatus.rdlc";
                //this.reportViewer1.LocalReport.ReportPath = "TimeCard.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
                this.reportViewer1.ZoomPercent = 100;
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                ReportParameter p1 = new ReportParameter("ReportTitle", "Pay Period - " + strPeriodDesc + "");
                this.reportViewer1.LocalReport.SetParameters(p1);
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

        private void button5_Click(object sender, EventArgs e)
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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                string strPeriodDesc = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodDesc = cmbPayDay.Text;
                }

                ReadData objRD = new ReadData();
                DataSet ds = objRD.GetCoverPageArchiveByPayPeriod(strEmpID, cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID, 30, 10);

                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.AttendanceCover.rdlc";

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));

                ReportParameter p1 = new ReportParameter("ReportTitle", "Pay Period - " + strPeriodDesc + "");
                this.reportViewer1.LocalReport.SetParameters(p1);
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

        private void button7_Click(object sender, EventArgs e)
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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                string strPeriodDesc = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodDesc = cmbPayDay.Text;
                }

                ReadData objRD = new ReadData();

                DataSet ds = objRD.GetLongLucnArchiveByPayPeriod(strEmpID, cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID, "Lunch", 30);
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.LongLunchReport.rdlc";
                //this.reportViewer1.LocalReport.ReportPath = "TimeCard.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));

                ReportParameter p1 = new ReportParameter("ReportTitle", "Pay Period - " + strPeriodDesc + "");
                this.reportViewer1.LocalReport.SetParameters(p1);

                ReportParameter p2 = new ReportParameter("ReportName", "Long Lunch Report");
                this.reportViewer1.LocalReport.SetParameters(p2);

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
        //private void runRptViewer()
        //{
        //    this.reportViewer1.Reset();
        //    this.reportViewer1.LocalReport.ReportPath = "Report.rdlc";
        //    reportViewer1.LocalReport.DataSources.Clear();
        //    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
        //    this.reportViewer1.LocalReport.Refresh();
        //}
        private void button6_Click(object sender, EventArgs e)
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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                string strPeriodDesc = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodDesc = cmbPayDay.Text;
                }

                ReadData objRD = new ReadData();

                DataSet ds = objRD.GetLongLucnArchiveByPayPeriod(strEmpID, cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID, "Break", 10);
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.LongLunchReport.rdlc";
                //this.reportViewer1.LocalReport.ReportPath = "TimeCard.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));

                ReportParameter p1 = new ReportParameter("ReportTitle", "Pay Period - " + strPeriodDesc + "");
                this.reportViewer1.LocalReport.SetParameters(p1);

                ReportParameter p2 = new ReportParameter("ReportName", "Long Break Report");
                this.reportViewer1.LocalReport.SetParameters(p2);

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

        private void button8_Click(object sender, EventArgs e)
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
                //string strEmpID = "0";
                //if (comboBox1.SelectedValue != null)
                //{
                //    strEmpID = comboBox1.SelectedValue.ToString();
                //}
                string strPeriodID = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodID = cmbPayDay.SelectedValue.ToString();
                }
                string strPeriodDesc = "0";
                if (cmbPayDay.SelectedValue != null)
                {
                    strPeriodDesc = cmbPayDay.Text;
                }
                ReadData objRD = new ReadData();

                DataSet ds = objRD.GetLeaveDataByPayPeriod(strEmpID, cmbSortBy.SelectedValue.ToString(), cmbSortOption.SelectedValue.ToString(), strPeriodID);
                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WengLeePayroll.LeaveReport.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));

                ReportParameter p1 = new ReportParameter("ReportTitle", "Pay Period - " + strPeriodDesc + "");
                this.reportViewer1.LocalReport.SetParameters(p1);
                
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBox1.DroppedDown = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
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
                button10.Text = tmpStr;
            }
            else { button10.Text = "All"; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataRow[] drArr = dtGlobal.Select("EmpName like '%" + textBox1.Text + "%'");

            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("EmpID", typeof(System.Int32));
            dtNew.Columns.Add("EmpName", typeof(System.String));
            for (int i = 0; i < drArr.Length; i++)
                dtNew.Rows.Add(drArr[i].ItemArray);
            listBox1.DataSource = dtNew;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void cmbPayDay_Click(object sender, EventArgs e)
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

        private void ExecuteReportFile_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void reportViewer1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }

        
}
