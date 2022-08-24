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

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string DateOfCreation { get; set; }

        public int CreatorId { get; set; }

        [DataType(DataType.Date)]
        public string DateOfLastChange { get; set; }

        public int IdOfTheEditor { get; set; }

    }
}
