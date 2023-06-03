using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using MailKit.Net.Pop3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Outlook;

namespace MailClient
{


    public partial class F_MailBox : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8DEJ0LF\SQLEXPRESS;Initial Catalog=Mail_Client;Integrated Security=True");
        public  string username { get; set; }
        public  string password { get; set; }

        public F_MailBox()
        {
            InitializeComponent();
        }
        
        public class EmailInfo
        {
            public string Id { get; set; }
            public string From { get; set; }
            public DateTimeOffset TimeReceive { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public string FileAttactment { get; set; }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            btnReceivedMail.Enabled = false;
            txtUsername.Text = username;
        }
    
        //Show các record trong database
        private void dataGridViewLoadReceived_Email()
        {
            conn.Open();
            string query = "Select * from Email_Received";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            conn.Close();
        }
        private void dataGridViewLoadSent_Email()
        {
            conn.Open();
            string query = "Select * from Email_Sent";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            conn.Close();
        }
        //---


        
        private void toDatabaseReceived_Email()
        {
            conn.Open();

            string query = "INSERT INTO Email_Received ([From], [Time Received], Subject, Body, [File Attachment]) VALUES (@from_received, @time_received, @subject, @body, @file_attachment)";
            SqlCommand command = new SqlCommand(query, conn);

            
            command.Parameters.Add("@from_received", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@time_received", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@subject", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@body", SqlDbType.NVarChar).Value = DBNull.Value;
            command.Parameters.Add("@file_attachment", SqlDbType.NVarChar).Value = DBNull.Value;

            // Xoá tất cả
            string query2 = "DELETE FROM Email_Received";
            SqlCommand command2 = new SqlCommand(query2, conn);
            command2.ExecuteNonQuery();
            //Cập nhật lại
                foreach (DataGridViewRow row in dataGridView1.Rows)
                { 
                    try
                    {
                        
                        command.Parameters["@from_received"].Value = row.Cells[1].Value;
                        command.Parameters["@time_received"].Value = row.Cells[2].Value;
                        command.Parameters["@subject"].Value = row.Cells[3].Value;
                        command.Parameters["@body"].Value = row.Cells[4].Value;
                        command.Parameters["@file_attachment"].Value = row.Cells[5].Value;
                    command.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {

                        
                    }

                }
            conn.Close();

        } //Lưu vào Database

        private void btnCompose_Click(object sender, EventArgs e)
        {

            F_Compose form3 = new F_Compose();
            form3.username = this.username;
            form3.password = this.password;
            
            form3.Show();
        }
        private void btnPOP3_Click(object sender, EventArgs e)
        {
                var client = new Pop3Client();          
                client.Connect("pop.gmail.com", 995, true);
                // Kiểm tra credential
                client.Authenticate(username, password);
                int count = client.GetMessageCount();
                // Tạo datatable để lưu
                DataTable listEmail = new DataTable();
                listEmail.Columns.Add("ID");
                listEmail.Columns.Add("From");
                listEmail.Columns.Add("Date");
                listEmail.Columns.Add("Subject");
                listEmail.Columns.Add("Body");
                listEmail.Columns.Add("Attachments");

                // Lấy email rồi cho data vào datatable

                for (int i = 0; i < count; i++)
                {
                    MimeMessage message = client.GetMessage(i);
                    // Các field của email
                    string id = (i + 1).ToString();
                    string from = message.From.ToString();
                    string date = message.Date.ToString();
                    string subject = message.Subject;
                    string body = message.TextBody;
                    string attachments = "";
                    if (message.Attachments != null )
                    {
                        foreach (MimePart attachment in message.Attachments)
                        {
                            attachments += attachment.FileName + "; ";
                        }
                    }
                    // add the email details to the DataTable
                    listEmail.Rows.Add(id, from, date, subject, body, attachments);
                }
                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = listEmail;
                toDatabaseReceived_Email();              
            
        }

        private  void btnIMAP_Click(object sender, EventArgs e)
        {
            var listEmail = new List<EmailInfo>();
            var mailClient = new ImapClient();
            mailClient.Connect("imap.gmail.com", 993);
            // Kiểm tra credential
            mailClient.Authenticate(username, password);
            var folder =  mailClient.Inbox;
            folder.Open(FolderAccess.ReadOnly);
            // Lấy các field của email
            IList<UniqueId> uids = folder.Search(SearchQuery.All);
            foreach (UniqueId uid in uids)
            {
                MimeMessage message = folder.GetMessage(uid);
                var emailInfo = new EmailInfo();
                emailInfo.Id = uid.ToString();
                emailInfo.From = message.From.ToString();
                emailInfo.TimeReceive = message.Date;
                emailInfo.Subject = message.Subject;
                emailInfo.Body = message.TextBody;
                var fileAttacthment = new List<string>();


                foreach (MimeEntity attachment in message.Attachments)
                {
                    var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                    fileAttacthment.Add(fileName);

                    using (var stream = File.Create(fileName))
                    {
                        if (attachment is MessagePart)
                        {
                            var rfc822 = (MessagePart)attachment;

                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)attachment;

                            part.Content.DecodeTo(stream);
                        }
                    }
                }
                emailInfo.FileAttactment = string.Join("", fileAttacthment);
                listEmail.Add(emailInfo);

            }
            dataGridView1.DataSource = listEmail;
            toDatabaseReceived_Email();
        }

        private void btnReceivedMail_Click(object sender, EventArgs e)
        {
            btnSentMail.Enabled = true;      
            btnReceivedMail.Enabled = false;
            dataGridViewLoadReceived_Email();
            
        }

        private void btnSentMail_Click(object sender, EventArgs e)
        {
            btnReceivedMail.Enabled = true;
            btnSentMail.Enabled=false;
            dataGridViewLoadSent_Email();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form4 readMail = new Form4();
            //Chuyển data sang form đọc mail
            readMail.txtFrom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            readMail.lbDateReceived.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            readMail.txtSubject.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            readMail.txtBody.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            readMail.txtAttachment.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            readMail.ShowDialog();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Trỏ vào Row hiện tại
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

            // Lấy số ID
            int primaryKeyValue = Convert.ToInt32(selectedRow.Cells[0].Value);

            // Xoá record          
             string deleteQuery = "DELETE FROM Email_Received WHERE ID=@PrimaryKeyValue";
                        
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);

                cmd.Parameters.Add("@PrimaryKeyValue", SqlDbType.Int).Value = primaryKeyValue;

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully!");

                        // Xoá Row trong datagridview
                        dataGridView1.Rows.Remove(selectedRow);
                    }
                    else
                    {
                        MessageBox.Show("No records were deleted.");
                    }
                    conn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        
    }
}
