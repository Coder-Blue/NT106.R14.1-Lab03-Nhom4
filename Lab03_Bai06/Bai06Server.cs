using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_Bai06
{
    public partial class Bai06Server : Form
    {
        private TcpListener tcpListener;
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();
        private readonly object lockObj = new object();
        private readonly UTF8Encoding utf8NoBom = new UTF8Encoding(false);

        public Bai06Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;
            Thread listenThread = new Thread(ListenForClients);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ListenForClients()
        {
            tcpListener = new TcpListener(IPAddress.Any, 8080);
            tcpListener.Start();
            lstServerLog.Items.Add("Server started on port 8080...");

            while (true)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch
                {
                    break;
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            string clientName = "";
            try
            {
                StreamReader reader = new StreamReader(client.GetStream(), utf8NoBom);

                clientName = reader.ReadLine()?.TrimStart('\uFEFF', '\u200B').Trim();
                if (string.IsNullOrEmpty(clientName)) return;

                lock (lockObj)
                {
                    if (clients.ContainsKey(clientName))
                    {
                        clientName += "_" + new Random().Next(100, 999);
                    }
                    clients.Add(clientName, client);
                }

                string remoteEndPoint = client.Client.RemoteEndPoint.ToString();
                lstServerLog.Items.Add($"New client connected from {remoteEndPoint} ({clientName})");

                BroadcastMessage($"[Hệ thống]: {clientName} đã tham gia phòng chat.", "");
                SendUserListToAll();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.TrimStart('\uFEFF', '\u200B').Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split('|');
                    string type = parts[0];

                    if (type == "PUBLIC" && parts.Length >= 2)
                    {
                        string msg = parts[1];
                        lstServerLog.Items.Add($"{clientName}: {msg}");
                        BroadcastMessage($"{clientName}: {msg}", clientName);
                    }
                    else if (type == "PRIVATE" && parts.Length >= 3)
                    {
                        string targetUser = parts[1];
                        string msg = parts[2];
                        lstServerLog.Items.Add($"[Private] {clientName} -> {targetUser}: {msg}");
                        SendPrivateMessage(clientName, targetUser, msg);
                    }
                }
            }
            catch { }
            finally
            {
                if (!string.IsNullOrEmpty(clientName))
                {
                    lock (lockObj)
                    {
                        clients.Remove(clientName);
                    }
                    lstServerLog.Items.Add($"{clientName} left the group.");
                    BroadcastMessage($"{clientName} left the group.", clientName);
                    SendUserListToAll();
                }
                client.Close();
            }
        }

        private void BroadcastMessage(string message, string excludeUser)
        {
            lock (lockObj)
            {
                foreach (var pair in clients)
                {
                    if (pair.Key != excludeUser)
                    {
                        try
                        {
                            StreamWriter writer = new StreamWriter(pair.Value.GetStream(), utf8NoBom) { AutoFlush = true };
                            writer.WriteLine("MSG|" + message);
                        }
                        catch { }
                    }
                }
            }
        }

        private void SendPrivateMessage(string sender, string targetUser, string message)
        {
            lock (lockObj)
            {
                if (clients.ContainsKey(targetUser))
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(clients[targetUser].GetStream(), utf8NoBom) { AutoFlush = true };
                        writer.WriteLine($"MSG|[Riêng từ {sender}]: {message}");
                    }
                    catch { }
                }
            }
        }

        private void SendUserListToAll()
        {
            lock (lockObj)
            {
                string userList = string.Join(",", clients.Keys);
                foreach (var pair in clients)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(pair.Value.GetStream(), utf8NoBom) { AutoFlush = true };
                        writer.WriteLine("USERS|" + userList);
                    }
                    catch { }
                }
            }
        }
    }
}
