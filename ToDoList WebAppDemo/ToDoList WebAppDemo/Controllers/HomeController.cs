using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_WebAppDemo.Data;
using ToDoList_WebAppDemo.Models;

namespace ToDoList_WebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(User obj)
        {
            foreach(var item in _db.Users)
            {
                if(item.Username == obj.Username && item.Password == obj.Password)
                {
                    Logged.LoggedIn = true;
                    Logged.LoggedId = item.Id;
                    if (item.IsAdmin == true)
                    {
                        Logged.IsAdmin = true;
                    }
                    else Logged.IsAdmin = false;
                    if (item.IsAdmin == true)
                    {
                        return View("../AfterLogInAdmin");
                    }
                    else return View("../AfterLogInNoAdmin");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult LogOut()
        {
            Logged.LoggedIn = false;
            return View("../Index");
        }
        public IActionResult Admin()
        {
            return View("../AfterLogInAdmin");
        }

        public IActionResult NoAdmin()
        {
            return View("../AfterLogInNoAdmin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
