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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mailClientEmail = "kadar.marcell69@gmail.com";
            string mailClientPassword = "bpvo jgkd rcmg vruv";
            string administratorEmail = "kadar.marcell69@gmail.com";
            var smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = mailClientEmail,
                    Password = mailClientPassword
                }
                
            };
            string schoolName = "None-School";
            MailAddress fromEmail = new MailAddress(mailClientEmail, schoolName);
            MailAddress toEmail = new MailAddress(administratorEmail, "Administrator");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = "Forgot Password by a User",
                Body = "A user who goes by the email replacemail has forgotten their password! Please, contact them as soon as possible to resolve this issue.".Replace("replacemail", textBox1.Text),
            };

            message.To.Add(toEmail);

            try
            {
                smtpClient.Send(message);
                MessageBox.Show("The Administrator has been notified of your forgotten password! Please, wait until they contact you for further instructions.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
