using System.Windows.Forms;

namespace Software.src.modules.Home
{
    public class HomeController
    {
        public HomeController() { }

        public void getParticipation(DataGridView grid)
        {
            DB db = new DB();
            grid.DataSource = db.getParticipation();
        }

        public void search(TextBox textBox1, DataGridView grid)
        {
            string searchTerm = textBox1.Text;

            if (searchTerm == "")
            {
                return;
            }

            DB db = new DB();
            grid.DataSource = db.getParticipationSearch(searchTerm);
        }
    }
}
