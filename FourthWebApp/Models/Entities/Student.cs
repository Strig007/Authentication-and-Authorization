using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FourthWebApp.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(10, ErrorMessage = "Max length is 10!")]
        [MinLength(5, ErrorMessage = "Minimum length is 5!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select your gender!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select your date of birth!")]
        public string Dob { get; set; }

        public Double Cgpa { get; set; }
    }
}