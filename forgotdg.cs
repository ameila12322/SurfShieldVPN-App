using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN
{
    public partial class forgotdg : Form
    {
        public forgotdg()
        {
            InitializeComponent();
        }

        private void forgotpasswd_Click(object sender, EventArgs e)
        {
            if(emailreset.Text.Length >0)
            {
                 mailfp();
                MessageBox.Show("The password request was sent successfully!");
            }
            else
            {
                
                MessageBox.Show("Error: Please enter the email");
          

            }
        }

        private void mailfp()
        {
            string recipient = "surfshieldvpn@gmail.com";
            string subject = "Forgot password request";
            string body = "User forgot the password and requires a password retrieval. The user's E-mail ID is : " + emailreset.Text ;

            SmtpClient client = new SmtpClient("email-smtp.ap-northeast-1.amazonaws.com", 587);
            client.Credentials = new NetworkCredential("AKIAZWIQDHZBQABYKF4H", "BFZMfpk3wTEf5AAO2fHV4L5bBONtu6+IuKA5nqzW57l2");
            client.EnableSsl = true;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("sujayautodrift@gmail.com");
            message.To.Add(new MailAddress(recipient));
            message.Subject = subject;
            message.Body = body;

            client.Send(message);
        }
    }
}
