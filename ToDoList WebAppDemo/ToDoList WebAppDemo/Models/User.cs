using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_WebAppDemo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName {get; set;}

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public string DateOfCreation { get; set; }

        public int CreatorId { get; set; }

        [DataType(DataType.Date)]
        public string DateOfLastChange { get; set; }

        public int IdOfTheEditor { get; set; }
        public bool IsAdmin { get; set; }
    }
}
