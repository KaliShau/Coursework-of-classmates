using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Software
{
    internal class DB
    {
        string StrConnection = "Server=localhost; port=5432; User Id=postgres ;Password=root;database=students;"; // Строка подключения
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
            Cmd.CommandText = "SELECT * FROM users WHERE username = :username AND password = :pass";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);

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
            Cmd.CommandText = "SELECT * FROM users WHERE role = 'Admin' OR role = 'Teacher'";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getTeachers()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM users WHERE  role = 'Teacher'";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createUser(string username, string pass, string fio, string role)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO users (username, password, role, full_name) VALUES (:username,:pass,:role,:fio);";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.Parameters.AddWithValue("role", role);
            Cmd.Parameters.AddWithValue("fio", fio);

            Cmd.ExecuteReader();
            MessageBox.Show("Пользователь добавлен!");
        }
        public void deleteUser(int id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "DELETE FROM users WHERE id = :id;";
            Cmd.Parameters.AddWithValue("id", id);

            Cmd.ExecuteReader();
            MessageBox.Show("Пользователь удален!");
        }

        public DataTable getGroups()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT g.*, t.full_name FROM groups g JOIN users t ON t.id = g.teacher_id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createGroup(string name,int teacher_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO groups (name, teacher_id) VALUES (:name,:teacher_id);";
            Cmd.Parameters.AddWithValue("name", name);
            Cmd.Parameters.AddWithValue("teacher_id", teacher_id);

            Cmd.ExecuteReader();
            MessageBox.Show("Группа добавлена!");
        }
        public void deleteGroup(int id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "DELETE FROM groups WHERE id = :id;";
            Cmd.Parameters.AddWithValue("id", id);

            Cmd.ExecuteReader();
            MessageBox.Show("Группа удалена!");
        }

        public DataTable getStudents()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT u.*, s.birth_date, s.address, s.phone, g.name AS group_name FROM users u JOIN students s ON s.user_id = u.id JOIN groups g ON g.id = s.group_id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getStudentsByGroup(int teacher_id)
        {
            connection();
            DataTable group = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM groups WHERE teacher_id = :teacher_id;";
            Cmd.Parameters.AddWithValue("teacher_id", teacher_id);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            group.Load(dr);

            DataTable dt = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT u.*, s.birth_date, s.address, s.phone, g.name AS group_name FROM users u JOIN students s ON s.user_id = u.id JOIN groups g ON g.id = s.group_id WHERE g.id = :id;";
            Cmd.Parameters.AddWithValue("id", group.Rows[0]["id"]);

            NpgsqlDataReader dr1 = Cmd.ExecuteReader();
            dt.Load(dr1);
            return dt;
        }

        public DataTable getGradesByGroup(int teacher_id)
        {
            connection();
            DataTable group = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM groups WHERE teacher_id = :teacher_id;";
            Cmd.Parameters.AddWithValue("teacher_id", teacher_id);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            group.Load(dr);

            DataTable dt = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT gr.id, gr.subject, gr.grade, gr.date, u.full_name FROM grades gr JOIN students s ON s.id = gr.student_id JOIN users u ON s.user_id = u.id JOIN groups g ON g.id = s.group_id WHERE g.id = :id;";
            Cmd.Parameters.AddWithValue("id", group.Rows[0]["id"]);

            NpgsqlDataReader dr1 = Cmd.ExecuteReader();
            dt.Load(dr1);
            return dt;
        }

        public void createGrade(string subject, int grade, int user_id)
        {
            DataTable dt = new DataTable();
            connection();

            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM students WHERE user_id = :user_id";
            Cmd.Parameters.AddWithValue("user_id", user_id);

            NpgsqlDataReader dr1 = Cmd.ExecuteReader();
            DataTable student = new DataTable();
            student.Load(dr1);

            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO grades (subject, grade, student_id) VALUES (:subject,:grade, :student_id);";
            Cmd.Parameters.AddWithValue("subject", subject);
            Cmd.Parameters.AddWithValue("grade", grade);
            Cmd.Parameters.AddWithValue("student_id", student.Rows[0]["id"]);

            Cmd.ExecuteReader();
            MessageBox.Show("Оценка добавлена!");
        }

        public void createStudent(string username, string pass, string fio, string number, string address, DateTime date, int group_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO users (username, password, role, full_name) VALUES (:username,:pass,'Student',:fio);";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.Parameters.AddWithValue("fio", fio);

            Cmd.ExecuteReader();


            DataTable user = new DataTable();
            user = login(username, pass);

            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO students (user_id, group_id, birth_date, address, phone) VALUES (:user_id,:group_id,:birth_date,:address, :phone);";
            Cmd.Parameters.AddWithValue("user_id", Convert.ToInt32(user.Rows[0]["id"]));
            Cmd.Parameters.AddWithValue("group_id", group_id);
            Cmd.Parameters.AddWithValue("birth_date", date);
            Cmd.Parameters.AddWithValue("address", address);
            Cmd.Parameters.AddWithValue("phone", number);

            Cmd.ExecuteReader();

            MessageBox.Show("Студент Добавлен!");
        }

        public DataTable getGroupName(int teacher_id)
        {
            connection();
            DataTable group = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM groups WHERE teacher_id = :teacher_id;";
            Cmd.Parameters.AddWithValue("teacher_id", teacher_id);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            group.Load(dr);

            return group;
         }

        public void deleteGrade(int id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "DELETE FROM grades WHERE id = :id;";
            Cmd.Parameters.AddWithValue("id", id);

            Cmd.ExecuteReader();
            MessageBox.Show("Оценка удалена!");
        }

        public DataTable getGradesStudents(int user_id)
        {
            connection();
            DataTable dt = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT gr.id, gr.subject, gr.grade, gr.date, u.full_name FROM grades gr JOIN students s ON s.id = gr.student_id JOIN users u ON s.user_id = u.id JOIN groups g ON g.id = s.group_id WHERE u.id = :id;";
            Cmd.Parameters.AddWithValue("id", user_id);

            NpgsqlDataReader dr1 = Cmd.ExecuteReader();
            dt.Load(dr1);
            return dt;
        }

        public DataTable getStudentsByUser(int user_id)
        {
            connection();
            DataTable dt = new DataTable();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM students WHERE user_id = :user_id;";
            Cmd.Parameters.AddWithValue("user_id", user_id);

            NpgsqlDataReader dr1 = Cmd.ExecuteReader();
            dt.Load(dr1);
            return dt;
        }
    }
}
