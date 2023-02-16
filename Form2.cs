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

namespace VPN
{
    public partial class Form2 : Form
    {
        bool rememberchk;
        
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
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
            createpg.Visible=false;
            guna2Transition1.HideSync(createpg);
        }

        private async void Loginbtn_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Wrong credentials");
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
            Form1 Form1= new Form1();
            Form1.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void mail()
        {
            string recipient = "surfshieldvpn@gmail.com";
            string subject = "New User account application";
            string body = "User details: " + newusername.Text + ", " + "Password-" + newpassword.Text + ", " + "Email:" + emailadd.Text;

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

        private void createaccbtn_Click(object sender, EventArgs e)
        {
            mail();
        }
    }


}
