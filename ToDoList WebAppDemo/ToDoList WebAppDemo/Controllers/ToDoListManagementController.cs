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
            IEnumerable<SharedToDoListWithUser> shareList = _db.SharedToDoListsWithUsers;
            BigViewModel bigviewmodel = new BigViewModel(objList, shareList);
            return View(bigviewmodel);
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
        public IActionResult DeletePostList(int id)
        {
            IEnumerable<SharedToDoListWithUser> objList = _db.SharedToDoListsWithUsers;
            var obj = _db.ToDoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else if (Logged.LoggedId == obj.CreatorId)
            {
                _db.ToDoLists.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("CreateEditDeleteListView");
            }
            else
            {
                foreach (var share in objList)
                {
                    if (share.UserId == Logged.LoggedId && share.ToDoListId == id)
                    {
                        _db.SharedToDoListsWithUsers.Remove(share);
                    }
                }
                _db.SaveChanges();
                return RedirectToAction("CreateEditDeleteListView");
            }
        }
        public IActionResult ShareToDoListId(int id)
        {
            SharingToDoListWithUser.ToDoListId = id;
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }
        public IActionResult ShareUserId(int id)
        {
            SharingToDoListWithUser.UserIdForShare = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateShareList(SharedToDoListWithUser obj)
        {
            obj.ToDoListId = SharingToDoListWithUser.ToDoListId;
            obj.UserId = SharingToDoListWithUser.UserIdForShare;
            _db.SharedToDoListsWithUsers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("CreateEditDeleteListView");
        }
    }
}

