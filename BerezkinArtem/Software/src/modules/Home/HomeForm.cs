using System;
using System.Data;
using System.Windows.Forms;
using Software.src.modules.Home;

namespace Software
{
    public partial class HomeForm : Form
    {
        DataTable user;
        string role;
        HomeController _controller;
        public HomeForm(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;
            this.role = Convert.ToString(this.user.Rows[0]["role"]);

            _controller = new HomeController();
            _controller.init(role, button1, button2, button3, button4);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.changeForm(new SuppliersForm(), panel3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.changeForm(new MaterialsForm(), panel3);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _controller.changeForm(new RequestsForm(this.role), panel3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _controller.changeForm(new UsersForm(), panel3);

        }
    }
}
