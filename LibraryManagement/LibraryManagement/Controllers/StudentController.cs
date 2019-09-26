using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly DemoContext _demoContext;
        private readonly IRepository<User> _userRepository;
        public StudentController(DemoContext demoContext, IRepository<User> userRepository)
        {
            _demoContext = demoContext;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            int id = Convert.ToInt32(this.HttpContext.Session.GetInt32("SessionId"));
            var u = _demoContext.Users.Find(id);
            User user = new User();
            user.Name = u.Name;
            user.Email = u.Email;
            user.Address = u.Address;
            user.Password = u.Password;
            return View(user);
        }
    }
}