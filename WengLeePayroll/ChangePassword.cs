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
    public partial class ChangePassword : Form
    {
        string PayId = "";
        public ChangePassword()
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
                string UserName = WengLeePayroll.appcode.PublicValues.UserName;
                int userLevel = WengLeePayroll.appcode.PublicValues.UserLevel;
                string OldPassword = WengLeePayroll.appcode.PublicValues.Password;

                if (OldPassword != txtOld.Text)
                {
                    MessageBox.Show("Old password mismatch. Please enter correct old password.");
                    txtOld.Focus();
                    return;
                }
                if (txtNewPass.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Password can't be blank. Please enter a password.");
                    txtNewPass.Focus();
                    return;
                }

                if (txtNewPass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("New Password mismatch. Please enter same one as new password.");
                    txtNewPass.Focus();
                    return;
                }
                
                SaveData objSD = new SaveData();
                objSD.ChangePassword(WengLeePayroll.appcode.PublicValues.UserId, txtNewPass.Text);
                WengLeePayroll.appcode.PublicValues.Password = txtNewPass.Text;
                MessageBox.Show("Password change successful.");
                
                txtOld.Text = "";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! Please contact system admin.");
            }
        }
        

        private void frmPayPeriod_Load(object sender, EventArgs e)
        {
            
        }


    }
}
