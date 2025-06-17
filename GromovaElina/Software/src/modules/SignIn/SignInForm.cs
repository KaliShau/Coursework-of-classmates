using System;
using System.Windows.Forms;
using Software.src.modules.SignIn;

namespace Software
{
    public partial class SignInForm : Form
    {
        SignInController _controller;
        public SignInForm()
        {
            InitializeComponent();
            _controller = new SignInController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.signIn(textBox1, textBox2, this);
        }
    }
}
