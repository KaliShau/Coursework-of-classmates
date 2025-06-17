using System.Windows.Forms;

namespace Software.src.modules.Home
{
    public class HomeController
    {
        public HomeController() { }

        public void init(string role, Button button1, Button button2, Button button3, Button button4)
        {
            if (role == "Client")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;
            }
            if (role == "Operator")
            {
                button2.Visible = true;
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
            }
            if (role == "Admin")
            {
                button2.Visible = true;
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        public void changeForm(Form child, Panel panel)
        {
            child.Dock = DockStyle.Fill;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Clear();
            panel.Controls.Add(child);
            child.Show();
        }
    }
}
