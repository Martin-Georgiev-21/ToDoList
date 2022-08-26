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

        public IActionResult CreateEditDeleteView()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User obj)
        {
            DateTime now = DateTime.Now;
            obj.CreatorId = Logged.LoggedId;
            obj.DateOfCreation = now.ToString();
            obj.IdOfTheEditor = Logged.LoggedId;
            obj.DateOfLastChange = now.ToString();
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteView");
        }

        public IActionResult EditUser(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(User obj)
        {
            DateTime now = DateTime.Now;
            obj.IdOfTheEditor = Logged.LoggedId;
            obj.DateOfLastChange = now.ToString();
            _db.Users.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteView");
        }
        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostUser(int? id)
        {
            var obj = _db.Users.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Users.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteView");
        }

    }
}
