using System;
using System.Data;
using System.Windows.Forms;

namespace Software.src.modules.SignIn
{
    public class SignInController
    {
        public SignInController() { }

        public void signIn(TextBox textBox1, TextBox textBox2, HomeForm homeForm, Form active)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                return;
            }

            DB db = new DB();
            DataTable dt = new DataTable();
            dt = db.login(username, password);

            if (dt.Rows.Count == 1)
            {
                homeForm.user = dt;
                if (dt != null && dt.Rows.Count == 1)
                {
                    homeForm.button2.Visible = false;

                    string role = Convert.ToString(dt.Rows[0]["role"]);

                    if (role == "Operator")
                    {
                        homeForm.button3.Visible = true;
                        homeForm.button4.Visible = true;
                        homeForm.button5.Visible = true;
                        homeForm.button6.Visible = false;
                    }
                    if (role == "Admin")
                    {
                        homeForm.button3.Visible = true;
                        homeForm.button4.Visible = true;
                        homeForm.button5.Visible = true;
                        homeForm.button6.Visible = true;
                    }
                }

                homeForm.Show();
                active.Close();
            }
        }
    }
}
