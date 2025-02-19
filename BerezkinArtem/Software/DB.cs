using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Software
{
    internal class DB
    {

        string StrConnection = "Server=localhost; port=5432; User Id=postgres ;Password=root;database=db;"; // Строка подключения
        NpgsqlConnection Con;
        NpgsqlCommand Cmd;


        public void connection()
        {
            Con = new NpgsqlConnection();
            Con.ConnectionString = StrConnection;

            if (Con.State == System.Data.ConnectionState.Closed)
            {
                Con.Open();
            }
        }

        public DataTable login(string username, string pass)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Users WHERE username = :username AND password = :pass";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable register(string username, string pass)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            dt = this.login(username, pass);

            if (dt.Rows.Count > 0)
            {
                DataTable error = new DataTable();
                return error;
            }

            Cmd.CommandText = "INSERT INTO Users (username,password,role) VALUES(:username,:pass, 'Client');";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.ExecuteReader();

            dt = this.login(username, pass);

            return dt;
        }

        public void createUser(string username, string pass, string role)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandText = "INSERT INTO Users (username,password,role) VALUES(:username,:pass, :role);";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.Parameters.AddWithValue("role", role);
            Cmd.ExecuteReader();
            MessageBox.Show("Пользователь добавлен");

        }

        public DataTable getUsers()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Users;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createSuppliers(string name, string contact_person, string phone, string email)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Suppliers (name, contact_person, phone, email) VALUES (:name, :contact_person, :phone, :email);";
            Cmd.Parameters.AddWithValue("name", name);
            Cmd.Parameters.AddWithValue("contact_person", contact_person);
            Cmd.Parameters.AddWithValue("phone", phone);
            Cmd.Parameters.AddWithValue("email", email);

            Cmd.ExecuteReader();
            MessageBox.Show("Добавлен поставщик!");
        }

        public void createRequest(int quantity, int material_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Requests (quantity, material_id, status) VALUES (:quantity, :material_id, 'Новая');";
            Cmd.Parameters.AddWithValue("quantity", quantity);
            Cmd.Parameters.AddWithValue("material_id", material_id);

            Cmd.ExecuteReader();
            MessageBox.Show("Добавлена заявка!");
        }

        public DataTable getRequests()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT r.*, m.name as material_name FROM Requests r JOIN Materials m ON r.material_id = m.id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void updateRequestsForProcessing(int id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "UPDATE Requests SET status = 'В обработке' WHERE id = :id;";
            Cmd.Parameters.AddWithValue("id", id);

            Cmd.ExecuteReader();
            MessageBox.Show("Заявка обновлена!");
        }

        public void updateRequestsForPerformed(int id)
        {
            try
            {
                // Устанавливаем соединение с базой данных
                connection();

                // Шаг 1: Обновляем статус заявки на "Выполнена"
                using (Cmd = new NpgsqlCommand())
                {
                    Cmd.Connection = Con;
                    Cmd.CommandText = "UPDATE Requests SET status = 'Выполнена' WHERE id = @id;";
                    Cmd.Parameters.AddWithValue("@id", id);
                    int rowsUpdated = Cmd.ExecuteNonQuery();

                    if (rowsUpdated == 0)
                    {
                        MessageBox.Show("Заявка с указанным ID не найдена!");
                        return;
                    }
                }

                // Шаг 2: Получаем данные заявки
                int materialId = 0;
                int requestQuantity = 0;

                using (Cmd = new NpgsqlCommand())
                {
                    Cmd.Connection = Con;
                    Cmd.CommandText = "SELECT material_id, quantity FROM Requests WHERE id = @id;";
                    Cmd.Parameters.AddWithValue("@id", id);

                    using (NpgsqlDataReader dr = Cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            materialId = dr.GetInt32(dr.GetOrdinal("material_id"));
                            requestQuantity = dr.GetInt32(dr.GetOrdinal("quantity"));
                        }
                        else
                        {
                            MessageBox.Show("Данные заявки не найдены!");
                            return;
                        }
                    }
                }

                // Шаг 3: Обновляем количество материала
                using (Cmd = new NpgsqlCommand())
                {
                    Cmd.Connection = Con;
                    Cmd.CommandText = "UPDATE Materials SET quantity = quantity + @requestQuantity WHERE id = @materialId;";
                    Cmd.Parameters.AddWithValue("@requestQuantity", requestQuantity);
                    Cmd.Parameters.AddWithValue("@materialId", materialId);
                    int rowsUpdated = Cmd.ExecuteNonQuery();

                    if (rowsUpdated == 0)
                    {
                        MessageBox.Show("Материал с указанным ID не найден!");
                        return;
                    }
                }

                MessageBox.Show("Заявка обновлена, и количество материала увеличено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                // Закрываем соединение с базой данных
                if (Con != null && Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public void createMaterials(string name, int quantity, string unit, int supplier_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Materials (name, quantity, unit, supplier_id) VALUES (:name, :quantity, :unit, :supplier_id);";
            Cmd.Parameters.AddWithValue("name", name);
            Cmd.Parameters.AddWithValue("quantity", quantity);
            Cmd.Parameters.AddWithValue("unit", unit);
            Cmd.Parameters.AddWithValue("supplier_id", supplier_id);

            Cmd.ExecuteReader();
            MessageBox.Show("Добавлен материал!");
        }

        public DataTable getMaterials()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT m.*, s.name as supplier_name FROM Materials m JOIN Suppliers s ON m.supplier_id = s.id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getSuppliers()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Suppliers;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}
