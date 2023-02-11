using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VPN
{
    public partial class Form1 : Form
    {
        private bool buttonClicked = false;
        public Form1()
        {
            InitializeComponent();
            Connectbtn.Text = "Connect";
            Connectbtn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (!pn_menu.Visible)
                guna2Transition1.ShowSync(pn_menu);
            else
                guna2Transition1.HideSync(pn_menu);
        }
          
        private void Netherlands_Click_1(object sender, EventArgs e)
        {
            servername.Text = "Netherlands";
        }

        private void USA_Click(object sender, EventArgs e)
        {
            servername.Text = "USA";
        }

        private void Singapore_Click(object sender, EventArgs e)
        {
            servername.Text = "Singapore";
        }

        private void UK_Click(object sender, EventArgs e)
        {
            servername.Text = "UK";
        }

        private void Japan_Click(object sender, EventArgs e)
        {
            servername.Text = "Japan";
        }

        private void Australia_Click(object sender, EventArgs e)
        {
            servername.Text = "Australia";
        }

        private void Connectbtn_Click(object sender, EventArgs e)
        {
            if (!buttonClicked)
            {
                Connectbtn.Text = "Disconnect";
                buttonClicked = true;

                if (servername.Text == "Netherlands")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config amsterdamudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        MessageBox.Show("You've connected to server with udp");

                    }
                    else if (servername.Text == "Netherlands")
                    {

                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config amsterdamtcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        MessageBox.Show("You've connected to server with tcp");

                    }
                }
                if (servername.Text == "USA")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config newyorkudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        MessageBox.Show("You've connected to server with udp");

                    }
                    else if (servername.Text == "USA")
                    {

                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config newyorktcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        MessageBox.Show("You've connected to server with tcp");

                    }
                }
            }
            else
            {
                Connectbtn.Text= "Connect";
                buttonClicked = false;
                Process.Start(new ProcessStartInfo
                {
                    FileName = "taskkill",
                    Arguments = $"/f /im openvpn.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false
                }).WaitForExit();
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(!guna2ToggleSwitch1.Checked)
            {
                protocol.Text = "UDP";
            }
            else
            {
                protocol.Text = "TCP";
            }
        }

    }
}
