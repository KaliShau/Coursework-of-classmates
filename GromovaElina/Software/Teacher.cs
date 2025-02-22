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
    public partial class Teacher : Form
    {
        DataTable user;
        private int selectedStudent = -1;

        public Teacher(DataTable user)
        {
            InitializeComponent();
            this.user = user;

            DB db = new DB();

           DataTable group = new DataTable();
            group = db.getGroupName(Convert.ToInt32(user.Rows[0]["id"]));

            if (group.Rows.Count == 0)
            {
                MessageBox.Show("У вас отсутствует группа!");
                Application.Exit();
                return;
            }

            dataGridView1.DataSource = db.getStudentsByGroup(Convert.ToInt32(user.Rows[0]["id"]));
            dataGridView2.DataSource = db.getGradesByGroup(Convert.ToInt32(user.Rows[0]["id"]));

            comboBox1.DataSource = db.getStudentsByGroup(Convert.ToInt32(user.Rows[0]["id"]));
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";

            label4.Text = "Группа: " + db.getGroupName(Convert.ToInt32(user.Rows[0]["id"])).Rows[0]["name"];
        }

        private void Teacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subject = textBox1.Text;

            if (int.TryParse(textBox2.Text, out int grade))
            {
                // Преобразование прошло успешно, grade содержит число
                if (grade == 2 || grade == 3 || grade == 4 || grade == 5)
                {
                    if (textBox1.Text == "")
                    {
                        return;
                    }
                    DB db = new DB();
                    db.createGrade(subject, grade, Convert.ToInt32(comboBox1.SelectedValue));
                    dataGridView2.DataSource = db.getGradesByGroup(Convert.ToInt32(user.Rows[0]["id"]));
                } else
                {
                    MessageBox.Show("Пожалуйста, введите корректное число.");

                }

            }
            else
            {
                // Преобразование не удалось, введено не число
                MessageBox.Show("Пожалуйста, введите корректное число.");
            }

            

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            comboBox1.DataSource = db.getStudentsByGroup(Convert.ToInt32(user.Rows[0]["id"]));
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            // Определяем, по какой строке и столбцу был клик
            var hitTest = dataGridView2.HitTest(e.X, e.Y);

            if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
            {
                // Выделяем строку
                dataGridView2.Rows[hitTest.RowIndex].Selected = true;

                // Получаем значение столбца "request_id"
                var cellValue = dataGridView2.Rows[hitTest.RowIndex].Cells[0].Value;

                // Безопасно преобразуем значение в int
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int student_id))
                {
                    this.selectedStudent = student_id;
                }
                else
                {
                    // Если значение не удалось преобразовать, сбрасываем selectedUser
                    this.selectedStudent = -1;
                    MessageBox.Show("Некорректное значение в столбце id.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedStudent == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }
            DB db = new DB();
            db.deleteGrade(selectedStudent);
            dataGridView2.DataSource = db.getGradesByGroup(Convert.ToInt32(user.Rows[0]["id"]));
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
