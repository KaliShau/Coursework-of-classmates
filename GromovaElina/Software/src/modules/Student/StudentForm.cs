using System.Data;
using System.Windows.Forms;
using Software.src.modules.Student;

namespace Software
{
    public partial class StudentForm : Form
    {
        StudentController _controller;
        public StudentForm(DataTable user)
        {
            InitializeComponent();

            _controller = new StudentController();
            _controller.init(dataGridView1, user, label2, label3, label4, label5);
        }

        private void Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
