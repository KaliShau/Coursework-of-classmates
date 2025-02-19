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
    public partial class Materials : Form
    {
        public Materials()
        {
            InitializeComponent();

            DB db = new DB();
            dataGridView1.DataSource = db.getMaterials();

            comboBox1.DataSource = db.getSuppliers();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int quantity;
            string unit = textBox3.Text;
            bool isNumber = int.TryParse(textBox2.Text, out quantity);

            if (!isNumber)
            {
                MessageBox.Show("Ошибка: введите число!");
            }

            if (quantity == 0 || textBox2.Text == "" || name == "" || unit == "" || comboBox1.Text == "")
            {
                return;
            }

            DB db = new DB();
            db.createMaterials(name, quantity, unit, Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView1.DataSource = db.getMaterials();
        }
    }
}
