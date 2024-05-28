using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using KeyAuth;
using System.Runtime.InteropServices;
using System.Management;



namespace Loader
{
    public partial class spoofer : Form
    {
        public spoofer()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        public static extern bool BlockInput(bool fkk);
        public static IntPtr currenthandle()
        {
            return Process.GetCurrentProcess().MainWindowHandle;
        }
        public static string GetWMICProperty(string className, string propertyName)
        {
            string propertyValue = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + className);

            foreach (ManagementObject obj in searcher.Get())
            {
                if (obj[propertyName] != null)
                {
                    propertyValue = obj[propertyName].ToString();
                    break;
                }
            }

            return propertyValue;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            label1.Text = $@"Disks> 
{GetWMICProperty("Win32_DiskDrive", "Model")}
{GetWMICProperty("Win32_DiskDrive", "SerialNumber")}

Motherboard> 
{GetWMICProperty("Win32_BaseBoard", "SerialNumber")}

BIOS>
{GetWMICProperty("Win32_BIOS", "SerialNumber")}

BIOS UUID>
{GetWMICProperty("Win32_ComputerSystemProduct", "UUID")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            system main = new system();
            main.StartPosition = FormStartPosition.Manual;
            main.Location = this.Location;
            main.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\Windows"))
            {
                Directory.CreateDirectory("C:\\Windows");
            }
            await Task.Run(() => CMD("start C:\\Windows\\cleaner.bat"));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            woofload main = new woofload();
            main.Show();
            this.Hide();

            System.Windows.MessageBox.Show("Press OK to begin, wait for 2 beeps", "Diamond-Service", MessageBoxButton.OK);
            await Task.Run(() =>CMD("C:\\Windows\\AMIDEWINx64.exe /SU AUTO", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe /BS %RANDOM%W%RANDOM%S%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe /SS %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /IVN %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /IV %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /SM %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /SP %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /SV %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /SK %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /SF %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /BM %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /BP %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /BV %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /BT %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /BLC %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /CM %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /CV %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /CA %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /CSK %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /PSN %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /PAT %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => CMD("C:\\Windows\\AMIDEWINx64.exe  /PPN %RANDOM%%RANDOM%%RANDOM%", true));
            await Task.Run(() => Console.Beep(500, 500));
            await Task.Run(() => CMD("net stop winmgmt /y", true));
            await Task.Run(() => Console.Beep(500, 500));
            await Task.Run(() => Task.Delay(1500).Wait());
        }
#pragma warning disable CS1998 // Bei der asynchronen Methode fehlen "await"-Operatoren. Die Methode wird synchron ausgeführt.
        public static async void CMD(string cmd, bool showoutput = false)
#pragma warning restore CS1998 // Bei der asynchronen Methode fehlen "await"-Operatoren. Die Methode wird synchron ausgeführt.
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + cmd; // /c means execute the command and then terminate
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            if (showoutput)
            {
                Console.WriteLine(output);
            }
            process.WaitForExit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            label1.Text = $@"Disks> 
{GetWMICProperty("Win32_DiskDrive", "Model")}
{GetWMICProperty("Win32_DiskDrive", "SerialNumber")}

Motherboard> 
{GetWMICProperty("Win32_BaseBoard", "SerialNumber")}

BIOS>
{GetWMICProperty("Win32_BIOS", "SerialNumber")}

BIOS UUID>
{GetWMICProperty("Win32_ComputerSystemProduct", "UUID")}";
        }

        private void siticoneControlBox3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label4_Click(object sender, EventArgs e)
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

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            warninfo main3 = new warninfo();
            main3.Show();
            this.Hide();
        }
    }
}
