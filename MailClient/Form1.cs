using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MailClient
{
    public partial class F_Login : Form
    {
     
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8DEJ0LF\SQLEXPRESS;Initial Catalog=Mail_Client;Integrated Security=True");
        public F_Login()
        {
            InitializeComponent();
            label_WrongCredential.Text = "";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
                Regex emailCheck = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                conn.Open();
                string username = txt_Username.Text;
                string password = txt_Password.Text;
                if (emailCheck.IsMatch(username)||emailCheck.IsMatch(password))
            {
                string sql = "select * from Account_Login where username = '" + username + "'and password = '" + password + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    F_MailBox newForm = new F_MailBox();
                    newForm.username = txt_Username.Text;
                    newForm.password = txt_Password.Text;
                    newForm.Show();
                    
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
             }
             else
             {
               MessageBox.Show("No special characters allowed");
             }
                conn.Close();
          
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
