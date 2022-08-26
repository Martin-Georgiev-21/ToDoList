using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo
{
    static public class TasksInfo
    {
        private static int taskToDoListId;
        public static int TaskToDoListId { get => taskToDoListId; set => taskToDoListId = value; }
    }
}
