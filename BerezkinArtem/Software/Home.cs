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
    public partial class Home : Form
    {
        DataTable user;
        string role;
        public Home(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;

            this.role = Convert.ToString(this.user.Rows[0]["role"]);

            if (this.role == "Client")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;
            }
            if (this.role == "Operator")
            {
                button2.Visible = true;
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
            }
            if (this.role == "Admin") 
            {
                button2.Visible = true;
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form child = new Suppliers();
            child.Dock = DockStyle.Fill;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Clear();
            panel3.Controls.Add(child);
            child.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form child = new Materials();
            child.Dock = DockStyle.Fill;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Clear();
            panel3.Controls.Add(child);
            child.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form child = new Requests(this.role);
            child.Dock = DockStyle.Fill;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Clear();
            panel3.Controls.Add(child);
            child.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form child = new Users();
            child.Dock = DockStyle.Fill;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Clear();
            panel3.Controls.Add(child);
            child.Show();
        }
    }
}
