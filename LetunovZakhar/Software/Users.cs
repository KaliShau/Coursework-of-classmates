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
    public partial class Users : Form
    {
        Participation Participation;
        public Users(Participation participation)
        {
            InitializeComponent();
            Participation = participation;

            DB db = new DB();
            dataGridView1.DataSource = db.getUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Participation.Show();
            this.Hide();
        }

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;

            if (username == "" ||  password == "" || comboBox1.Text == "")
            {
                return;
            }

            DB db = new DB();
            db.createUser(username, password, comboBox1.Text);
            dataGridView1.DataSource = db.getUsers();
        }
    }
}
