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
            mastersToolStripMenuItem_Click(null, null);
            toolStripMenuItem1_Click(null, null);
            toolStripMenuItem2_Click(null, null);
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            ManageEmployee objManageEmployee = new ManageEmployee();
            objManageEmployee.Show();
        }

        private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmForm1 = new Masters { MdiParent = this };
            frmForm1.Show();
            
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
            var frmForm1 = new Reports { MdiParent = this };
            frmForm1.Show();
            //Reports objMain = new Reports();
            //objMain.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmForm1 = new Trans { MdiParent = this };
            frmForm1.Show();
            //Trans objMain = new Trans();
            //objMain.Show();
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
    }
}
