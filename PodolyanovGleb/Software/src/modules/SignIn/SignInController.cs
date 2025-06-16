using System.Data;
using System.Windows.Forms;
using Software.src.modules.Work;

namespace Software.src.modules.SignIn
{
    public class SignInController
    {
        public SignInController() { }

        public void signIn(TextBox textBox1, TextBox textBox2, Form signIn, Form main)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (login == "" || password == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();

            dt = db.login(login, password);

            if (dt.Rows.Count == 1)
            {
                Form form = new WorkForm(dt);
                form.Show();
                signIn.Close();
                main.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
