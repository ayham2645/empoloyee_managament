using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maktabi

{

    //            **************** ;) *****************
    public partial class FormFeedback : Form
    {

        string name = "";
        string feedb = "";


        public FormFeedback()
        {
            InitializeComponent();

            FormFeedback_rounded();

            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;  // connect the actions

            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;

            ratting.Text = "Rate me honestly <3 ";
        }




        private void FormFeedback_rounded()
        {
            // form rounded

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 40;

            path.AddArc(0, 0, radius, radius, 180, 90);

            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);

            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            this.Region = new Region(path);




        }

        // the send button
        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            feedb = textBox2.Text;


            if (ratting.Text == "Rate me honestly <3 ")
            {
                MessageBox.Show("Rate the application");
                return;
            }

            if ((name == " Enter your name" || string.IsNullOrWhiteSpace(name)) &&
                (feedb == " Enter your feedback" || string.IsNullOrWhiteSpace(feedb)))
            {
                MessageBox.Show("Enter your name and your feedback");
                textBox1.Focus();
                textBox2.Focus();
                return;

            }

            else if (name == " Enter your name" || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter your name");
                textBox1.Focus();
                return;
            }

            else if (feedb == " Enter your feedback" || string.IsNullOrWhiteSpace(feedb))
            {
                MessageBox.Show("Enter your feedback");
                textBox2.Focus();
                return;
            }

            MessageBox.Show("Thank you for your feedback :) ");
            SaveData();
            // reset
            textBox1.Text = " Enter your name";
            textBox2.Text = " Enter your feedback";
            trackBar1.Value = 0;
            ratting.Text = "Rate me honestly <3 ";



            return;


        }

        // save feedbacks to file
        private void SaveData()
        {

            try
            {

                using (System.IO.StreamWriter feedbackFile = new System.IO.StreamWriter("admins_file.txt", true))
                {

                    feedbackFile.WriteLine("From : " + name + ",Feedback :" + feedb + "Rate=" + trackBar1.Value + "(" + ratting.Text + ")");


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // panel rounded

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 40;

            path.AddArc(0, 0, radius, radius, 180, 90);

            path.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);

            path.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);

            panel1.Region = new Region(path);



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            // clear the text box to write 

            if (textBox1.Text == " Enter your name")
                textBox1.Text = "";

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            // return the default text when leave if the user dont write his name

            if (textBox1.Text == "")
                textBox1.Text = " Enter your name";
            textBox1.ForeColor = Color.Gray;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //panel rounded

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);

            path.AddArc(panel2.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(panel2.Width - radius, panel2.Height - radius, radius, radius, 0, 90);

            path.AddArc(0, panel2.Height - radius, radius, radius, 90, 90);

            panel2.Region = new Region(path);

        }

        private void FormFeedback_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_Leave(object sender, EventArgs e)
        {
            // return the default text 

            if (textBox2.Text == "")
                textBox2.Text = " Enter your feedback";
            textBox2.ForeColor = Color.Gray;

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            // clear the text box to write

            if (textBox2.Text == " Enter your feedback")
                textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);

            path.AddArc(panel3.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(panel3.Width - radius, panel3.Height - radius, radius, radius, 0, 90);

            path.AddArc(0, panel3.Height - radius, radius, radius, 90, 90);

            panel3.Region = new Region(path);

        }

        private void ratting_Click(object sender, EventArgs e)
        {






        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (trackBar1.Value)
            {
                case 0:
                    ratting.Text = "Withdraw";
                    break;
                case 1:
                    ratting.Text = "Oof";
                    break;
                case 2:
                    ratting.Text = " Very Bad";
                    break;
                case 3:
                    ratting.Text = "Bad";
                    break;
                case 4:
                    ratting.Text = "Need Work";
                    break;
                case 5:
                    ratting.Text = "Okay";
                    break;
                case 6:
                    ratting.Text = "Not Bad";
                    break;
                case 7:
                    ratting.Text = "Good";
                    break;
                case 8:
                    ratting.Text = "Very Good";
                    break;
                case 9:
                    ratting.Text = "Amazing";
                    break;
                case 10:
                    ratting.Text = "Perfect";
                    break;

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sad_Click(object sender, EventArgs e)
        {

        }
    }
}








