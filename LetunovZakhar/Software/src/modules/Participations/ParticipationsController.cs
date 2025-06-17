using System;
using System.Windows.Forms;

namespace Software.src.modules.Participations
{
    public class ParticipationsController
    {
        public ParticipationsController() { }

        public void init(DataGridView grid, ComboBox comboBox1, ComboBox comboBox2)
        {
            DB db = new DB();
            grid.DataSource = db.getParticipation();

            comboBox1.DataSource = db.getStudents();
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";

            comboBox2.DataSource = db.getEvents();
            comboBox2.DisplayMember = "event_name";
            comboBox2.ValueMember = "id";
        }

        public void create(TextBox textBox1, TextBox textBox2, ComboBox comboBox1, ComboBox comboBox2, DataGridView grid)
        {
            string participation_type = textBox1.Text;

            int points;
            bool isNumber = int.TryParse(textBox2.Text, out points);

            if (!isNumber)
            {
                MessageBox.Show("Пожалуйста, введите число.");
            }

            if (comboBox1.Text == "" || comboBox2.Text == "" || participation_type == "")
            {
                return;
            }

            DB db = new DB();
            db.createParticipation(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), participation_type, points);
            grid.DataSource = db.getParticipation();
        }
    }
}
