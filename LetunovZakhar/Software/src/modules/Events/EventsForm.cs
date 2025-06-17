using System;
using System.Windows.Forms;
using Software.src.modules.Events;

namespace Software
{
    public partial class EventsForm : Form
    {
        EventsController _controller;
        public EventsForm(HomeForm participation)
        {
            InitializeComponent();

            _controller = new EventsController();
            _controller.getEvents(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox2, dateTimePicker1, dataGridView1);
        }
    }
}
