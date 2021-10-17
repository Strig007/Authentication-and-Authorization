using FourthWebApp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FourthWebApp.Models
{
    public class Database
    {
        SqlConnection conn;

        public Students Students { get; set; }

        public Departments Departments { get; set; }

        public Courses Courses { get; set; }

        public Users Users { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-RHSOBA2\SQLEXPRESS; Database=Strig; Integrated Security=true";
            conn = new SqlConnection(connString);

            Students = new Students(conn);
            Departments = new Departments();
            Courses = new Courses(conn);
            Users = new Users(conn);
        }
    }
}