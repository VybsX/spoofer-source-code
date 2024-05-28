using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows;

namespace Loader
{
    public partial class woofload : Form
    {
        public woofload()
        {
            InitializeComponent();
        }

        private async Task woofload_LoadAsync(object sender, EventArgs e)
        {

            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 300000;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();

            System.Windows.MessageBox.Show("Press OK to begin, wait for 2 beeps", "Diamond Solutions", MessageBoxButton.OK);
            label4.Text = "Spoofing...";
            label4.Visible = true;
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe /SU AUTO", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe /BS %RANDOM%W%RANDOM%S%RANDOM%", true));
            await Task.Run(() => Console.Beep(500, 500));
            await Task.Run(() => CMD("net stop winmgmt /y", true));
            await Task.Run(() => Console.Beep(500, 500));
            await Task.Run(() => Task.Delay(1500).Wait());
        }

        private void CMD(string v1, bool v2)
        {
            throw new NotImplementedException();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);

            if (progressBar1.Value == 10)
            {
                label4.Text = "Spoofing your pc";
                label4.Visible = true;
            }

            if (progressBar1.Value == 15)
            {
                label1.Text = "Please wait";
                label1.Visible = true;
            }

            if (progressBar1.Value == 20)
            {
                label2.Text = "- Spoofed your Bios UUID";
                label2.Visible = true;
            }

            if (progressBar1.Value == 30)
            {
                label3.Text = "- Spoofed your Motherboard Serial Number";
                label3.Visible = true;
            }

            if (progressBar1.Value == 40)
            {
                label5.Text = "- Spoofed your SystemSerial";
                label5.Visible = true;
            }

            if (progressBar1.Value == 50)
            {
                label6.Text = "- Spoofed your Baseboard Serialnumber";
                label6.Visible = true;
            }


            if (progressBar1.Value == 60)
            {
                label7.Text = "- Spoofed your BIOS vendor name";
                label7.Visible = true;
            }

            if (progressBar1.Value == 70)
            {
                label8.Text = "- Spoofed your System SKU Number";
                label8.Visible = true;
            }

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                spoofer main = new spoofer();
                main.Show();
                this.Hide();
            }
        }

        private void woofload_Load_1(object sender, EventArgs e)
        {

        }
    }
}
