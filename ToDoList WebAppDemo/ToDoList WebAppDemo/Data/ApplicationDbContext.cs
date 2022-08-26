using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_WebAppDemo.Models;
using Task = ToDoList_WebAppDemo.Models.Task;

namespace ToDoList_WebAppDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<SharedToDoListWithUser> SharedToDoListsWithUsers { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
