using System;
using System.Windows.Forms;
using Software.src.modules.Main;

namespace Software
{
    public partial class MainForm : Form
    {
        MainController _controller;
        public MainForm()
        {
            InitializeComponent();
            _controller = new MainController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form signIn = new SignInForm(this);
            signIn.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form signUp = new SignUpForm(this);
            signUp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.save();
        }
    }
}
