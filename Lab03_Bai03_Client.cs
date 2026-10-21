using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace NT106.R14._1_Lab03_Nhom4
{
    public partial class Lab03_Bai03_Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream ns;

        public Lab03_Bai03_Client()
        {
            InitializeComponent();
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.tcpClient = new TcpClient();
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);

                this.tcpClient.Connect(ipEndPoint);

                this.ns = this.tcpClient.GetStream();

                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến Server: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.ns != null && !string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text + "\n");
                this.ns.Write(data, 0, data.Length);
                txtMessage.Clear();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (this.ns != null)
            {
                byte[] data = Encoding.UTF8.GetBytes("quit\n");
                this.ns.Write(data, 0, data.Length);

                this.ns.Close();
                this.tcpClient.Close();

                btnConnect.Enabled = true;
                btnSend.Enabled = false;
                btnDisconnect.Enabled = false;
            }
        }
    }
}
