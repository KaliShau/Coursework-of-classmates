using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public class DB
    {

        string StrConnection = "Server=localhost; port=5432; User Id=postgres ;Password=root;database=db;";
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

            Cmd.CommandText = "INSERT INTO Users (first_name,login,password, phone_number, role_id) VALUES(:name,:login,:pass, :number, 3);";
            Cmd.Parameters.AddWithValue("name", Name);
            Cmd.Parameters.AddWithValue("login", Login);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.Parameters.AddWithValue("number", number);
            Cmd.ExecuteReader();


            dt = this.login(Login, pass);

            return dt;
        }

        public void createStatement(string fio, string address, string work)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Statements (FIO,address,type_work) VALUES(:fio,:address,:work);";
            Cmd.Parameters.AddWithValue("FIO", fio);
            Cmd.Parameters.AddWithValue("address", address);
            Cmd.Parameters.AddWithValue("work", work);

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
            Cmd.CommandText = "SELECT * FROM Statements;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}