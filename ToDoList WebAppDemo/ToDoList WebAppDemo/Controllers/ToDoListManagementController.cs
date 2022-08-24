using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_WebAppDemo.Data;
using ToDoList_WebAppDemo.Models;

namespace ToDoList_WebAppDemo.Controllers
{
    public class ToDoListManagementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoListManagementController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult CreateEditDeleteListView()
        {
            IEnumerable<ToDoList> objList = _db.ToDoLists;
            return View(objList);
        }
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateToDoList(ToDoList obj)
        {
            DateTime now = DateTime.Now;
            obj.CreatorId = Logged.LoggedId;
            obj.DateOfCreation = now.ToString();
            obj.IdOfTheEditor = Logged.LoggedId;
            obj.DateOfLastChange = now.ToString();
            _db.ToDoLists.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteListView");
        }
        public IActionResult EditList(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditList(ToDoList obj)
        {
            DateTime now = DateTime.Now;
            obj.IdOfTheEditor = Logged.LoggedId;
            obj.DateOfLastChange = now.ToString();
            _db.ToDoLists.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteListView");
        }
        public IActionResult DeleteList(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostList(int? id)
        {
            var obj = _db.ToDoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDoLists.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteListView");
        }
        public IActionResult ShareList(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}

