using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_Bai06
{
    public partial class Bai06Client : Form
    {
        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;
        private string myName;

        public Bai06Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            btnSend.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn trước khi kết nối!");
                return;
            }

            try
            {
                myName = txtName.Text.Trim();
                tcpClient = new TcpClient("127.0.0.1", 8080);
                UTF8Encoding utf8NoBom = new UTF8Encoding(false);
                reader = new StreamReader(tcpClient.GetStream(), utf8NoBom);
                writer = new StreamWriter(tcpClient.GetStream(), utf8NoBom) { AutoFlush = true };

                writer.WriteLine(myName);

                btnConnect.Enabled = false;
                txtName.ReadOnly = true;
                btnSend.Enabled = true;
                this.Text = "Client - " + myName;

                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến Server: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (writer == null || string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            string msg = txtMessage.Text.Trim();
            string selectedTarget = lstParticipants.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedTarget) || selectedTarget == "All (Chat chung)")
            {
                writer.WriteLine($"PUBLIC|{msg}");
                lstChatBox.Items.Add($"Me: {msg}");
            }
            else
            {
                writer.WriteLine($"PRIVATE|{selectedTarget}|{msg}");
                lstChatBox.Items.Add($"Me (riêng tới {selectedTarget}): {msg}");
            }

            txtMessage.Clear();
        }

        private void ReceiveMessages()
        {
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.TrimStart('\uFEFF', '\u200B').Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split(new[] { '|' }, 2);
                    string type = parts[0];
                    string content = parts.Length > 1 ? parts[1] : "";

                    if (type == "MSG")
                    {
                        lstChatBox.Items.Add(content);
                    }
                    else if (type == "USERS")
                    {
                        lstParticipants.Items.Clear();
                        lstParticipants.Items.Add("All (Chat chung)");

                        string[] users = content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string u in users)
                        {
                            if (u != myName)
                            {
                                lstParticipants.Items.Add(u);
                            }
                        }
                        lstParticipants.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
                lstChatBox.Items.Add("You left the group.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                tcpClient?.Close();
            }
            catch { }
        }
    }
}
