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
        Main mainForm;
        public SignUp(Main from)
        {
            InitializeComponent();
            mainForm = from;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = this.textBox1.Text;
            string password = this.textBox2.Text;
            string name = this.textBox3.Text;
            string number = this.textBox4.Text;

            if (login == "" || password == "" || name == "" || number == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();

            dt = db.register(login, password, name, number);

            if (dt.Rows.Count == 1)
            {
                Work form = new Work(dt);
                form.Show();
                this.Close();
                mainForm.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
