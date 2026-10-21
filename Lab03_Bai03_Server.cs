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
    public partial class Lab03_Bai03_Server : Form
    {
        private Socket listenerSocket;
        private Socket clientSocket;
        private Thread serverThread;

        public Lab03_Bai03_Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;
            serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            try
            {
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);

                lstLog.Items.Add("Server started!");

                clientSocket = listenerSocket.Accept();
                lstLog.Items.Add("Connection accepted from " + clientSocket.RemoteEndPoint.ToString());

                byte[] recv = new byte[1024];
                while (clientSocket.Connected)
                {
                    int bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived == 0) break;

                    string text = Encoding.UTF8.GetString(recv, 0, bytesReceived);

                    if (text.Trim() == "quit")
                    {
                        lstLog.Items.Add("Client disconnected.");
                        break;
                    }

                    string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        lstLog.Items.Add("From client: " + line.Trim());
                    }
                }

                clientSocket.Close();
                listenerSocket.Close();
                btnListen.Enabled = true;
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Error: " + ex.Message);
            }
        }
    }
}
