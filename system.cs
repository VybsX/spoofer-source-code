using KeyAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader
{
    public partial class system : Form
    {
        public system()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = "Pc Name: " + System.Net.Dns.GetHostName();
            label7.Text = "Windows Version: " + RuntimeInformation.OSDescription;
            label3.Text = "Architecture: " + RuntimeInformation.OSArchitecture;
            label2.Text = "ProcessorCount: " + Environment.ProcessorCount;
            label1.Text = "Processor Model: " + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            label12.Text = "Processor Level: " + Environment.GetEnvironmentVariable("PROCESSOR_LEVEL");
            label13.Text = "SystemDirectory: " + Environment.SystemDirectory;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            system main = new system();
            main.StartPosition = FormStartPosition.Manual;
            main.Location = this.Location;
            main.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            spoofer main = new spoofer();
            main.StartPosition = FormStartPosition.Manual;
            main.Location = this.Location;
            main.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            updates main = new updates();
            main.StartPosition = FormStartPosition.Manual;
            main.Location = this.Location;
            main.Show();
            this.Hide();
        }
    }
}
