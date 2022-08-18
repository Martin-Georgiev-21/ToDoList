using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo.Controllers
{
    public class UsersManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
