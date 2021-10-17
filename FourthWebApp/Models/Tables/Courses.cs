using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FourthWebApp.Models.Tables
{
    public class Courses
    {
        SqlConnection conn;

        public Courses (SqlConnection conn)
        {
            this.conn = conn;
        }
    }
}