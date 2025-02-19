using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Software
{
    public partial class Requests : Form
    {
        private string _selectedRequestId;
        public Requests(string role)
        {
            InitializeComponent();

            DB db = new DB();

            dataGridView1.DataSource = db.getRequests();

            comboBox1.DataSource = db.getMaterials();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";

            if (role == "Admin" || role == "Operator")
            {
                dataGridView1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int quantity;
            bool isNumber = int.TryParse(textBox2.Text, out quantity);

            if (!isNumber)
            {
                MessageBox.Show("Ошибка: введите число!");
            }

            if (quantity == 0 || textBox2.Text == "" || comboBox1.Text == "")
            {
                return;
            }

            DB db = new DB();
            db.createRequest(quantity, Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView1.DataSource = db.getRequests();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DB db = new DB();
                    db.updateRequestsForProcessing(Convert.ToInt16(_selectedRequestId));
                    dataGridView1.DataSource = db.getRequests();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при принятии запроса: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Не выбран request_id.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Определяем, по какой строке и столбцу был клик
                var hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    // Выделяем строку
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    // Получаем значение столбца "request_id"
                    this._selectedRequestId = dataGridView1.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();

                    // Показываем контекстное меню
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DB db = new DB();
                    db.updateRequestsForPerformed(Convert.ToInt16(_selectedRequestId));
                    dataGridView1.DataSource = db.getRequests();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при принятии запроса: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Не выбран request_id.");
            }
        }
    }
}
