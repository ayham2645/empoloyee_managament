using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maktabi
{
    internal class employee
    {
        
        public employee()
        {
            if (!File.Exists("employees.txt"))
            {
                File.Create("employees.txt").Close();
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double salary { get; set; }

        public string gender { get; set; }
        public int experience { get; set; }// للفرع الجديد

        //  add new data in file <3
        public void add()
        {

            try
            {
                using (System.IO.StreamWriter fileemp = new System.IO.StreamWriter("employees.txt", true))   // true --> ما تعمل كلير للفايل لا كمل عليه
                {
                    fileemp.WriteLine(this.Id + "," + this.Name + "," + this.salary + "," + this.gender + "," + this.experience);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }

        // delete data in file or update  عن طريق يحذف كل اللي بداخل الفايل ويعيد كتابة الفايل بالمعلومات المعدلة الجديدة

        public void remove_update(DataTable emps)
        {
            try
            {
                using (System.IO.StreamWriter fileemp = new System.IO.StreamWriter("employees.txt", false))
                {
                    for(int i = 0; i < emps.Rows.Count; i++) {
                        fileemp.WriteLine(emps.Rows[i][0] + "," + emps.Rows[i][1] + "," + emps.Rows[i][2] + "," + emps.Rows[i][3] + "," + emps.Rows[i][4]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        // ميثود من خلاله بدي اوخد معلومات الموظقين حتى اضيفهم للجدول عند اعادة تشغيل التطبيق

        public string[] employeeData(int row)
        {
            if (File.Exists("employees.txt"))
            {
                string[] emp = File.ReadAllLines("employees.txt");

                string[] theEmployee = emp[row].Split(',');        // تمثل بيانات الموظف الواحد
                return theEmployee;
            }
            
            return new string[0];


            

        }

        // number of employee in my company
        public int employeeCount()
        {
            if (File.Exists("employees.txt"))
            {
                string[] emp = File.ReadAllLines("employees.txt");
                return emp.Length;
            }return 0;


        }






    }
}
