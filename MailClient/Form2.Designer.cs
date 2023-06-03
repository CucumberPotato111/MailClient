namespace MailClient
{
    partial class F_MailBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCompose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnIMAP = new System.Windows.Forms.Button();
            this.btnPOP3 = new System.Windows.Forms.Button();
            this.btnReceivedMail = new System.Windows.Forms.Button();
            this.btnSentMail = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCompose
            // 
            this.btnCompose.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCompose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompose.Location = new System.Drawing.Point(12, 23);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(96, 99);
            this.btnCompose.TabIndex = 0;
            this.btnCompose.Text = "Compose";
            this.btnCompose.UseVisualStyleBackColor = false;
            this.btnCompose.Click += new System.EventHandler(this.btnCompose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MailClient.Properties.Resources._4fbdc7de3e31de33862586c8db456f53;
            this.pictureBox1.Location = new System.Drawing.Point(372, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(114, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 493);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnIMAP
            // 
            this.btnIMAP.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnIMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMAP.Location = new System.Drawing.Point(194, 79);
            this.btnIMAP.Name = "btnIMAP";
            this.btnIMAP.Size = new System.Drawing.Size(75, 23);
            this.btnIMAP.TabIndex = 5;
            this.btnIMAP.Text = "IMAP";
            this.btnIMAP.UseVisualStyleBackColor = false;
            this.btnIMAP.Click += new System.EventHandler(this.btnIMAP_Click);
            // 
            // btnPOP3
            // 
            this.btnPOP3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPOP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOP3.Location = new System.Drawing.Point(290, 79);
            this.btnPOP3.Name = "btnPOP3";
            this.btnPOP3.Size = new System.Drawing.Size(75, 23);
            this.btnPOP3.TabIndex = 6;
            this.btnPOP3.Text = "POP3";
            this.btnPOP3.UseVisualStyleBackColor = false;
            this.btnPOP3.Click += new System.EventHandler(this.btnPOP3_Click);
            // 
            // btnReceivedMail
            // 
            this.btnReceivedMail.BackColor = System.Drawing.Color.LawnGreen;
            this.btnReceivedMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceivedMail.Location = new System.Drawing.Point(12, 143);
            this.btnReceivedMail.Name = "btnReceivedMail";
            this.btnReceivedMail.Size = new System.Drawing.Size(86, 41);
            this.btnReceivedMail.TabIndex = 8;
            this.btnReceivedMail.Text = "Received";
            this.btnReceivedMail.UseVisualStyleBackColor = false;
            this.btnReceivedMail.Click += new System.EventHandler(this.btnReceivedMail_Click);
            // 
            // btnSentMail
            // 
            this.btnSentMail.BackColor = System.Drawing.Color.LawnGreen;
            this.btnSentMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSentMail.Location = new System.Drawing.Point(12, 226);
            this.btnSentMail.Name = "btnSentMail";
            this.btnSentMail.Size = new System.Drawing.Size(86, 37);
            this.btnSentMail.TabIndex = 9;
            this.btnSentMail.Text = "Sent";
            this.btnSentMail.UseVisualStyleBackColor = false;
            this.btnSentMail.Click += new System.EventHandler(this.btnSentMail_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(837, 34);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(202, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LawnGreen;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(12, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 38);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // F_MailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1179, 626);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnSentMail);
            this.Controls.Add(this.btnReceivedMail);
            this.Controls.Add(this.btnPOP3);
            this.Controls.Add(this.btnIMAP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCompose);
            this.Name = "F_MailBox";
            this.Text = "Mail Box";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnIMAP;
        private System.Windows.Forms.Button btnPOP3;
        private System.Windows.Forms.Button btnReceivedMail;
        private System.Windows.Forms.Button btnSentMail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnDelete;
    }
}