using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader
{
    public partial class warninfo : Form
    {
        int toastX, toastY;
        public warninfo()
        {
            InitializeComponent();
        }

        private void warninfo_Load(object sender, EventArgs e)
        {
            int screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenwidth - this.Width;
            toastY = screenheight - this.Height;

            this.Location = new Point(toastX, toastY);
        }

        int y = 100;
        private void timer2_Tick(object sender, EventArgs e)
        {
            y--;
            if (y <= 0)
            {
                toastY += 1;
                this.Location = new Point(toastX, toastY += 10);
                if (toastY > 800)
                {
                    timer2.Stop();
                    y = 100;
                    this.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toastY -= 5;
            this.Location = new Point(toastX, toastY);
            if (toastY < 975)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
    }
}
