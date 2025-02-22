using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public partial class Student : Form
    {
        DataTable user;
        public Student(DataTable user)
        {
            InitializeComponent();
            this.user = user;

            DB db = new DB();
            dataGridView1.DataSource = db.getGradesStudents(Convert.ToInt32(user.Rows[0]["id"]));
            label2.Text = "ФИО - " + user.Rows[0]["full_name"];

            DataTable student = new DataTable();
            student = db.getStudentsByUser(Convert.ToInt32(user.Rows[0]["id"]));
            label3.Text = "День рождение - " + student.Rows[0]["birth_date"];
            label4.Text = "Адреc - " + student.Rows[0]["address"];
            label5.Text = "Телефон - " + student.Rows[0]["phone"];
        }

        private void Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
