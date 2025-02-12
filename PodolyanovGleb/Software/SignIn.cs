using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public partial class SignIn : Form
    {
        private Main mainForm;
        public SignIn(Main from)
        {
            InitializeComponent();
            mainForm = from;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Show();
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
