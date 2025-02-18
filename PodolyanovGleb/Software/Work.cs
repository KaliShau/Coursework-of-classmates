using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
                button7.Visible = false;
            }

            if (my_role == "Operator")
            {
                button2.Visible = true;
                button1.Visible = true;
                button4.Visible = false;
                button7.Visible = false;

            }

            if (my_role == "Admin")
            {
                button2.Visible = true;
                button1.Visible = true;
                button4.Visible = true;
                button7.Visible = true;
            }

            panel2.Visible = false;
            DB dB = new DB();

            comboBox1.DataSource = dB.getTypesWork();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "ID";
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
            db.createStatement(fio, address, work, Convert.ToInt32(comboBox1.SelectedValue));

        }

        private void button2_Click(object sender, EventArgs e)
        {
           panel1.Visible = true;
           panel2.Visible = false;
           panel3.Visible = false;
           panel4.Visible = false;
            
            DB dB = new DB();

            comboBox1.DataSource = dB.getTypesWork();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "ID";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            DB db = new DB();
            dataGridView1.DataSource = db.getStatements();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox6.Text;

            DB dB = new DB();

            if (searchTerm != "")
            {
            dataGridView1.DataSource = dB.getStatementsBySearchTerm(searchTerm);

            } else
            {
                dataGridView1.DataSource = dB.getStatements();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string login = textBox8.Text;
            string password = textBox4.Text;
            string fio = textBox5.Text;
            string number = textBox7.Text;

            if (fio == "" || password== "" || login == "" || number == "")
            {
                return;
            }

            DB db = new DB();
            db.createOperator(login, password, fio, number);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;

            DB dB = new DB();

            dataGridView2.DataSource = dB.getUsers();
        }
    }
}
