using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_Bai06
{
    public partial class Bai06Form : Form
    {
        public Bai06Form()
        {
            InitializeComponent();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            Bai06Server server = new Bai06Server();
            server.Show();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            Bai06Client client = new Bai06Client();
            client.Show();
        }
    }
}
