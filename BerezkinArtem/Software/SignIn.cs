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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form signup = new SignUp();
            signup.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username != "" && password != "")
            {
                DataTable dt = new DataTable();
                DB db = new DB();
                dt = db.login(username, password);

                if (dt.Rows.Count == 1)
                {
                    Form home = new Home(dt);
                    home.Show();
                    this.Hide();
                }
            }
        }
    }
}
