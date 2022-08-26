using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_WebAppDemo.Data;
using ToDoList_WebAppDemo.Models;
using Task = ToDoList_WebAppDemo.Models.Task;

namespace ToDoList_WebAppDemo.Controllers
{
    public class TaskManagementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TaskManagementController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ChooseListView()
        {
            IEnumerable<ToDoList> objList = _db.ToDoLists;
            IEnumerable<SharedToDoListWithUser> shareList = _db.SharedToDoListsWithUsers;
            BigViewModel bigviewmodel = new BigViewModel(objList, shareList);
            return View(bigviewmodel);
        }
        public IActionResult TaskView(int? id)
        {
            if (id != null)
            {
                TasksInfo.TaskToDoListId = id.Value;
            }
            return TaskViewListed();
        }
        public IActionResult TaskViewListed()
        {
            IEnumerable<Task> objList = _db.Tasks;
            return View(objList);
        }
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(Task obj)
        {
            DateTime now = DateTime.Now;
            obj.ListId = TasksInfo.TaskToDoListId;
            obj.CreatorId = Logged.LoggedId;
            obj.DateOfCreation = now.ToString();
            obj.IdOfTheEditor = Logged.LoggedId;
            obj.DateOfLastChange = now.ToString();
            obj.IsComplete = false;
            _db.Tasks.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("TaskView");
        }
        public IActionResult DeleteTask(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult DeletePostTask(int? id)
        {
            var obj = _db.Tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Tasks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("TaskView");
        }
    }
}
