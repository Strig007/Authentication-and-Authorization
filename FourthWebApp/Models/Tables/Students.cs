using FourthWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FourthWebApp.Models.Tables
{
    public class Students
    {
        SqlConnection conn;

        public Students (SqlConnection conn)
        {
            this.conn = conn;
        }
        
        public void Create (Student s)
        {
            conn.Open();
            string query = String.Format("insert into Students values ('{0}', '{1}', '{2}', 0.0)", s.Name, s.Gender, s.Dob);
            SqlCommand cmd = new SqlCommand(query, conn);

            int r = cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Student> Get()
        {
            conn.Open();

            string query = "select * from Students";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                Student s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))
                };

                students.Add(s);
            }

            conn.Close();
            return students;
        }

        public Student Get (int id)
        {
            conn.Open();
            string query = String.Format("select * from Students where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            Student s = null;
            while (reader.Read())
            {
                s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))
                };
            }
            conn.Close();

            return s;
        }


        public int Update (Student p)
        {
            conn.Open();
            string query = String.Format("update Students set Name='{0}',Dob='{1}',Gender='{2}' where Id={3}", p.Name,
                p.Dob, p.Gender, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return r;
        }
    }
}