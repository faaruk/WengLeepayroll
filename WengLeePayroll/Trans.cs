
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
    public partial class Trans : Form
    {
        public Trans()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var frmForm1 = new Form1 { MdiParent = this.MdiParent };
            frmForm1.Show();
            //Form1 objImportData = new Form1();
            //objImportData.Show();
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

        private void Trans_FormClosing(object sender, FormClosingEventArgs e)
        {
            
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
            var frmForm1 = new ConvertSalariedTemplateToTime { MdiParent = this.MdiParent };
            frmForm1.Show();
            //ConvertSalariedTemplateToTime objfrm = new ConvertSalariedTemplateToTime();
            //objfrm.Show();
        }

        private void buttonLastest8_Click(object sender, EventArgs e)
        {
            //var frmForm1 = new ExecuteReport { MdiParent = this.MdiParent };
            //frmForm1.Show();
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

        private void Trans_Paint(object sender, PaintEventArgs e)
        {
            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.SteelBlue,
                                                                       Color.Black,
                                                                       60F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Trans_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void buttonLastest1_Click_1(object sender, EventArgs e)
        {
            var frmForm1 = new frmPersonalLeave { MdiParent = this.MdiParent };
            frmForm1.Show();

            //frmPersonalLeave objRreport = new frmPersonalLeave();
            //objRreport.Show();
        }
       
    }
}
