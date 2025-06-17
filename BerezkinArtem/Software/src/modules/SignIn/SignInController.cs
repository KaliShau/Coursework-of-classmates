using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.SignIn
{
    public class SignInController
    {
        public SignInController() { }

        public void signIn(Form form, TextBox textBox1, TextBox textBox2)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username != "" && password != "")
            {
                DataTable dt = new DataTable();
                DB db = new DB();
                dt = db.login(username, password);

                if (dt.Rows.Count == 1)
                {
                    Form home = new HomeForm(dt);
                    home.Show();
                    form.Hide();
                }
            }
        }
    }
}
