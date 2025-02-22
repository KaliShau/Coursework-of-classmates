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
    public partial class Admin : Form
    {
        DataTable user;
        private int selectedUser = -1;
        private int selectedGroup = -1;
        private int selectedStudent = -1;
        public Admin(DataTable dt)
        {
            InitializeComponent();
            user = dt;

            DB db = new DB();
            dataGridView1.DataSource = db.getUsers();

            dataGridView2.DataSource = db.getGroups();

            dataGridView3.DataSource = db.getStudents();

            comboBox2.DataSource = db.getTeachers();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";

            comboBox3.DataSource = db.getGroups();
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string fio = textBox3.Text;

            if (username == "" || password == "" ||  fio == "")
            {
                return;
            }

            DB db = new DB();
            db.createUser(username, password, fio, Convert.ToString(comboBox1.Text));
            dataGridView1.DataSource = db.getUsers();


        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
                // Определяем, по какой строке и столбцу был клик
                var hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    // Выделяем строку
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    // Получаем значение столбца "request_id"
                    var cellValue = dataGridView1.Rows[hitTest.RowIndex].Cells[0].Value;

                    // Безопасно преобразуем значение в int
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int userId))
                    {
                        this.selectedUser = userId;
                    }
                    else
                    {
                        // Если значение не удалось преобразовать, сбрасываем selectedUser
                        this.selectedUser = -1;
                        MessageBox.Show("Некорректное значение в столбце id.");
                    }
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedUser == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }
            DB db = new DB();
            db.deleteUser(selectedUser);
            dataGridView1.DataSource = db.getUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedGroup == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }
            DB db = new DB();
            db.deleteGroup(selectedGroup);
            dataGridView2.DataSource = db.getGroups();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;

            if (name == "")
            {
                return;
            }

            DB db = new DB();
            db.createGroup(name, Convert.ToInt32(comboBox2.SelectedValue));
            dataGridView2.DataSource = db.getGroups();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            dataGridView1.DataSource = db.getUsers();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            dataGridView2.DataSource = db.getGroups();


            comboBox2.DataSource = db.getTeachers();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            dataGridView3.DataSource = db.getStudents();
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
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int groupId))
                {
                    this.selectedGroup = groupId;
                }
                else
                {
                    // Если значение не удалось преобразовать, сбрасываем selectedUser
                    this.selectedGroup = -1;
                    MessageBox.Show("Некорректное значение в столбце id.");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            comboBox2.DataSource = db.getTeachers();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            comboBox3.DataSource = db.getGroups();
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string username = textBox6.Text;
            string password = textBox5.Text;
            string fio = textBox7.Text;
            string number = textBox8.Text;
            string address = textBox9.Text;
            DateTime date = dateTimePicker1.Value;

            if (username == "" || password == "" || fio == "" ||  number == "" ||  address == "")
            {
                return;
            }

            DB db = new DB();
            db.createStudent(username,password, fio, number, address, date, Convert.ToInt32(comboBox3.SelectedValue));
            dataGridView3.DataSource = db.getStudents();
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            // Определяем, по какой строке и столбцу был клик
            var hitTest = dataGridView3.HitTest(e.X, e.Y);

            if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
            {
                // Выделяем строку
                dataGridView3.Rows[hitTest.RowIndex].Selected = true;

                // Получаем значение столбца "request_id"
                var cellValue = dataGridView3.Rows[hitTest.RowIndex].Cells[0].Value;

                // Безопасно преобразуем значение в int
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int studentId))
                {
                    this.selectedStudent = studentId;
                }
                else
                {
                    // Если значение не удалось преобразовать, сбрасываем selectedUser
                    this.selectedStudent = -1;
                    MessageBox.Show("Некорректное значение в столбце id.");
                }
            }
        }
    }
}
