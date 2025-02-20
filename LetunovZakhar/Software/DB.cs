using Microsoft.Extensions.Logging;
using Npgsql; // Подключаем библиотеку
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Software
{
    internal class DB
    {
        string StrConnection = "Server=localhost; port=5432; User Id=postgres ;Password=root;database=lat_db;"; // Строка подключения
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

        public void createStudent(string fio, string group)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Students (full_name, group_name) VALUES (:fio, :group);";
            Cmd.Parameters.AddWithValue("fio", fio);
            Cmd.Parameters.AddWithValue("group", group);

            Cmd.ExecuteReader();
            MessageBox.Show("Студент добавлен!");
        }

        public DataTable getStudents()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Students";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createEvents(string event_name, DateTime event_data)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO  Events (event_name, event_date) VALUES (:event_name, :event_data);";
            Cmd.Parameters.AddWithValue("event_name", event_name);
            Cmd.Parameters.AddWithValue("event_data", event_data);

            Cmd.ExecuteReader();
            MessageBox.Show("Событие добавлено!");
        }

        public DataTable getEvents()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Events";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createParticipation(int student_id, int event_id, string participation_type, int point)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO  Participation (student_id, event_id, participation_type, points) VALUES (:student_id, :event_id, :participation_type, :point);";
            Cmd.Parameters.AddWithValue("student_id", student_id);
            Cmd.Parameters.AddWithValue("event_id", event_id);
            Cmd.Parameters.AddWithValue("participation_type", participation_type);
            Cmd.Parameters.AddWithValue("point", point);

            Cmd.ExecuteReader();
            MessageBox.Show("Активность добавлено!");
        }

        public DataTable getParticipation()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT s.full_name, s.group_name, e.event_name, e.event_date, p.participation_type, p.points FROM Participation p JOIN Students s ON s.id = p.student_id JOIN Events e ON e.id = p.event_id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getParticipationSearch(string searchTerm)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;

            string query = @"
                SELECT 
                    s.full_name, 
                    s.group_name, 
                    e.event_name, 
                    e.event_date, 
                    p.participation_type, 
                    p.points 
                FROM 
                    Participation p 
                JOIN 
                    Students s ON s.id = p.student_id 
                JOIN 
                    Events e ON e.id = p.event_id 
                WHERE 
                    s.full_name LIKE :searchTerm 
                    OR e.event_name LIKE :searchTerm;
            ";

            Cmd.CommandText = query;
            Cmd.Parameters.AddWithValue("searchTerm", $"%{searchTerm}%");


            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createUser(string username, string password, string role)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO  Users (username, password, role) VALUES (:username, :password, :role);";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("password", password);
            Cmd.Parameters.AddWithValue("role", role);

            Cmd.ExecuteReader();
            MessageBox.Show("Пользователь добавлено!");
        }

        public DataTable getUsers()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Users";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}
