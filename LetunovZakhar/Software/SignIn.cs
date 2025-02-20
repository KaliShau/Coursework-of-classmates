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
        Participation participation;
        public SignIn(Participation from)
        {
            InitializeComponent();
            this.participation = from;
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();
            dt = db.login(username, password);

            if (dt.Rows.Count == 1)
            {
                participation.user = dt;
                if (dt != null && dt.Rows.Count == 1)
                {
                    participation.button2.Visible = false;

                    string role = Convert.ToString(dt.Rows[0]["role"]);

                    if (role == "Operator")
                    {
                        participation.button3.Visible = true;
                        participation.button4.Visible = true;
                        participation.button5.Visible = true;
                        participation.button6.Visible = false;
                    }
                    if (role == "Admin")
                    {
                        participation.button3.Visible = true;
                        participation.button4.Visible = true;
                        participation.button5.Visible = true;
                        participation.button6.Visible = true;
                    }
                }

                participation.Show();
                this.Close();
            }
        }
    }
}
