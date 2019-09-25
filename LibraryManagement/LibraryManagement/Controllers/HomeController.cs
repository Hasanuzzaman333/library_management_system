using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.VIewModels;

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
            return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
