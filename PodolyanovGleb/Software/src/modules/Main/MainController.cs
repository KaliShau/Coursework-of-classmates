using System;
using System.IO;
using System.Windows.Forms;

namespace Software.src.modules.Main
{
    public class MainController
    {
        public MainController() { }

        public void save()
        {
            string fileName = "Statement.docx";
            string sourceFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, fileName);

            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("Файл не найден!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = fileName;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationFilePath = saveFileDialog.FileName;

                try
                {
                    File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                    MessageBox.Show("Файл успешно сохранен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show($"Ошибка при сохранении файл");
            }
        }
    }
}
