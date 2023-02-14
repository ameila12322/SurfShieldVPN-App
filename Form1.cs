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
using System.IO;
using System.Timers;
using System.Net.NetworkInformation;

namespace VPN
{
    public partial class Form1 : Form
    {
        private string lblloc;
        private string lblip;
        private long initialDataSent;
        private long initialDataReceived;
        private bool buttonClicked = false;
        int timeSec, timeMin, timeCs;
        bool isActive;
        public Form1()
        {
            InitializeComponent();
            Connectbtn.Text = "Connect";
            Connectbtn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            localip();



        }

        private void setlocalipdetails()
        {
            labelIPAddress.Text = lblip;
            labelLocation.Text = lblloc;
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
                isActive = true;
                starttrackdata();

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
                        await Task.Delay(12000);
                        ExternalIPlocation();
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if(labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }

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
                        await Task.Delay(12000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }
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
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }

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
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }
                    }
                }

                if (servername.Text == "Singapore")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config singaporeudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }

                    }
                    else if (servername.Text == "Singapore")
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config singaporetcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }
                    }
                }

                if (servername.Text == "UK")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config unitedkingdomudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }

                    }
                    else if (servername.Text == "UK")
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config unitedkingdomtcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }
                    }
                }

                if (servername.Text == "Japan")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config Japanudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }

                    }
                    else if (servername.Text == "Japan")
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config Japantcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }
                    }
                }

                if (servername.Text == "Australia")
                {
                    if (!guna2ToggleSwitch1.Checked)
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config Australiaudp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with udp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }

                    }
                    else if (servername.Text == "Australia")
                    {
                        Connectbtn.Enabled = false;
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                        startInfo.Arguments = "--config Australiatcp.ovpn";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        await Task.Delay(6000);
                        Connectbtn.Text = "Disconnect";
                        buttonClicked = true;
                        MessageBox.Show("You've connected to server with tcp");
                        ExternalIPlocation();
                        Connectbtn.Enabled = true;
                        await Task.Delay(5000);
                        if (labelLocation.Text == "Bangalore,India")
                        {
                            ExternalIPlocation();
                        }
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

                await Task.Delay(2000);
                Connectbtn.Text = "Connect";
                buttonClicked = false;
                Connectbtn.Enabled = true;
                setlocalipdetails();
                isActive = false;
                ResetTime();



            }



        }


        private void ResetTime()
        {
            timeMin = 0;
            timeCs = 0;
            timeSec = 0;
            DU.Text = "";
            DS.Text = "";
            DR.Text = "";
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
            
            timeSec = 0;
            timeCs = 0;
            timeMin = 0;
            isActive = false;
            
        }

        private string GetPublicIpAddress()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

            request.UserAgent = "curl"; // this will tell the server to return the information as if the request was made by the linux "curl" command

            string publicIPAddress;

            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    publicIPAddress = reader.ReadToEnd();
                }
            }

            return publicIPAddress.Replace("\n", "");
        }
        private async System.Threading.Tasks.Task<string> GetLocation(string ipAddress)
        {
            string url = $"http://ip-api.com/json/{ipAddress}";
            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);
                dynamic locationData = JsonConvert.DeserializeObject(json);
                string location = locationData.city + ", " + locationData.regionName + ", " + locationData.country;
                return location;
            }
        }

        //local ip functions
        private async void localip()
        {
            labelIPAddress.Text = GetPublicIpAddress();
            string ipAddress = labelIPAddress.Text;
            string location = await GetLocation(ipAddress);
            labelLocation.Text = location;
            lblip = labelIPAddress.Text;
            lblloc = labelLocation.Text;
        }

        private void starttrackdata()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            initialDataSent = 0;
            initialDataReceived = 0;

            foreach (NetworkInterface nic in nics)
            {
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();
                initialDataSent += interfaceStats.BytesSent;
                initialDataReceived += interfaceStats.BytesReceived;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                long dataSent = 0;
                long dataReceived = 0;

                foreach (NetworkInterface nic in nics)
                {
                    IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();
                    dataSent += interfaceStats.BytesSent;
                    dataReceived += interfaceStats.BytesReceived;
                }

                dataSent -= initialDataSent;
                dataReceived -= initialDataReceived;

                double dataSentMB = dataSent / 1048576.0;
                double dataReceivedMB = dataReceived / 1048576.0;
                double totalDataMB = dataReceivedMB + dataSentMB;   
                DS.Text = dataSentMB.ToString("0.0" + "MB");
                DR.Text = dataReceivedMB.ToString("0.0" + "MB");
                DU.Text = totalDataMB.ToString("0.0" + "MB");
                timeCs++;
                if (timeCs >= 100)
                {
                    timeSec++;
                    timeCs = 0;
                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }
            DrawTime();
        }

        //vpn ip functions
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
                location = loc.city + "," + loc.country;
            }
            catch
            {
                location = "Location not found.";
            }
            labelLocation.Text = location;
        }

        

        private void DrawTime()
        {
            lblmin.Text = String.Format("{0,00}", timeMin);
            lblsec.Text = String.Format("{0,00}", timeSec);
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
