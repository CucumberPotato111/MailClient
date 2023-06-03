using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Data.SqlClient;

namespace MailClient
{
    public partial class F_Compose : Form
    {
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8DEJ0LF\SQLEXPRESS;Initial Catalog=Mail_Client;Integrated Security=True");
        public F_Compose()
        {
            InitializeComponent();
        }
        public string username { get; set; }
        public string password { get; set; }


        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtTo != null && !string.IsNullOrWhiteSpace(txtTo.Text) || 
                txtSubject != null && !string.IsNullOrWhiteSpace(txtSubject.Text) || 
                rtxtMessage != null && !string.IsNullOrWhiteSpace(rtxtMessage.Text))
            {                                 
                        MailMessage mail = new MailMessage(txtFrom.Text, txtTo.Text, txtSubject.Text, rtxtMessage.Text);
                        if (!string.IsNullOrEmpty(txtAttachment.Text))
                        {
                            mail.Attachments.Add(new Attachment(txtAttachment.Text.ToString()));
                        }
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new NetworkCredential(username,password);
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mail);                  
                        toDatabaseSent_Email();               
            }
            else
            {
                MessageBox.Show("Please don't leave boxes blank");
            }
        

        }
        private void toDatabaseSent_Email()
        {
            string from = txtFrom.Text;
            string to = txtTo.Text;
            string timesent = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
            string subject = txtSubject.Text;
            string body = rtxtMessage.Text;
            string fileattachment = txtAttachment.Text;


            conn.Open();

            string query = "INSERT INTO Email_Sent ([From], [To], [Time Sent], Subject, Body, [File Attachment]) VALUES (@from, @to, @timesent, @subject, @body, @fileattachment)";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.Add("@from", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@to", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@timesent", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@subject", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@body", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@fileattachment", SqlDbType.NVarChar).Value = DBNull.Value;


            command.Parameters["@from"].Value = from;
            command.Parameters["@to"].Value = to;
            command.Parameters["@timesent"].Value = timesent;
            command.Parameters["@subject"].Value = subject;
            command.Parameters["@body"].Value = body;
            command.Parameters["@fileattachment"].Value = fileattachment;


            command.ExecuteNonQuery();
            conn.Close();
            

        } //Lưu vào database
       
        private void F_Compose_Load(object sender, EventArgs e)
        {
            
            txtFrom.Text = username;
            
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();           
            openFileDialog.Title = "Select File";
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                string path = openFileDialog.FileName.ToString();
                txtAttachment.Text = path;
            }
        }

    }
}
