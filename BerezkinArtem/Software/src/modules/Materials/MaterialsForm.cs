using System;
using System.Windows.Forms;
using Software.src.modules.Materials;

namespace Software
{
    public partial class MaterialsForm : Form
    {
        MaterialsController _controller;
        public MaterialsForm()
        {
            InitializeComponent();
            _controller = new MaterialsController();

            _controller.init(dataGridView1, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox1, textBox2, textBox3, comboBox1, dataGridView1);
        }
    }
}
