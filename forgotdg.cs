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
using Npgsql;

namespace SurfShield
{
    public partial class forgotdg : Form
    {
        public forgotdg()
        {
            InitializeComponent();
        }

        private void forgotpasswd_Click(object sender, EventArgs e)
        {
            if (emailreset.Text.Length > 0)
            {
                mailfp();
                MessageBox.Show("The password request was sent successfully!" +
                    " Kindly check your email.");
            }
            else
            {

                MessageBox.Show("Error: Please enter a valid email address");


            }
        }

        private void mailfp()
        {

            string connString = "Server=vpndb-do-user-13474542-0.b.db.ondigitalocean.com;Port=25060;Database=User_authentication;User Id=doadmin;Password=AVNS_p8XCGKsbkYveUlC7z2V;";

            // Define the SQL query to select the password for a given email
            string sqlQuery = "SELECT password FROM users WHERE email = @email";

            // Create a new Npgsql connection using the connection string
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                // Open the database connection
                conn.Open();

                // Create a new Npgsql command using the SQL query and connection
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, conn))
                {
                    // Add the email parameter to the SQL query
                    cmd.Parameters.AddWithValue("@email", emailreset.Text);

                    // Execute the SQL query and retrieve the result
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if the reader has any rows
                        if (reader.HasRows)
                        {
                            // Read the first row of the result
                            reader.Read();

                            // Get the password value from the "password" column in the row
                            string password = reader.GetString(reader.GetOrdinal("password"));

                            string recipient = emailreset.Text;
                            string subject = "Forgot password request";
                            string body = "Dear [User],\r\n\r\nWe understand that sometimes you may forget your password and require assistance to regain access to your SurfShield VPN account. As a trusted VPN service provider, we take your account security and privacy very seriously.\r\n\r\nIn response to your password recovery request, we have retrieved your password from our secure database and are providing it to you in this email. Please ensure that you keep this information confidential and do not share it with anyone." +
                                "\r\n\r\nYour Password is :" + password + " \r\n\r\nThank you for choosing SurfShield VPN to protect your online privacy and security.\r\n\r\nBest regards,\r\n\r\nThe SurfShield VPN Team";

                            SmtpClient client = new SmtpClient("email-smtp.ap-northeast-1.amazonaws.com", 587);
                            client.Credentials = new NetworkCredential("AKIAZWIQDHZBQABYKF4H", "BFZMfpk3wTEf5AAO2fHV4L5bBONtu6+IuKA5nqzW57l2");
                            client.EnableSsl = true;

                            MailMessage message = new MailMessage();
                            message.From = new MailAddress("surfshieldvpn@gmail.com");
                            message.To.Add(new MailAddress(recipient));
                            message.Subject = subject;
                            message.Body = body;
                            client.Send(message);
                        }
                        else
                        {
                            // If the reader has no rows, the email does not exist in the database
                            MessageBox.Show("Email not found.");
                        }




                    }

                }
            }
        }
    }
}
    

