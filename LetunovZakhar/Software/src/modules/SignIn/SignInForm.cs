using System;
using System.Windows.Forms;
using Software.src.modules.SignIn;

namespace Software
{
    public partial class SignInForm : Form
    {
        HomeForm homeForm;
        SignInController _controller;
        public SignInForm(HomeForm home)
        {
            InitializeComponent();
            this.homeForm = home;
            _controller = new SignInController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.signIn(textBox1, textBox2, homeForm, this);
        }
    }
}
