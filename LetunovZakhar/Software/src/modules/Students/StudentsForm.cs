using System;
using System.Windows.Forms;
using Software.src.modules.Students;

namespace Software
{
    public partial class StudentsForm : Form
    {
        StudentsController _controller;
        public StudentsForm(HomeForm from)
        {
            InitializeComponent();

            _controller = new StudentsController();
            _controller.init(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox1, textBox2, dataGridView1);
        }
    }
}
