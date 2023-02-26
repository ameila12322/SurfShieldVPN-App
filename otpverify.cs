using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SurfShield
{
    public partial class otpverify : Form
    {
        string otp;
        public otpverify()
        {
            InitializeComponent();
            Form2 Form2 = (Form2)Application.OpenForms["Form2"];
            if (Form2 != null)
                otp = Form2.Getotp();
            
        }

       
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Check if the entered OTP matches the generated OTP
            if (OTPTextBox.Text == otp)
            {
               
                otp = "";
                this.Close();

            }
            else
            {
                // If the OTP does not match, notify the user
                MessageBox.Show("Invalid OTP!");
               
            }

        }
        public string getuserotp()
        {
            return OTPTextBox.Text;
        }

        private void otpverify_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            ((Form2)Owner).register();
        }
    }
}
