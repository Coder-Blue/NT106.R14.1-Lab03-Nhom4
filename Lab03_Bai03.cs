using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NT106.R14._1_Lab03_Nhom4
{
    public partial class Lab03_Bai03 : Form
    {
        public Lab03_Bai03()
        {
            InitializeComponent();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            Lab03_Bai03_Server server = new Lab03_Bai03_Server();
            server.Show();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            Lab03_Bai03_Client client = new Lab03_Bai03_Client();
            client.Show();
        }
    }
}
