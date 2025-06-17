using System;
using System.Windows.Forms;
using Software.src.modules.Users;

namespace Software
{
    public partial class UsersForm : Form
    {
        UsersController _controller;
        public UsersForm()
        {
            InitializeComponent();
            _controller = new UsersController();

            _controller.init(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox1, textBox2, comboBox1, dataGridView1);
        }
    }
}
