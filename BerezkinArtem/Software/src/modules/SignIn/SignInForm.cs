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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form signup = new SignUpForm();
            signup.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.signIn(this, textBox1, textBox2);
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
