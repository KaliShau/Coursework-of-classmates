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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form signIn = new SignIn();
            signIn.Show();
            this.Hide();
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username != "" && password != "")
            {
                DataTable dt = new DataTable();
                DB db = new DB();
                dt = db.register(username, password);

                if (dt.Rows.Count == 1)
                {
                    Form home = new Home(dt);
                    home.Show();
                    this.Hide();
                } 
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
