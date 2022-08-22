using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_WebAppDemo.Data;
using ToDoList_WebAppDemo.Models;
using Microsoft.AspNetCore;

namespace ToDoList_WebAppDemo.Controllers
{
    public class UsersManagementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersManagementController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEditDeleteView()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }
    }
}
