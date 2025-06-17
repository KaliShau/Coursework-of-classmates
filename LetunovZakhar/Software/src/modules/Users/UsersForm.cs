using System;
using System.Windows.Forms;
using Software.src.modules.Users;

namespace Software
{
    public partial class UsersForm : Form
    {
        UsersContrroller _contrroller;
        public UsersForm(HomeForm participation)
        {
            InitializeComponent();

            _contrroller = new UsersContrroller();
            _contrroller.init(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _contrroller.create(dataGridView1, textBox1, textBox2, comboBox1);
        }
    }
}
