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
        public Users()
        {
            InitializeComponent();

            DB db = new DB();
            dataGridView1.DataSource = db.getUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username != "" && password != "")
            {
                DataTable dt = new DataTable();
                DB db = new DB();
                db.createUser(username, password, Convert.ToString(comboBox1.Text));
                dataGridView1.DataSource = db.getUsers();

            }
        }
    }
}
