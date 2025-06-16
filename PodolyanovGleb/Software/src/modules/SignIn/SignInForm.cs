using System;
using System.Windows.Forms;
using Software.src.modules.SignIn;

namespace Software
{
    public partial class SignInForm : Form
    {
        MainForm mainFrom;
        SignInController _controller;
        public SignInForm(MainForm form)
        {
            InitializeComponent();
            mainFrom = form;
            _controller = new SignInController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.signIn(textBox1, textBox2, this, mainFrom);
        }
    }
}
