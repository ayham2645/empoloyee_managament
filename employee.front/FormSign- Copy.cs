using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace employee.front
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void email_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void video_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;

        private const int HT_CAPTION = 0x2;
        private void Form1_Load(object sender, EventArgs e)

        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 15;

            path.AddArc(0, 0, radius, radius, 180, 90);

            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);

            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            this.Region = new Region(path);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (namebox.Text == "") 
            {
            MessageBox.Show("Invalid User Name");
             namebox.Focus();
                return;
            }
            if (passbox.Text == "")
            {
                MessageBox.Show("Invalid Password");
                passbox.Focus();
                return;
            }
            else 
            {
            MessageBox.Show("Successfully Login");
             
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }
    }
}


