using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTask.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }

    }
}
