using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public partial class Participation : Form
    {
        public DataTable user;
        public Participation()
        {
            InitializeComponent();

            DB db = new DB();
            dataGridView1.DataSource = db.getParticipation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new SignIn(this);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Students form = new Students(this);
            form.Show();
            this.Hide();    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Events form = new Events(this);
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Participations form = new Participations(this);
            form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            dataGridView1.DataSource = db.getParticipation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;
            
            if (searchTerm == "")
            {
                return;
            }

            DB db = new DB();
            dataGridView1.DataSource = db.getParticipationSearch(searchTerm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Users form = new Users(this);
            form.Show();
            this.Hide();
        }
    }
}
