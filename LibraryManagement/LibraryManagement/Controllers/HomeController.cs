using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.VIewModels;
using Microsoft.AspNetCore.Http;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoContext _demoContext;
        public HomeController(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            _demoContext.Users.Add(user);
            _demoContext.SaveChanges();
            int id = _demoContext.Users.Max(x => x.Id);
            HttpContext.Session.SetString("SessionName", user.Name);
            HttpContext.Session.SetString("SessionRole", "student");
            HttpContext.Session.SetInt32("SessionId", id);

            return RedirectToAction("Index", "Student");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginView loginView)
        {
            var u = _demoContext.Users.Where(x => x.Email == loginView.Email
                    && x.Password == loginView.Password).FirstOrDefault();
            if(u != null)
            {
                HttpContext.Session.SetString("SessionName", u.Name);
                HttpContext.Session.SetString("SessionRole", u.UserType);
                HttpContext.Session.SetInt32("SessionId", u.Id);
                if (u.UserType == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Student");
                }
                
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
