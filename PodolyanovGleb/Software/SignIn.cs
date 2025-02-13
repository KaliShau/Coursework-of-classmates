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

        Main mainFrom;
        public SignIn(Main form)
        {
            InitializeComponent();
            mainFrom = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (login == "" || password == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();

            dt = db.login(login, password);

            if (dt.Rows.Count == 1)
            {
                Work form = new Work(dt);
                form.Show();
                this.Close();
                mainFrom.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
