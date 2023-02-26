using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.IO;
using MimeKit;
using System.Text.RegularExpressions;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using static System.Net.WebRequestMethods;
using System.IdentityModel.Protocols.WSTrust;
using System.Runtime.ConstrainedExecution;

namespace SurfShield
{
    public partial class Form2 : Form
    {
        bool rememberchk;
        string otp;
       
       
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            createpg.BorderRadius = 25;

        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            createpg.Visible = true;
            guna2Transition1.ShowSync(createpg);
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            createpg.Visible = false;
            // Retrieve the saved username and password from the application settings
            string savedUsername = Properties.Settings.Default.Username;
            string savedPassword = Properties.Settings.Default.Password;
            bool savedremember = Properties.Settings.Default.RememberMe;
            // Autofill the text boxes if "Remember Me" is checked
            if (savedremember == true)
            {

                txtUsername.Text = savedUsername;
                txtPassword.Text = savedPassword;

            }

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            createpg.Visible = false;
            guna2Transition1.HideSync(createpg);
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            // Set your connection string here
            string connectionString = "Server=vpndb-do-user-13474542-0.b.db.ondigitalocean.com;Port=25060;Database=User_authentication;User Id=doadmin;Password=AVNS_p8XCGKsbkYveUlC7z2V;";


            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM users WHERE Username = @Username AND Password = @Password";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);

                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Credentials matched, load the main form
                    Form1 Form1 = new Form1();
                    Form1.Show();
                    this.Hide();
                    // Save credentials if "Remember Me" is checked
                    if (chkRememberMe.Checked)
                    {
                        rememberchk = true;
                        Properties.Settings.Default.Username = txtUsername.Text;
                        Properties.Settings.Default.Password = txtPassword.Text;
                        Properties.Settings.Default.RememberMe = rememberchk;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    // Credentials didn't match, display a message box
                    error2 form = new error2();
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }



        public string GetText()
        {
            // Return the text in the textbox
            return txtUsername.Text;
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public string Getotp()
        {
            // Return the text in the textbox
            return otp;
        }

        private void otpverifymail()
        {
            Random random = new Random();
            otp = random.Next(100000, 999999).ToString();

            var smtpClient = new SmtpClient("email-smtp.ap-northeast-1.amazonaws.com", 587)
            {
                Credentials = new NetworkCredential("AKIAZWIQDHZBU57BCVPH", "BCT8AAuoJ3UkBcuP+VTyesA71zJLf+TVfCG60xc86CUw"),
                EnableSsl = true
            };

            // Email message configuration
            var message = new MailMessage("surfshieldvpn@gmail.com", emailadd.Text)
            {
                Subject = "Email verification",
                Body = "As a VPN service provider, SurfShield takes user security and privacy seriously." +
                " To ensure that our users' accounts are protected, we require email verification when setting up an account. " +
                "After registering, an OTP (One-Time Password) is sent to the user's email address. This OTP is a unique code that is only valid for a single use and provides an additional layer of security to the account." +
                "By verifying their email address, users can be confident that their SurfShield account is secure and protected from unauthorized access." +
                "The OTP is :  " + otp
            };

            // Send the email
            smtpClient.Send(message);
           
           
            otpverify form = new otpverify();
            form.Owner = this;
            form.ShowDialog();
            
        }



        private async void createaccbtn_Click(object sender, EventArgs e)
        {
  
            if (newusername.Text.Length > 0 && newpassword.Text.Length > 0 && verifypass.Text.Length > 0 && emailadd.Text.Length > 0)
            {

                if (newpassword.Text == verifypass.Text)
                {
                        otpverifymail();
                        acccreate form = new acccreate();
                    
                        form.ShowDialog();
                    
                }
                else
                {
                    error form = new error();
                    form.ShowDialog();

                }
            }
            else
            {
                error1 form = new error1();
                form.ShowDialog();
            }
        }

        private void forgot_Click(object sender, EventArgs e)
        {
            forgotdg form = new forgotdg();
            form.ShowDialog();
        }

        private string GenerateRandomToken()
        {
            // Generate a random string of 16 characters
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public void register()
        {
            
            

            string Username = newusername.Text;
            string Password = newpassword.Text;
            string Email = emailadd.Text;
            // Set your connection string here
            string connectionString = "Server=vpndb-do-user-13474542-0.b.db.ondigitalocean.com;Port=25060;Database=User_authentication;User Id=doadmin;Password=AVNS_p8XCGKsbkYveUlC7z2V;";


            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            try
            {
                connection.Open();
                string input = "INSERT INTO users (Username, Password, Email) VALUES (@Username, @Password, @Email)";

                NpgsqlCommand cmd = new NpgsqlCommand(input, connection);

                // add parameters for the values to be inserted
                cmd.Parameters.AddWithValue("@Username", newusername.Text);
                cmd.Parameters.AddWithValue("@Password", newpassword.Text);
                cmd.Parameters.AddWithValue("@Email", emailadd.Text);

                // execute the SQL statement
                cmd.ExecuteNonQuery();

                // close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show(ex.Message);
            }

        }


    }

}
