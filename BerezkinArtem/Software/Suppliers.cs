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
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
            DB db = new DB();
            dataGridView1.DataSource = db.getSuppliers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string contact_person = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;

            if (name == "" || contact_person == "" || phone == "" || email == "")
            {
                return;
            }
            DB db = new DB();
            db.createSuppliers(name, contact_person, phone, email);
            dataGridView1.DataSource = db.getSuppliers();
        }
    }
}
