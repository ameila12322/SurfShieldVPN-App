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
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;

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

        private async void Connectbtn_Click(object sender, EventArgs e)
        {
           

            if (!buttonClicked)
            {
                

                if (servername.Text == "Netherlands")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config amsterdamudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(4000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;

                    }
                    else if (servername.Text == "Netherlands")
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config amsterdamtcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(4000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                    }
                }
                if (servername.Text == "USA")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config newyorkudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(4000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;


                    }
                    else if (servername.Text == "USA")
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config newyorktcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(4000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;

                    }
                }

                
            } 


            else
            {

                Connectbtn.Enabled = false;
                Process.Start(new ProcessStartInfo
                {
                    FileName = "taskkill",
                    Arguments = $"/f /im openvpn.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false
                }).WaitForExit();
                await Task.Delay(1000);
                Connectbtn.Text = "Connect";
                buttonClicked = false;
                Connectbtn.Enabled = true;
            }

            

        }



        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (!guna2ToggleSwitch1.Checked)
            {
                protocol.Text = "UDP";
            }
            else
            {
                protocol.Text = "TCP";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private async void ExternalIPlocation()
        {
            // Get the external IP address from ip-api.com
            string externalIP = "";
            try
            {
                string url = "http://ip-api.com/json/";
                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "Mozilla/5.0");
                var data = webClient.DownloadString(url);
                var loc = Newtonsoft.Json.JsonConvert.DeserializeObject<Location>(data);
                externalIP = loc.query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                externalIP = "External IP not found.";
            }
            labelIPAddress.Text = externalIP;

            // Get the location based on the external IP
            string location = "";
            try
            {
                string url = "http://ip-api.com/json/" + externalIP;
                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "Mozilla/5.0");
                var data = webClient.DownloadString(url);
                var loc = Newtonsoft.Json.JsonConvert.DeserializeObject<Location>(data);
                location = loc.country + ", " + loc.regionName + ", " + loc.city;
            }
            catch
            {
                location = "Location not found.";
            }
            labelLocation.Text = location;
        }
    }
}

public class Location
{
    public string status;
    public string country;
    public string countryCode;
    public string region;
    public string regionName;
    public string city;
    public string zip;
    public string lat;
    public string lon;
    public string timezone;
    public string isp;
    public string org;
    public string query;
}
