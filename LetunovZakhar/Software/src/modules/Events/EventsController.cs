using System;
using System.Windows.Forms;

namespace Software.src.modules.Events
{
    public class EventsController
    {
        public EventsController() { }

        public void getEvents(DataGridView grid)
        {
            DB db = new DB();
            grid.DataSource = db.getEvents();
        }

        public void create(TextBox textBox2, DateTimePicker dateTimePicker1, DataGridView grid)
        {
            string event_name = textBox2.Text;
            DateTime event_date = dateTimePicker1.Value;

            if (event_name == "")
            {
                return;
            }

            DB db = new DB();
            db.createEvents(event_name, event_date);
            grid.DataSource = db.getEvents();
        }
    }
}
