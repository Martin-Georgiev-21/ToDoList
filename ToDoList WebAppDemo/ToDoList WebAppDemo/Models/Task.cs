using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo.Models
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int ListId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Creation")]
        public string DateOfCreation { get; set; }

        [DisplayName("Creater ID")]
        public int CreatorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Last Change")]
        public string DateOfLastChange { get; set; }

        public int IdOfTheEditor { get; set; }


    }
}
