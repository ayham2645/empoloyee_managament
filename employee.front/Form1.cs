using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Maktabi
{
    
    public partial class Form1 : Form
    {

        private List<(string, string)> adminsInfo = new List<(string, string)>(); // perform admins name and password
        

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        public Form1()
        {
            InitializeComponent();

            adminsInfo.Add(("Yara", "1234"));
            adminsInfo.Add(("Ayham", "0000"));
            saveDate();
            startpage();
            Form1_rounded();
            

        }

        // save the admin information in file
        private void saveDate()
        {


            try
            {

                using (System.IO.StreamWriter adminFile = new System.IO.StreamWriter("admins_file.txt", true))
                {
                    for (int i = 0; i < adminsInfo.Count; i++)
                    {
                        adminFile.WriteLine(adminsInfo[i].Item1 + "," + adminsInfo[i].Item2);
                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }


        }

        // begin with start page
        private void startpage()
        {
            label1.Hide();
            button2.Hide();
            pass.Hide();
            passbox.Hide();
            name.Hide();
            namebox.Hide();
            pictureBox2.Hide();
            pictureBox1.Hide();
            label.Hide();

            pictureBox4.Show();
            l.Show();
            linkLabel1.Show();




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

        // exit button (X)
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;

        private const int HT_CAPTION = 0x2;
        private void Form1_rounded()

        {
           
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);

            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);

            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            this.Region = new Region(path);


           
            


        }


        // log in button
        private void button2_Click(object sender, EventArgs e)
        {
            if (namebox.Text == "" && passbox.Text == "")
            {
                MessageBox.Show("Invalid Admin Name & Password");
                namebox.Focus();
                passbox.Focus();
                return;
            }

            else if (namebox.Text == "")
            {
                MessageBox.Show("Invalid Admin Name");
                namebox.Focus();
                return;
            }
            else if (passbox.Text == "")
            {
                MessageBox.Show("Invalid Password");
                passbox.Focus();
                return;
            }
            else if ((passbox.Text == adminsInfo[0].Item2 && namebox.Text == adminsInfo[0].Item1) ||
                     (passbox.Text == adminsInfo[1].Item2 && namebox.Text == adminsInfo[1].Item1))
            {

                // go to (main) form
                main f = new main();
                this.Hide();
                f.ShowDialog();
                

            }
            else if ((passbox.Text == adminsInfo[0].Item2 && namebox.Text != adminsInfo[0].Item1) ||
                        (passbox.Text == adminsInfo[1].Item2 && namebox.Text != adminsInfo[1].Item1) ||
                        (passbox.Text != adminsInfo[0].Item2 && namebox.Text != adminsInfo[0].Item1) ||
                      (passbox.Text != adminsInfo[1].Item2 && namebox.Text != adminsInfo[1].Item1))
            {
                MessageBox.Show("Wrong Admin name or Password");
                passbox.Focus();
                namebox.Focus();
                return;
            }
            else if ((passbox.Text != adminsInfo[0].Item2 && namebox.Text == adminsInfo[0].Item1) ||
                        (passbox.Text != adminsInfo[1].Item2 && namebox.Text == adminsInfo[1].Item1))
            {
                MessageBox.Show("Wrong Password");
                passbox.Focus();
                return;
            }
           
        }
            




        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
        //********
        
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }  

        private void namebox_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // start button take us to log in page
        private void l_Click(object sender, EventArgs e)
        {
            label1.Show();
            button2.Show();
            pass.Show();
            passbox.Show();
            name.Show();
            namebox.Show();
            pictureBox2.Show();
            pictureBox1.Show();
            label.Show();

            pictureBox4.Hide();
            l.Hide();
            linkLabel1.Hide();


        }

        // feedback lapel link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormFeedback f = new FormFeedback();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}


