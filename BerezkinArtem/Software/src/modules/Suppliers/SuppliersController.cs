using System.Windows.Forms;

namespace Software.src.modules.Suppliers
{
    public class SuppliersController
    {
        public SuppliersController() { }

        public void init(DataGridView grid)
        {
            DB db = new DB();
            grid.DataSource = db.getSuppliers();
        }

        public void create(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, DataGridView grid)
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
            grid.DataSource = db.getSuppliers();
        }
    }
}
