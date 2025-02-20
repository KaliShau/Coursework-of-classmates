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
    public partial class Participations : Form
    {
        Participation Participation;
        public Participations(Participation participation)
        {
            InitializeComponent();
            Participation = participation;
            
            DB db = new DB();
            dataGridView1.DataSource = db.getParticipation();

            comboBox1.DataSource = db.getStudents();
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";

            comboBox2.DataSource = db.getEvents();
            comboBox2.DisplayMember = "event_name";
            comboBox2.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Participation.Show();
            this.Hide();
        }

        private void Participations_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string participation_type = textBox1.Text;

            int points;
            bool isNumber = int.TryParse(textBox2.Text, out points);

            if (!isNumber)
            {
                // Введенное значение не является числом
                MessageBox.Show("Пожалуйста, введите число.");
            }

            if (comboBox1.Text == "" || comboBox2.Text == "" || participation_type == "")
            {
                return;
            }

            DB db = new DB();
            db.createParticipation(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue),participation_type, points);
            dataGridView1.DataSource = db.getParticipation();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
