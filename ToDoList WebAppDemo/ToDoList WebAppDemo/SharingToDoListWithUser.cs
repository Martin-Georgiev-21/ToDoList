using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo
{
    static public class SharingToDoListWithUser
    {
        private static int toDoListId;
        private static int userIdForShare;

        public static int ToDoListId { get => toDoListId; set=> toDoListId=value; }
        public static int UserIdForShare { get => userIdForShare; set => userIdForShare = value; }

    }
}
