using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTask.Dto;
using ToDoTask.Models;

namespace ToDoTask.Repository.Interface
{
    public interface ITaskRepository
    {
        List<TaskDto> GetAllTask();
        void Create(Tasks data);
        void Update(Tasks data);
        void Delete(int id);
        TaskDto FindById(int id);
        void UpdateDone(TaskList data);
        List<TaskDto> GetTodayTask();
    }
}
