using System;
using System.Data;
using System.Windows.Forms;
using Software.src.modules.Teacher;

namespace Software
{
    public partial class TeacherForm : Form
    {
        DataTable user;
        private int selectedStudent = -1;
        TeacherController _controller;
        public TeacherForm(DataTable user)
        {
            InitializeComponent();
            this.user = user;

            _controller = new TeacherController();
            _controller.init(user, dataGridView1, dataGridView2, comboBox1, label4);
        }

        private void Teacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.createGrade(textBox1, textBox2, dataGridView2, comboBox1, user);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            _controller.loadComboBox(user, comboBox1);
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
                    selectedStudent = Convert.ToInt16(id);

                    contextMenuStrip1.Show(dataGridView2, e.Location);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.deleteGrade(user, selectedStudent, dataGridView2);
        }
    }
}
