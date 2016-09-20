using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WengLeePayroll
{
    public partial class MainMdi : Form
    {
        private int childFormNumber = 0;

        Masters fm = null;
        Trans ftran = null;
        Reports freports = null;
        
        public MainMdi()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainMdi_Load(object sender, EventArgs e)
        {
            string version = System.Windows.Forms.Application.ProductVersion;
            int VersionNumber = Int32.Parse(version.Replace(".", ""));

            this.Text = "WengLee Payroll System - " + version;

            string UserName =WengLeePayroll.appcode.PublicValues.UserName;
            int userLevel= WengLeePayroll.appcode.PublicValues.UserLevel;
            if (userLevel != 1)
            {
                toolStripMenuItem3.Visible = false;
            }
            //mastersToolStripMenuItem_Click(null, null);
            //toolStripMenuItem1_Click(null, null);
            //toolStripMenuItem2_Click(null, null);
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            ManageEmployee objManageEmployee = new ManageEmployee();
            objManageEmployee.Show();
        }

        private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frmForm1 = new Masters { MdiParent = this };
            //frmForm1.Show();

            if (fm == null || fm.Text == "")
            {
                fm = new Masters();
                fm.MdiParent = this;
                fm.Show();
            }
            else if (CheckOpened(fm.Text))
            {
                fm.WindowState = FormWindowState.Normal;
                fm.Show();
                fm.Focus();
            }          
            
            //Masters objMain = new Masters();
            //objMain.Show();
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmForm1 = new frmDepartment { MdiParent = this };
            frmForm1.Show();
        }

        private void MainMdi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //var frmForm1 = new Reports { MdiParent = this };
            //frmForm1.Show();
            //Reports objMain = new Reports();
            //objMain.Show();

            if (freports == null || freports.Text == "")
            {
                freports = new Reports();
                freports.MdiParent = this;
                freports.Show();
            }
            else if (CheckOpened(freports.Text))
            {
                freports.WindowState = FormWindowState.Normal;
                freports.Show();
                freports.Focus();
            }          
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //var frmForm1 = new Trans { MdiParent = this };
            //frmForm1.Show();
            //Trans objMain = new Trans();
            //objMain.Show();

            if (ftran == null || ftran.Text == "")
            {
                ftran = new Trans();
                ftran.MdiParent = this;
                ftran.Show();
            }
            else if (CheckOpened(ftran.Text))
            {
                ftran.WindowState = FormWindowState.Normal;
                ftran.Show();
                ftran.Focus();
            }          
            
        }

        private void toolStripSeparator4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var frmForm1 = new ManageUser { MdiParent = this };
            frmForm1.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var frmForm1 = new ChangePassword { MdiParent = this };
            frmForm1.Show();
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmDepartment))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }


            var myForm = new frmDepartment();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();

            //frmDepartment objRreport = new frmDepartment();
            //objRreport.Show();
        }

        private void btnReviewOrder_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmDesignation))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            //frmDesignation objRreport = new frmDesignation();
            //objRreport.Show();
            var myForm = new frmDesignation();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void btnFullFillOrder_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(ManageEmployee))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            var myForm = new ManageEmployee();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();

            //var frmForm1 = new ManageEmployee { MdiParent = this.MdiParent };
            //frmForm1.Show();
            
        }

        private void btnAddRoutes_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmPayPeriod))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            var myForm = new frmPayPeriod();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();

            //var frmForm1 = new frmPayPeriod { MdiParent = this};
            ////frmForm1.WindowState = FormWindowState.Maximized;
            ////MainMdi frm = this.MdiParent as MainMdi;

            ////frmForm1.MdiParent = frm;
            ////frmForm1.StartPosition = FormStartPosition.CenterParent;
            //frmForm1.Show();

            //var frmForm1 = new frmPayPeriod { MdiParent = this.MdiParent };
            //frmForm1.Show();
            //frmPayPeriod objPayPeriod = new frmPayPeriod();
            //objPayPeriod.Show();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(SalariedEmpTimeTemplate))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            //var frmForm1 = new SalariedEmpTimeTemplate { MdiParent = this.MdiParent };
            //frmForm1.Show();

            var myForm = new SalariedEmpTimeTemplate();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmCompanyHolidays))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }
            //frmCompanyHolidays objRreport = new frmCompanyHolidays();
            //objRreport.Show();
            var myForm = new frmCompanyHolidays();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void btnPickQty_Click(object sender, EventArgs e)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(Form1))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }
            //var frmForm1 = new Form1 { MdiParent = this.MdiParent };
            //frmForm1.Show();
            var myForm = new Form1();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void btnReceiveStock_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(ConvertSalariedTemplateToTime))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            //var frmForm1 = new ConvertSalariedTemplateToTime { MdiParent = this.MdiParent };
            //frmForm1.Show();

            var myForm = new ConvertSalariedTemplateToTime();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void btnPriceList_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(ExecuteReport))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            //var frmForm1 = new ExecuteReport { MdiParent = this.MdiParent };
            //frmForm1.Show();
            //ExecuteReport objRreport = new ExecuteReport();
            //objRreport.Show();
            var myForm = new ExecuteReport();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(frmPersonalLeave))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }
            //var frmForm1 = new frmPersonalLeave { MdiParent = this.MdiParent };
            //frmForm1.Show();

            var myForm = new frmPersonalLeave();
            myForm.MdiParent = this;
            //myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void txtScheduledOrders_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(ExecuteReportFile))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }

            var myForm = new ExecuteReportFile();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();

            //ExecuteReportFile objRreport = new ExecuteReportFile();
            //objRreport.Show();
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(ExecuteReportDateRange))
                {
                    if (form.WindowState == FormWindowState.Minimized)
                    {
                        form.WindowState = FormWindowState.Normal;
                    }
                    form.Activate();
                    return;
                }
            }
            //ExecuteReportDateRange objRreport = new ExecuteReportDateRange();
            //objRreport.Show();
            var myForm = new ExecuteReportDateRange();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }
    }
}
