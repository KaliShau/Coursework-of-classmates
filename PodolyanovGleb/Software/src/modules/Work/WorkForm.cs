using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.Work
{
    public partial class WorkForm : Form
    {
        WorkController _controller;
        public WorkForm(DataTable dt)
        {
            InitializeComponent();
            _controller = new WorkController();

            _controller.init(dt, button1, button2, button4, button7, panel2, comboBox1, panel12, panel14, panel11);
        }

        private void Work_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _controller.createStatement(textBox1, textBox2, textBox3, comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.openCreateStatement(panel1, panel2, panel3, panel4, comboBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _controller.openStatements(panel1, panel2, panel3, panel4, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.openCreateUser(panel1, panel2, panel3, panel4);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            _controller.openUsers(panel1, panel2, panel3, panel4, dataGridView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _controller.searchStatements(textBox6, dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _controller.createOperator(textBox8, textBox4, textBox5, textBox7);
        }
    }
}
