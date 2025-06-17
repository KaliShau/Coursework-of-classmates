using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.Users
{
    public class UsersController
    {
        public UsersController() { }

        public void init(DataGridView grid)
        {
            DB db = new DB();
            grid.DataSource = db.getUsers();
        }

        public void create(TextBox textBox1, TextBox textBox2, ComboBox comboBox1, DataGridView grid)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username != "" && password != "")
            {
                DataTable dt = new DataTable();
                DB db = new DB();
                db.createUser(username, password, Convert.ToString(comboBox1.Text));
                grid.DataSource = db.getUsers();
            }
        }
    }
}
