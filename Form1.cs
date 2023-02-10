using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (!pn_menu.Visible)
                guna2Transition1.ShowSync(pn_menu);
            else
                guna2Transition1.HideSync(pn_menu);
        }

        private void Netherlands_Click(object sender, EventArgs e)
        {
            servername.Text = "Netherlands";
        }
    }
}
