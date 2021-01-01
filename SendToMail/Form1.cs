using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendToMail
{
    public partial class Form1 : Form
    {
        string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Your-title";
            file.ShowDialog();
            filePath = file.FileName;
            MessageBox.Show("File is Uploaded");
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            string to = textBox1.Text;
            string subject = textBox2.Text;
            string text = textBox3.Text;

            sc.Credentials = new NetworkCredential("your-mail", "your-mail-password");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("your-mail");
            mail.To.Add(to);
            //mail.To.Add("cc2@mail.com");
            //mail.CC.Add("cc3@mail.com");
            //mail.CC.Add("cc4@mail.com");
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = text;
            mail.Attachments.Add(new Attachment(filePath));
            sc.Send(mail);
            MessageBox.Show("Mail is Send");
        }
    }
}
