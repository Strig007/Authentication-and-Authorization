using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FourthWebApp.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter username!")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please provide your password")]
        public string Password { get; set; }
    }
}