using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WengLeePayroll
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //Connection String
        
        string conString = ConfigurationManager.ConnectionStrings["TimeCardConnectionString"].ConnectionString;
        //btn_Submit Click event
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_UserName.Text=="" || txt_Password.Text=="")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("Select * from Users where UserName=@username and Password=@password and isnull(Status,0)=1", con);
                cmd.Parameters.AddWithValue("@username",txt_UserName.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {

                    WengLeePayroll.appcode.PublicValues.UserId = int.Parse(ds.Tables[0].Rows[0]["UserAutoID"].ToString());
                    WengLeePayroll.appcode.PublicValues.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    WengLeePayroll.appcode.PublicValues.UserLevel=int.Parse(ds.Tables[0].Rows[0]["UserLevel"].ToString());
                    WengLeePayroll.appcode.PublicValues.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    //MessageBox.Show("Login Successful!");
                    this.Hide();
                    //Main fm = new Main();
                    //fm.Show();
                    MainMdi fm = new MainMdi();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.SteelBlue,
                                                                       Color.Black,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            WengLeePayroll.appcode.Common objCommon=new WengLeePayroll.appcode.Common();

            if (objCommon.DeveloperPc())
            {
                txt_UserName.Text = "Admin";
                txt_Password.Text = "ct123";
                //button1_Click(null, null);
            }
            
        }
    }
}
