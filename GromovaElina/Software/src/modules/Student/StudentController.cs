using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.Student
{
    public class StudentController
    {
        public StudentController() { }

        public void init(DataGridView grid, DataTable user, Label label2, Label label3, Label label4, Label label5)
        {
            DB db = new DB();
            grid.DataSource = db.getGradesStudents(Convert.ToInt32(user.Rows[0]["id"]));
            label2.Text = "ФИО - " + user.Rows[0]["full_name"];

            DataTable student = new DataTable();
            student = db.getStudentsByUser(Convert.ToInt32(user.Rows[0]["id"]));
            label3.Text = "День рождение - " + student.Rows[0]["birth_date"];
            label4.Text = "Адреc - " + student.Rows[0]["address"];
            label5.Text = "Телефон - " + student.Rows[0]["phone"];
        }
    }
}
