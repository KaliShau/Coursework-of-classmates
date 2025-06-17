using System;
using System.Windows.Forms;
using Software.src.modules.Participations;

namespace Software
{
    public partial class ParticipationsForm : Form
    {
        ParticipationsController _controller;
        public ParticipationsForm(HomeForm participation)
        {
            InitializeComponent();

            _controller = new ParticipationsController();
            _controller.init(dataGridView1, comboBox1, comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox1, textBox2, comboBox1, comboBox2, dataGridView1);
        }
    }
}
