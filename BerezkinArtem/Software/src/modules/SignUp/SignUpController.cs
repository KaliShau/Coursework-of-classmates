using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.SignUp
{
    public class SignUpController
    {
        public SignUpController() { }

        public void signUp(Form form, TextBox textBox1, TextBox textBox2)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username != "" && password != "")
            {
                DataTable dt = new DataTable();
                DB db = new DB();
                dt = db.register(username, password);

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
