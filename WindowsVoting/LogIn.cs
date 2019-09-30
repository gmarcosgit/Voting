using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsVoting
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!SetError())
                return;
            else
                new frmMainHome().Show();
                Hide();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            AcceptButton = btnLogin;
        }

        private bool SetWarningifEmpty(TextBox txtbox)
        {
            bool Ereturn = new bool();
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                errorProviderLogin.SetError(txtbox, "Please fill up the fields");
                txtbox.Focus();
                Ereturn = false;
            }
            else
            {
                errorProviderLogin.Dispose();
                Ereturn = true;
            }

            return Ereturn;
        }

        private bool SetError()
        {
            if (!SetWarningifEmpty(txtBoxUserName) | !SetWarningifEmpty(txtBoxPassword))
            {
                return false;
            }
            return true;
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            //// Get the IP  
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            var addresses = Dns.GetHostEntryAsync((Dns.GetHostName()))
                .Result
                .AddressList
                .Where(x => x.AddressFamily  == AddressFamily.InterNetwork)
                .Select(x => x.ToString())
                .ToArray();
            MessageBox.Show("My IP Address is :" + addresses);
            //!= AddressFamily.InterNetworkV6 && x.AddressFamily
        }
    }
}
