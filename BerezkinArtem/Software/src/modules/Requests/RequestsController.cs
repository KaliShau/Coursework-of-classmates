using System;
using System.Windows.Forms;

namespace Software.src.modules.Requests
{
    public class RequestsController
    {
        public RequestsController() { }

        public void init(DataGridView grid, ComboBox comboBox1, string role, Panel panel2)
        {
            DB db = new DB();

            grid.DataSource = db.getRequests();

            comboBox1.DataSource = db.getMaterials();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";

            if (role == "Admin" || role == "Operator")
            {
                grid.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                grid.Visible = false;
                panel2.Visible = true;
            }
        }

        public void create(TextBox textBox2, ComboBox comboBox1, DataGridView grid)
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
            grid.DataSource = db.getRequests();
        }

        public void updateRequestsForProcessing(string _selectedRequestId, DataGridView grid)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DB db = new DB();
                    db.updateRequestsForProcessing(Convert.ToInt16(_selectedRequestId));
                    grid.DataSource = db.getRequests();
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

        public void updateRequestsForPerformed(string _selectedRequestId, DataGridView grid)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DB db = new DB();
                    db.updateRequestsForPerformed(Convert.ToInt16(_selectedRequestId));
                    grid.DataSource = db.getRequests();

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
