using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maktabi
{
    public partial class main : Form
    {
        
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        DataTable table = new DataTable();   // table to represent employee جدول لاظهار بيانات الموظفين


        public main()
        {
            InitializeComponent();

            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.RowTemplate.Height = 30;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;


                
            table.Columns.Add("Id",typeof(int));
            table.Columns.Add("Name",typeof(string));
            table.Columns.Add("Salary",typeof(double));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Experience", typeof(int));

            dataGridView1.DataSource = table;           // connect the table with datagridview ربطنا الجدول بالداتا جريد حتى اقدر اعرضهم بالشاشة


            // عند اعادة تشغيل البرنامج بدي اعرض بيانات الموظفين اللي ضفتها مسبقا

            employee emp = new employee();
            for(int i = 0; i < emp.employeeCount(); i++)
            {
                string[] info = emp.employeeData(i);
                table.Rows.Add(Convert.ToInt32( info[0]), info[1],Convert.ToDouble(info[2]), info[3], Convert.ToInt32(info[4]));
            }




        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        // the exit button (X)

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DataGridView GetDataGridView1()
        {
            return dataGridView1;
        }

        // the delete buttun

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var row = dataGridView1.CurrentRow;
          if (row.IsNewRow) {
            MessageBox.Show("Cannot delete the new (empty) row.");     
            return;
                         }

          

           dataGridView1.EndEdit();
           bindingSource1?.EndEdit(); 

    var drv = row.DataBoundItem as DataRowView;

    if (drv != null) 
            {
    drv.Row.Delete();          
    new employee().remove_update(table);
                textBox1.Text = textBox2.Text = textBox3.Text = ey.Text = "";
                radioButton1.Checked = false; // male gender
                radioButton2.Checked = false; //female gender
}
        }

        // add button

        private void button3_Click(object sender, EventArgs e)
        {
            if (!TryValidateInputs(out int id, out string name, out double salary))
                return;

            employee emp = new employee();

            emp.Id = Convert.ToInt32(textBox1.Text);
            emp.Name = textBox2.Text;
            emp.salary = Convert.ToDouble(textBox3.Text);
            emp.gender = gender;
            emp.experience = Convert.ToInt32(ey.Text);
            table.Rows.Add(emp.Id, emp.Name, emp.salary, emp.gender, emp.experience);
            emp.add();
            
          
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            ey.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        int indexRow;

        // method to show the data selected in text boxs for editing
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { if (e.RowIndex >= 0) { 
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            ey.Text = row.Cells[4].Value.ToString();
                if (row.Cells[3].Value.ToString()=="Female") radioButton2.Checked = true;
                if (row.Cells[3].Value.ToString() == "Male") radioButton1.Checked = true;
        }


        }
        
        // update button
        private void button4_Click(object sender, EventArgs e)
        {
            if (!TryValidateInputs(out int id, out string name, out double salary))
                return;

            if (indexRow >= 0)
            {
                DataGridViewRow newData = dataGridView1.Rows[indexRow];

                newData.Cells[0].Value = Convert.ToInt32(textBox1.Text);
                newData.Cells[1].Value = textBox2.Text;
                newData.Cells[2].Value = Convert.ToDouble(textBox3.Text);
                newData.Cells[4].Value = Convert.ToInt32(ey.Text);
                if (radioButton1.Checked) newData.Cells[3].Value = "Male";
                if (radioButton2.Checked) newData.Cells[3].Value = "Female";

                employee emp = new employee();
                emp.remove_update(table);
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            ey.Text = "";
            radioButton2.Checked = false;
            radioButton1.Checked = false;
        }

        // method to check the input (check empty field , input type)

        private bool TryValidateInputs(out int id, out string name, out double salary)
        {
            id = 0;
            name = string.Empty;
            salary = 0;

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text)||
                 string.IsNullOrWhiteSpace(ey.Text) || 
                 (!(radioButton2.Checked)&&!(radioButton1.Checked)))
            {
                MessageBox.Show("Please fill in all fields.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out id))
            {
                MessageBox.Show("ID must be an integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }

            name = textBox2.Text.Trim();
            if (!name.Any(char.IsLetter))
            {
                MessageBox.Show("Name must contain letters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return false;
            }

            if (!double.TryParse(textBox3.Text.Trim(), out salary))
            {
                MessageBox.Show("Salary must be a numeric value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return false;
            }


            if (!int.TryParse(ey.Text.Trim(), out int exp) || exp < 0)
            {
                MessageBox.Show("Experience must be a positive number.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ey.Focus();
                return false;
            }

            return true;

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        string gender;

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender=radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender=radioButton2.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        // compare button
        private void Compare_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 2)
            {
                MessageBox.Show("Please select exactly 2 employees to compare.",
                                "Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row1 = dataGridView1.SelectedRows[0];
            var row2 = dataGridView1.SelectedRows[1];

            string name1 = row1.Cells[1].Value.ToString();
            double salary1 = Convert.ToDouble(row1.Cells[2].Value);
            int exp1 = Convert.ToInt32(row1.Cells[4].Value);

            string name2 = row2.Cells[1].Value.ToString();
            double salary2 = Convert.ToDouble(row2.Cells[2].Value);
            int exp2 = Convert.ToInt32(row2.Cells[4].Value);

            double score1 = GetSalaryScore(exp1, salary1);
            double score2 = GetSalaryScore(exp2, salary2);

            string result;
            if (score1 < score2)
                result = $" {name1} is more suitable to keep.\n" +
                         $" Consider letting go of {name2}.";
            else if (score2 < score1)
                result = $" {name2} is more suitable to keep.\n" +
                         $" Consider letting go of {name1}.";
            else
                result = $" Both {name1} and {name2} have equal suitability.\n" +
                         $"You can let go of either one of them.";

            MessageBox.Show(result, "Comparison Result",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double GetSalaryScore(int experience, double salary)
        {
            if (experience == 0) experience = 1;
            return salary / experience;
        }

        private void ey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
