using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.Teacher
{
    public class TeacherController
    {
        public TeacherController() { }

        public void init(DataTable user, DataGridView grid1, DataGridView grid2, ComboBox comboBox1, Label label4)
        {
            DB db = new DB();
            DataTable group = new DataTable();
            group = db.getGroupName(Convert.ToInt32(user.Rows[0]["id"]));

            if (group.Rows.Count == 0)
            {
                MessageBox.Show("У вас отсутствует группа!");
                Application.Exit();
                return;
            }

            grid1.DataSource = db.getStudentsByGroup(Convert.ToInt32(user.Rows[0]["id"]));
            grid2.DataSource = db.getGradesByGroup(Convert.ToInt32(user.Rows[0]["id"]));

            comboBox1.DataSource = db.getStudentsByGroup(Convert.ToInt32(user.Rows[0]["id"]));
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";

            label4.Text = db.getGroupName(Convert.ToInt32(user.Rows[0]["id"])).Rows[0]["name"].ToString();
        }

        public void createGrade(TextBox textBox1, TextBox textBox2, DataGridView grid, ComboBox comboBox1, DataTable user)
        {
            string subject = textBox1.Text;

            if (int.TryParse(textBox2.Text, out int grade))
            {
                if (grade == 2 || grade == 3 || grade == 4 || grade == 5)
                {
                    if (textBox1.Text == "")
                    {
                        return;
                    }
                    DB db = new DB();
                    db.createGrade(subject, grade, Convert.ToInt32(comboBox1.SelectedValue));
                    grid.DataSource = db.getGradesByGroup(Convert.ToInt32(user.Rows[0]["id"]));
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное число.");

                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное число.");
            }
        }

        public void loadComboBox(DataTable user, ComboBox comboBox1)
        {
            DB db = new DB();
            comboBox1.DataSource = db.getStudentsByGroup(Convert.ToInt32(user.Rows[0]["id"]));
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";
        }

        public void deleteGrade(DataTable user, int selectedStudent, DataGridView grid2)
        {
            if (selectedStudent == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }

            DB db = new DB();
            db.deleteGrade(selectedStudent);
            grid2.DataSource = db.getGradesByGroup(Convert.ToInt32(user.Rows[0]["id"]));
        }
    }
}
