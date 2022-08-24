using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo.Models
{
    public class ToDoList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public bool IsDone { get; set; }

        [DataType(DataType.Text)]
        public string Discription { get; set; }

        public int UserId { get; set; }

    }
}
