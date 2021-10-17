using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FourthWebApp.Models.Entities;
using System.Data.SqlClient;
using FourthWebApp.Models;
using FourthWebApp.Auth;

namespace FourthWebApp.Controllers
{
    [AdminAccess]
    public class StudentController : Controller
    {
        // GET: Student
        [AllowAnonymous]
        public ActionResult Index()
        {
            Database db = new Database();
            var students = db.Students.Get();

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Create(s);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var s = db.Students.Get(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit (Student s)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                var r = db.Students.Update(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }
    }
}