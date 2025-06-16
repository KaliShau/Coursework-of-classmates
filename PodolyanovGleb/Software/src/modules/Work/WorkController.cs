using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.Work
{
    public class WorkController
    {
        public WorkController() { }

        public void init(DataTable user, Button button1, Button button2, Button button4, Button button7, Panel panel2, ComboBox comboBox1,
            Panel panel12, Panel panel14, Panel panel11)
        {
            int role_id = Convert.ToInt16(user.Rows[0]["role_id"]);

            DB db = new DB();

            string my_role = Convert.ToString(db.getRolesById(role_id).Rows[0]["name"]);

            if (my_role == "Client")
            {
                button2.Visible = true;
                button1.Visible = false;
                button4.Visible = false;
                button7.Visible = false;

                panel11.Visible = false;
                panel12.Visible = false;
                panel14.Visible = false;
            }

            if (my_role == "Operator")
            {
                button2.Visible = true;
                button1.Visible = false;
                button4.Visible = true;
                button7.Visible = false;

                panel11.Visible = true;
                panel12.Visible = false;
                panel14.Visible = false;
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

        public void createStatement(TextBox textBox1, TextBox textBox2, TextBox textBox3, ComboBox comboBox1)
        {
            string fio = textBox1.Text;
            string address = textBox2.Text;
            string work = textBox3.Text;

            if (fio == "" || address == "" || work == "")
            {
                return;
            }

            DB db = new DB();
            db.createStatement(fio, address, work, Convert.ToInt32(comboBox1.SelectedValue));
        }

        public void openCreateStatement(Panel panel1, Panel panel2, Panel panel3, Panel panel4, ComboBox comboBox1)
        {
            visibleNav(panel1, panel2, panel3, panel4, panel1);

            DB dB = new DB();

            comboBox1.DataSource = dB.getTypesWork();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "ID";
        }

        public void openStatements(Panel panel1, Panel panel2, Panel panel3, Panel panel4, DataGridView grid)
        {
            visibleNav(panel1, panel2, panel3, panel4, panel2);

            DB dB = new DB();
            DB db = new DB();
            grid.DataSource = db.getStatements();
        }

        public void openUsers(Panel panel1, Panel panel2, Panel panel3, Panel panel4, DataGridView grid)
        {
            visibleNav(panel1, panel2, panel3, panel4, panel4);

            DB dB = new DB();
            DB db = new DB();
            grid.DataSource = db.getUsers();
        }

        public void openCreateUser(Panel panel1, Panel panel2, Panel panel3, Panel panel4)
        {
            visibleNav(panel1, panel2, panel3, panel4, panel3);
        }

        public void searchStatements(TextBox textBox6, DataGridView grid)
        {
            string searchTerm = textBox6.Text;
            DB dB = new DB();

            if (searchTerm != "")
            {
                grid.DataSource = dB.getStatementsBySearchTerm(searchTerm);

            }
            else
            {
                grid.DataSource = dB.getStatements();
            }
        }

        public void createOperator(TextBox textBox8, TextBox textBox4, TextBox textBox5, TextBox textBox7)
        {
            string login = textBox8.Text;
            string password = textBox4.Text;
            string fio = textBox5.Text;
            string number = textBox7.Text;

            if (fio == "" || password == "" || login == "" || number == "")
            {
                return;
            }

            DB db = new DB();
            db.createOperator(login, password, fio, number);
        }

        //-- utils --\\

        private void visibleNav(Panel panel1, Panel panel2, Panel panel3, Panel panel4, Panel active)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            active.Visible = true;
        }
    }
}
