using System;
using System.Windows.Forms;
using Software.src.modules.Requests;

namespace Software
{
    public partial class RequestsForm : Form
    {
        private string _selectedRequestId;
        RequestsController _controller;
        public RequestsForm(string role)
        {
            InitializeComponent();
            _controller = new RequestsController();

            _controller.init(dataGridView1, comboBox1, role, panel2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox2, comboBox1, dataGridView1);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _controller.updateRequestsForProcessing(_selectedRequestId, dataGridView1);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    this._selectedRequestId = dataGridView1.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();

                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _controller.updateRequestsForPerformed(_selectedRequestId, dataGridView1);
        }
    }
}
