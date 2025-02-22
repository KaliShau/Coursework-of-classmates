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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username == "" ||  password == "")
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
                    Admin admin = new Admin(dt);
                    this.Hide();
                    admin.Show();
                }
                if (role == "Teacher")
                {
                    Teacher teacher = new Teacher(dt);
                    this.Hide();
                    teacher.Show();
                }
                if (role == "Student")
                {
                    Student student = new Student(dt);
                    this.Hide();
                    student.Show();
                }
            }
        }
    }
}
