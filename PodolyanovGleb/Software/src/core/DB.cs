﻿using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Software
{
    public class DB
    {
        string StrConnection = "Server=localhost; port=5432; User Id=postgres ;Password=root;database=mcu;";
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

        public DataTable login(string Login, string Pass)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Users WHERE login = :login AND password = :pass";
            Cmd.Parameters.AddWithValue("login", Login);
            Cmd.Parameters.AddWithValue("pass", Pass);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable register(string Login, string pass, string Name, string number)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            dt = this.login(Login, pass);

            if (dt.Rows.Count > 0)
            {
                DataTable error = new DataTable();
                return error;
            }

            Cmd.CommandText = "INSERT INTO Users (fio,login,password, phone_number, role_id) VALUES(:name,:login,:pass, :number, 3);";
            Cmd.Parameters.AddWithValue("name", Name);
            Cmd.Parameters.AddWithValue("login", Login);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.Parameters.AddWithValue("number", number);
            Cmd.ExecuteReader();

            dt = this.login(Login, pass);
            return dt;
        }

        public void createOperator(string Login, string pass, string Name, string number)
        {
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandText = "INSERT INTO Users (fio,login,password, phone_number, role_id) VALUES(:name,:login,:pass, :number, 2);";
            Cmd.Parameters.AddWithValue("name", Name);
            Cmd.Parameters.AddWithValue("login", Login);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.Parameters.AddWithValue("number", number);
            Cmd.ExecuteReader();

            MessageBox.Show("Успешно добавлено");
        }

        public void createStatement(string fio, string address, string work, int id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Statements (FIO,address,type_work, types_work_id) VALUES(:fio,:address,:work, :id);";
            Cmd.Parameters.AddWithValue("FIO", fio);
            Cmd.Parameters.AddWithValue("address", address);
            Cmd.Parameters.AddWithValue("work", work);
            Cmd.Parameters.AddWithValue("id", id);

            Cmd.ExecuteReader();

            MessageBox.Show("Успешно добавлено");
        }

        public DataTable getRoles()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Roles";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getUsers()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT u.id, u.created_at, u.login, u.password, u.fio, u.phone_number, r.name AS role_name FROM Users u JOIN Roles r ON u.role_id = r.id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getTypesWork()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM TypesWork;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getRolesById(int id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Roles WHERE id = :id;";
            Cmd.Parameters.AddWithValue("id", id);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getStatements()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT s.*, t.name AS work_name, t.description AS work_description FROM Statements s JOIN TypesWork t ON s.types_work_id = t.ID;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getStatementsBySearchTerm(string searchTerm)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = @"
                SELECT s.*, t.name AS work_name, t.description AS work_description FROM Statements s JOIN TypesWork t ON s.types_work_id = t.ID
                WHERE LOWER(s.id::text) LIKE LOWER(@searchTerm) OR LOWER(s.fio) LIKE LOWER(@searchTerm) OR LOWER(t.name) LIKE LOWER(@searchTerm);
            ";

            Cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}