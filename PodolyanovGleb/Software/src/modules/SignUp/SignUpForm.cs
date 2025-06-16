using System;
using System.Windows.Forms;
using Software.src.modules.SignUp;

namespace Software
{
    public partial class SignUpForm : Form
    {
        MainForm mainForm;
        SignUpController _controller;
        public SignUpForm(MainForm from)
        {
            InitializeComponent();
            mainForm = from;
            _controller = new SignUpController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.signUp(textBox1, textBox2, textBox3, textBox4, this, mainForm);
        }
    }
}
