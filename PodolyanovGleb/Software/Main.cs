using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace Software
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form signIn = new SignIn(this);
            signIn.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form signUp = new SignUp(this);
            signUp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Путь к файлу в корневой директории приложения
            string fileName = "save.docx"; // Имя файла в корневой директории
            string sourceFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, fileName);
            
            // Проверяем, существует ли файл
            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("Файл не найден!");
                return;
            }

            // Диалог для выбора места сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = fileName; // Устанавливаем имя файла по умолчанию

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationFilePath = saveFileDialog.FileName;

                try
                {
                    // Копируем файл в выбранное место
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

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = "save.docx"; // Имя файла в корневой директории
            string sourceFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, fileName);

            // Проверяем, существует ли файл
            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("Файл не найден!");
                return;
            }

            // Отправляем документ на печать
            PrintDocument(sourceFilePath);
        }

        private void PrintDocument(string filePath)
        {
            try
            {
                // Создаем экземпляр приложения Word
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document doc = null;

                try
                {
                    // Открываем документ
                    doc = wordApp.Documents.Open(filePath);

                    // Отправляем документ на печать
                    doc.PrintOut();

                    MessageBox.Show("Документ отправлен на печать!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при печати документа: {ex.Message}");
                }
                finally
                {
                    // Закрываем документ и приложение Word
                    if (doc != null)
                    {
                        doc.Close(SaveChanges: false);
                    }
                    wordApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске Word: {ex.Message}");
            }
        }
    }
}
