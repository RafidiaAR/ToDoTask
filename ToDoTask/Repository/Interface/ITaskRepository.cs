using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTask.Models;

namespace ToDoTask.Repository.Interface
{
    public interface ITaskRepository
    {
        Tasks GetTask();
    }
}
