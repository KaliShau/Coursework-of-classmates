using System.Data;
using System.Windows.Forms;
using Software.src.modules.Work;

namespace Software.src.modules.SignUp
{
    public class SignUpController
    {
        public SignUpController() { }

        public void signUp(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, Form signUp, Form main)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox3.Text;
            string number = textBox4.Text;

            if (login == "" || password == "" || name == "" || number == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();

            dt = db.register(login, password, name, number);

            if (dt.Rows.Count == 1)
            {
                Form form = new WorkForm(dt);
                form.Show();
                signUp.Close();
                main.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
