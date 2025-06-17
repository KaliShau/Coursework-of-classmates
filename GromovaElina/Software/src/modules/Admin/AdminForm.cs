using System;
using System.Data;
using System.Windows.Forms;
using Software.src.modules.Admin;

namespace Software
{
    public partial class AdminForm : Form
    {
        AdminController _controller;
        DataTable user;

        private int selectedId = -1;

        public AdminForm(DataTable dt)
        {
            InitializeComponent();
            user = dt;

            _controller = new AdminController();
            _controller.init(dataGridView1, dataGridView2, dataGridView3, comboBox2, comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.createUser(textBox1, textBox2, textBox3, comboBox1, dataGridView1);
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    string id = dataGridView1.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();
                    selectedId = Convert.ToInt16(id);

                    contextMenuStrip1.Items.Clear();

                    var menuItem = new ToolStripMenuItem("Удалить");
                    menuItem.Name = "deletewMenuItem";
                    menuItem.Click += (s, args) =>
                    {
                        _controller.deleteUser(dataGridView1, selectedId);
                    };

                    contextMenuStrip1.Items.Add(menuItem);
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView2.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    dataGridView2.Rows[hitTest.RowIndex].Selected = true;

                    string id = dataGridView2.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();
                    selectedId = Convert.ToInt16(id);

                    contextMenuStrip1.Items.Clear();

                    var menuItem = new ToolStripMenuItem("Удалить");
                    menuItem.Name = "deletewMenuItem";
                    menuItem.Click += (s, args) =>
                    {
                        _controller.deleteGroup(dataGridView2, selectedId);
                    };

                    contextMenuStrip1.Items.Add(menuItem);
                    contextMenuStrip1.Show(dataGridView2, e.Location);
                }
            }
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView3.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    dataGridView3.Rows[hitTest.RowIndex].Selected = true;

                    string id = dataGridView3.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();
                    selectedId = Convert.ToInt16(id);

                    contextMenuStrip1.Items.Clear();

                    var menuItem = new ToolStripMenuItem("Удалить");
                    menuItem.Name = "deletewMenuItem";
                    menuItem.Click += (s, args) =>
                    {
                        _controller.deleteStudent(dataGridView3, selectedId);
                    };

                    contextMenuStrip1.Items.Add(menuItem);
                    contextMenuStrip1.Show(dataGridView3, e.Location);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _controller.createGroup(textBox4, comboBox2, dataGridView2);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DB().getUsers();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = new DB().getGroups();
            comboBox2.DataSource = new DB().getTeachers();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = new DB().getStudents();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            comboBox2.DataSource = db.getTeachers();
            comboBox2.DisplayMember = "full_name";
            comboBox2.ValueMember = "id";
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.DataSource = new DB().getGroups();
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _controller.createStudent(textBox6, textBox5, textBox7, textBox8, textBox9, dateTimePicker1, comboBox3, dataGridView3);
        }
    }
}
