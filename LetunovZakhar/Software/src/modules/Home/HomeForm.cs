using System;
using System.Data;
using System.Windows.Forms;
using Software.src.modules.Home;

namespace Software
{
    public partial class HomeForm : Form
    {
        public DataTable user;
        HomeController _controller;
        public HomeForm()
        {
            InitializeComponent();

            _controller = new HomeController();
            _controller.getParticipation(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new SignInForm(this);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentsForm form = new StudentsForm(this);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EventsForm form = new EventsForm(this);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ParticipationsForm form = new ParticipationsForm(this);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UsersForm form = new UsersForm(this);
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _controller.getParticipation(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.search(textBox1, dataGridView1);
        }
    }
}
