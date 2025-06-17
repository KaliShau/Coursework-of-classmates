using System;
using System.Windows.Forms;

namespace Software.src.modules.Materials
{
    public class MaterialsController
    {
        public MaterialsController() { }

        public void init(DataGridView grid, ComboBox comboBox1)
        {
            DB db = new DB();
            grid.DataSource = db.getMaterials();

            comboBox1.DataSource = db.getSuppliers();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        public void create(TextBox textBox1, TextBox textBox2, TextBox textBox3, ComboBox comboBox1, DataGridView grid)
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
            grid.DataSource = db.getMaterials();
        }
    }
}
