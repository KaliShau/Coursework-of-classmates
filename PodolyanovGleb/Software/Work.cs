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
    public partial class Work : Form
    {
        public Work(DataTable dt)
        {
            InitializeComponent();

            int role_id = Convert.ToInt16(dt.Rows[0]["role_id"]);
            
            DB db = new DB();

            string my_role = Convert.ToString(db.getRolesById(role_id).Rows[0]["name"]);

            if (my_role == "Client")
            {
                button2.Visible = true;
                button1.Visible = false;
                button4.Visible = false;
            }

            if (my_role == "Operator")
            {
                button2.Visible = true;
                button1.Visible = true;
                button4.Visible = false;
            }

            if (my_role == "Admin")
            {
                button2.Visible = true;
                button1.Visible = true;
                button4.Visible = true;
            }

            panel2.Visible = false;
        }

        private void Work_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string address = textBox2.Text;
            string work = textBox3.Text;

            if (fio == "" || address == "" ||  work == "")
            {
                return;
            }

            DB db = new DB();
            db.createStatement(fio, address, work);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           panel1.Visible = true;
           panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;

            DB db = new DB();
            dataGridView1.DataSource = db.getStatements();
        }
    }
}
