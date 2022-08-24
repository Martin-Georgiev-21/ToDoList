using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo.Models
{
    public class BigViewModel
    {
        public BigViewModel(IEnumerable<ToDoList> objList, IEnumerable<SharedToDoListWithUser> shareList)
        {
            this.objList = objList;
            this.shareList = shareList;
        }

        private IEnumerable<ToDoList> objList;
        private IEnumerable<SharedToDoListWithUser> shareList;

        public IEnumerable<ToDoList> ToDoList
        {
            get => objList;
            set => objList = value;
        }
        public IEnumerable<SharedToDoListWithUser> Shares
        {
            get => shareList;
            set => shareList = value;
        }
    }
}
