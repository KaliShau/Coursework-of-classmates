using System;
using System.Windows.Forms;
using Software.src.modules.Suppliers;

namespace Software
{
    public partial class SuppliersForm : Form
    {
        SuppliersController _controller;
        public SuppliersForm()
        {
            InitializeComponent();
            _controller = new SuppliersController();

            _controller.init(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox1, textBox2, textBox3, textBox4, dataGridView1);
        }
    }
}
