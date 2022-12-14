using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ToDoList_WebAppDemo.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("First Name")]
        public string FirstName {get; set;}

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Date of Creation")]
        public string DateOfCreation { get; set; }

        [DisplayName("Creater ID")]
        public int CreatorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Last Change")]
        public string DateOfLastChange { get; set; }

        public int IdOfTheEditor { get; set; }
        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }
    }
}
