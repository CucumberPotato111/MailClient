using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            F_Compose newForm= new F_Compose();
            newForm.txtTo.Text = txtFrom.Text;
            newForm.ShowDialog();
        }

       

       
    }
}
