using System.Windows.Forms;

namespace Software.src.modules.Users
{
    public class UsersContrroller
    {
        public UsersContrroller() { }

        public void init(DataGridView grid)
        {
            DB db = new DB();
            grid.DataSource = db.getUsers();
        }

        public void create(DataGridView grid, TextBox textBox1, TextBox textBox2, ComboBox comboBox1)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;

            if (username == "" || password == "" || comboBox1.Text == "")
            {
                return;
            }

            DB db = new DB();
            db.createUser(username, password, comboBox1.Text);
            grid.DataSource = db.getUsers();
        }
    }
}
