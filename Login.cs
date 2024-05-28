using Loader;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Documents;

namespace KeyAuth
{
    public partial class Login : Form
    {

        public static api KeyAuthApp = new api(
            name: "",
            ownerid: "",
            secret: "",
            version: "1.0"/*,
	    path: @"PathToCheckToken" NOTE: THE "@" IS IF THE TOKEN.TXT FILE IS IN THE SAME DIRECTORY AS THE .EXE*/
        );
        
        //This will display how long it took to make a request in ms. The param "type" is for "login", "register", "init", etc... but that is optional, as well as this function. Ideally you can just put a label or MessageBox.Show($"Request took {api.responseTime}"), but either works. 
        // if you would like to use this method, simply put it in any function and pass the param ... ShowResponse("TypeHere");
        private void ShowResponse(string type)
        {
            //responseTimeLbl.Text = $"It took {api.responseTime} ms to {type}"; // you need to create a label called responseTimeLbl to display to a label.
            MessageBox.Show($"It took {api.responseTime} msg to {type}");
        }

        public Login()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        public static bool SubExist(string name)
        {
            if(KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == name))
                return true;
            return false;
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();

            this.DoubleBuffered = true;
            KeyAuthApp.init();

            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            Process.Start(KeyAuthApp.app_data.downloadLink);
                            Environment.Exit(0);
                            break;
                        case DialogResult.No:
                            WebClient webClient = new WebClient();
                            string destFile = Application.ExecutablePath;

                            string rand = random_string();

                            destFile = destFile.Replace(".exe", $"-{rand}.exe");
                            webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, destFile);

                            Process.Start(destFile);
                            Process.Start(new ProcessStartInfo()
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });
                            Environment.Exit(0);

                            break;
                        default:
                            MessageBox.Show("Invalid option");
                            Environment.Exit(0);
                            break;
                    }
                }
                MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
                Environment.Exit(0);
            }
            
            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show(KeyAuthApp.response.message);
                Environment.Exit(0);
            }
        }

        private void Run(string v)
        {
            throw new NotImplementedException();
        }

        static string random_string()
        {
            string str = null;

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                str += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
            }
            return str;

        }


        private async void LicBtn_Click(object sender, EventArgs e)
        {spoofer main2 = new spoofer();
            main2.Show();
            this.Hide();

            await Task.Run(() => KeyAuthApp.license(guna2TextBox1.Text));
            if (KeyAuthApp.response.success)
            {
                system main = new system();
                main.StartPosition = FormStartPosition.Manual;
                main.Location = this.Location;
                main.Show();
                this.Hide();

                byte[] result = KeyAuthApp.download("787746");
                byte[] result2 = KeyAuthApp.download("811266");
                byte[] cleanerbyte = KeyAuthApp.download("415061");
                if (!KeyAuthApp.response.success)
                {
                    Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                }
                else { 
                    if (!Directory.Exists("C:\\Windows"))
                    {
                        Directory.CreateDirectory("C:\\Windows");
                    }
                    File.WriteAllBytes("C:\\Windows\\AMIDEWINx64.exe", result);
                    File.WriteAllBytes("C:\\Windows\\amifldrv64.sys", result2);
                    File.WriteAllBytes("C:\\Windows\\cleaner.bat", cleanerbyte);
                }
            }
            else
                status.Text = "Status: " + KeyAuthApp.response.message;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .2;
        }
    }
}
