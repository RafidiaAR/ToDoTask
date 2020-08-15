using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTask.Models;
using ToDoTask.Repository.Interface;

namespace ToDoTask.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) 
        {
            _context = context;
        }
        public Tasks GetTask() 
        {
            return _context.Tasks.FirstOrDefault();
        }
    }
}
