using System;
using System.Windows.Forms;

namespace Software.src.modules.Admin
{
    public class AdminController
    {
        public AdminController() { }

        public void init(DataGridView grid1, DataGridView grid2, DataGridView grid3, ComboBox comboBox2, ComboBox comboBox3)
        {
            DB db = new DB();

            grid1.DataSource = db.getUsers();
            grid2.DataSource = db.getGroups();
            grid3.DataSource = db.getStudents();

            comboBox2.DataSource = db.getTeachers();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";

            comboBox3.DataSource = db.getGroups();
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";
        }

        public void createUser(TextBox textBox1, TextBox textBox2, TextBox textBox3, ComboBox comboBox1, DataGridView grid1)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string fio = textBox3.Text;

            if (username == "" || password == "" || fio == "")
            {
                return;
            }

            DB db = new DB();
            db.createUser(username, password, fio, Convert.ToString(comboBox1.Text));
            grid1.DataSource = db.getUsers();
        }

        public void deleteUser(DataGridView grid1, int selectedId)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }

            DB db = new DB();
            db.deleteUser(selectedId);
            grid1.DataSource = db.getUsers();
        }

        public void createGroup(TextBox textBox4, ComboBox comboBox2, DataGridView grid2)
        {
            string name = textBox4.Text;

            if (name == "")
            {
                return;
            }

            DB db = new DB();
            db.createGroup(name, Convert.ToInt32(comboBox2.SelectedValue));
            grid2.DataSource = db.getGroups();
        }

        public void deleteGroup(DataGridView grid2, int selectedId)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }

            DB db = new DB();
            db.deleteGroup(selectedId);
            grid2.DataSource = db.getGroups();
        }

        public void createStudent(TextBox textBox6, TextBox textBox5, TextBox textBox7, TextBox textBox8, TextBox textBox9, DateTimePicker dateTimePicker1, ComboBox comboBox3, DataGridView grid3)
        {
            string username = textBox6.Text;
            string password = textBox5.Text;
            string fio = textBox7.Text;
            string number = textBox8.Text;
            string address = textBox9.Text;
            DateTime date = dateTimePicker1.Value;

            if (username == "" || password == "" || fio == "" || number == "" || address == "")
            {
                return;
            }

            DB db = new DB();
            db.createStudent(username, password, fio, number, address, date, Convert.ToInt32(comboBox3.SelectedValue));
            grid3.DataSource = db.getStudents();
        }

        public void deleteStudent(DataGridView grid3, int selectedId)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Выберете поле!");
                return;
            }

            DB db = new DB();
            db.deleteStudent(selectedId);
            grid3.DataSource = db.getStudents();
        }
    }
}
