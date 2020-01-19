using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace LAB_10_11P
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emailAddr = this.textBox1.Text;
            string receiversEmailAddr = this.textBox3.Text;
            string password = this.textBox2.Text;
            string message = this.richTextBox1.Text;

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(emailAddr.Trim());
            mail.To.Add(receiversEmailAddr);
            mail.Subject = this.textBox4.Text;
            mail.Body = message;
            mail.IsBodyHtml = false;

            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailAddr, password);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message);
            }
            
        }

        //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string realpass = "";
        //    if (e.KeyChar == (Char)Keys.Back)
        //        realpass += realpass.Substring(0, realpass.Length - 2);
        //    realpass += e.KeyChar.ToString();
        //    textBox1.Text = "";
        //    for (int i = 0; i < realpass.Length; i++)
        //        textBox1.Text += "*";
        //}
    }
}
