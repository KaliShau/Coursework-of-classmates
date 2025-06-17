using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.SignIn
{
    public class SignInController
    {
        public SignInController() { }

        public void signIn(TextBox textBox1, TextBox textBox2, Form form)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();
            dt = db.login(username, password);

            if (dt.Rows.Count == 1)
            {
                string role = Convert.ToString(dt.Rows[0]["role"]);
                if (role == "Admin")
                {
                    AdminForm admin = new AdminForm(dt);
                    form.Hide();
                    admin.Show();
                }
                if (role == "Teacher")
                {
                    TeacherForm teacher = new TeacherForm(dt);
                    form.Hide();
                    teacher.Show();
                }
                if (role == "Student")
                {
                    StudentForm student = new StudentForm(dt);
                    form.Hide();
                    student.Show();
                }
            }
        }
    }
}
