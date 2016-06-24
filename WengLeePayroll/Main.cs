
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 objImportData = new Form1();
            objImportData.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExecuteReport objRreport = new ExecuteReport();
            objRreport.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExecuteReportFile objRreport = new ExecuteReportFile();
            objRreport.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExecuteReportDateRange objRreport = new ExecuteReportDateRange();
            objRreport.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalariedEmpTime objImportData = new SalariedEmpTime();
            objImportData.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExecuteReportLongLunch objRreport = new ExecuteReportLongLunch();
            objRreport.Show();
        }

        private void cmdPayPeriod_Click(object sender, EventArgs e)
        {
            frmCompanyHolidays objPayPeriod = new frmCompanyHolidays();
            objPayPeriod.Show();
        }

        private void managePayPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyHolidays objPayPeriod = new frmCompanyHolidays();
            objPayPeriod.Show();
        }

        private void manageSalariedTimeTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalariedEmpTimeTemplate objTemplate = new SalariedEmpTimeTemplate();
            objTemplate.Show();
        }

        private void buttonLastest1_Click(object sender, EventArgs e)
        {
            SalariedEmpTimeTemplate objSalariedEmpTimeTemplate = new SalariedEmpTimeTemplate();
            objSalariedEmpTimeTemplate.Show();
        }

        private void importHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 objImportData = new Form1();
            objImportData.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageEmployee objManageEmployee = new ManageEmployee();
            objManageEmployee.Show();
        }

        private void buttonLastest3_Click(object sender, EventArgs e)
        {
            ManageEmployee objManageEmployee = new ManageEmployee();
            objManageEmployee.Show();
        }

        private void buttonLastest4_Click(object sender, EventArgs e)
        {
            ConvertSalariedTemplateToTime objfrm = new ConvertSalariedTemplateToTime();
            objfrm.Show();
        }

        private void buttonLastest8_Click(object sender, EventArgs e)
        {
            ExecuteReport objRreport = new ExecuteReport();
            objRreport.Show();
        }

        private void buttonLastest7_Click(object sender, EventArgs e)
        {
            ExecuteReportFile objRreport = new ExecuteReportFile();
            objRreport.Show();
        }

        private void buttonLastest6_Click(object sender, EventArgs e)
        {
            ExecuteReportDateRange objRreport = new ExecuteReportDateRange();
            objRreport.Show();
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
            ExecuteReportLongLunch objRreport = new ExecuteReportLongLunch();
            objRreport.Show();
        }
        
       
    }
}
