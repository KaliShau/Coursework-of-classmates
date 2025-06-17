using System.Windows.Forms;

namespace Software.src.modules.Students
{
    public class StudentsController
    {
        public StudentsController() { }

        public void init(DataGridView grid)
        {
            DB db = new DB();
            grid.DataSource = db.getStudents();
        }

        public void create(TextBox textBox1, TextBox textBox2, DataGridView grid)
        {
            string group = textBox1.Text;
            string fio = textBox2.Text;

            if (group == "" || fio == "")
            {
                return;
            }

            DB db = new DB();
            db.createStudent(fio, group);
            grid.DataSource = db.getStudents();
        }
    }
}
