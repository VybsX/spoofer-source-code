using KeyAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader
{
    public partial class updates : Form
    {
        public updates()
        {
            InitializeComponent();
        }



        private void updates_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            updates main = new updates();
            main.StartPosition = FormStartPosition.Manual;
            main.Location = this.Location;
            main.Show();
            this.Hide();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
