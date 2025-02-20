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
    public partial class Students : Form
    {
        Participation Participation;
        public Students(Participation from)
        {
            InitializeComponent();
            Participation = from;

            DB db = new DB();
            dataGridView1.DataSource = db.getStudents();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string group = textBox1.Text;
            string fio = textBox2.Text;

            if (group == "" || fio == "")
            {
                return;
            }

            DB db = new DB();
            db.createStudent(fio, group);
            dataGridView1.DataSource = db.getStudents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Participation.Show();
            this.Hide();
        }

        private void Students_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
