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
    public partial class Events : Form
    {
        Participation participation;
        public Events(Participation participation)
        {
            InitializeComponent();
            this.participation = participation;

            DB db = new DB();
            dataGridView1.DataSource = db.getEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string event_name = textBox2.Text;
            DateTime event_date = dateTimePicker1.Value;

            if (event_name == "")
            {
                return;
            }

            DB db = new DB();
            db.createEvents(event_name, event_date);
            dataGridView1.DataSource = db.getEvents();
        }

        private void Events_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            participation.Show();
            this.Hide();
        }
    }
}
