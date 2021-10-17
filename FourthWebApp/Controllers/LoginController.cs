using FourthWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FourthWebApp.Models.Entities;
using System.Web.Security;

namespace FourthWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                var user = db.Users.Authenticate(Username, Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    return RedirectToAction("Index", "Student");
                }
                return View();
            }
            return View();
        }
    }
}