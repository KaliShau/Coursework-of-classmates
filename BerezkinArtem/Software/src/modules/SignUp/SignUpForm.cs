using System;
using System.Windows.Forms;
using Software.src.modules.SignUp;

namespace Software
{
    public partial class SignUpForm : Form
    {
        SignUpController _controller;
        public SignUpForm()
        {
            InitializeComponent();
            _controller = new SignUpController();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form signIn = new SignInForm();
            signIn.Show();
            this.Hide();
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.signUp(this, textBox1, textBox2);
        }

    }
}
