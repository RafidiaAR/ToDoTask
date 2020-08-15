using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTask.Dto;
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
        public List<TaskDto> GetAllTask()
        {
            var data = (from a in _context.Tasks
                        join b in _context.TaskLists on a.TaskId equals b.TaskId
                        select new TaskDto
                        {
                            TaskId = a.TaskId,
                            Title = a.Title,
                            Description = a.Description,
                            StartDate = a.StartDate,
                            DueDate = a.DueDate,
                            Progress = a.Progress,
                            CreateDate = a.CreatedDate,
                            FinishDate = a.FinishDate,
                            TaskList = a.TaskLists.Select(z => new TaskListDto
                            {
                                TaskListId = z.TaskListId,
                                TaskName = z.TaskName,
                                IsComplete = z.IsComplete,
                                FinishDate = z.FinishDate
                            }).ToList()
                        }).ToList();
            return data;
        }
        public void Create(Tasks data) 
        {
            _context.Tasks.Add(data);
            _context.SaveChanges();
        }
        public void Update(Tasks data) 
        {
            _context.Tasks.Update(data);
            if (data.TaskLists != null) 
            {
                foreach (TaskList item in data.TaskLists) 
                {
                    _context.TaskLists.Update(item);
                }
            }
            _context.SaveChanges();
        }
        public void UpdateDone(TaskList data)
        {
            DateTime? nullableDate = null;
            TaskList dataToUpdate = (from a in _context.TaskLists where a.TaskListId == data.TaskListId select a).FirstOrDefault();
            dataToUpdate.IsComplete = data.IsComplete;
            dataToUpdate.FinishDate = data.IsComplete == true ? DateTime.Now : nullableDate;
            _context.TaskLists.Update(dataToUpdate);
            _context.SaveChanges();

            double progress = 100;
            List<TaskList> dataTaskList = (from a in _context.TaskLists where a.TaskId == data.TaskId select a).ToList();
            double countComplete = dataTaskList.Where(x => x.IsComplete == true).Count();
            double countTotal = dataTaskList.Count();

            progress = (countTotal / countComplete) == 0 ? 0 : 100 / (countTotal / countComplete);
            Tasks dataTask = (from a in _context.Tasks where a.TaskId == data.TaskId select a).FirstOrDefault();
            dataTask.Progress = progress;
            dataTask.FinishDate = progress == 100 ? DateTime.Now : nullableDate;
            _context.Tasks.Update(dataTask);
            _context.SaveChanges();
        }
        public void Delete(int id) 
        {
            List<TaskList> listObj = (from a in _context.TaskLists where a.TaskId == id select a).ToList();
            Tasks obj = (from a in _context.Tasks where a.TaskId == id select a).FirstOrDefault();
            _context.TaskLists.RemoveRange(listObj);
            _context.Tasks.Remove(obj);
            _context.SaveChanges();
        }
        public TaskDto FindById(int id) 
        {
            var data = (from a in _context.Tasks
                        join b in _context.TaskLists on a.TaskId equals b.TaskId
                        where a.TaskId == id
                        select new TaskDto
                        {
                            TaskId = a.TaskId,
                            Title = a.Title,
                            Description = a.Description,
                            StartDate = a.StartDate,
                            DueDate = a.DueDate,
                            Progress = a.Progress,
                            CreateDate = a.CreatedDate,
                            FinishDate = a.FinishDate,
                            TaskList = a.TaskLists.Select(z => new TaskListDto
                            {
                                TaskListId = z.TaskListId,
                                TaskName = z.TaskName,
                                IsComplete = z.IsComplete,
                                FinishDate = z.FinishDate
                            }).ToList()
                        }).FirstOrDefault();
            return data;
        }
        public List<TaskDto> GetTodayTask()
        {
            var data = (from a in _context.Tasks
                        join b in _context.TaskLists on a.TaskId equals b.TaskId
                        where a.StartDate.Date == DateTime.Now.Date
                        select new TaskDto
                        {
                            TaskId = a.TaskId,
                            Title = a.Title,
                            Description = a.Description,
                            StartDate = a.StartDate,
                            DueDate = a.DueDate,
                            Progress = a.Progress,
                            CreateDate = a.CreatedDate,
                            FinishDate = a.FinishDate,
                            TaskList = a.TaskLists.Select(z => new TaskListDto
                            {
                                TaskListId = z.TaskListId,
                                TaskName = z.TaskName,
                                IsComplete = z.IsComplete,
                                FinishDate = z.FinishDate
                            }).ToList()
                        }).ToList();
            return data;
        }
        public List<TaskDto> GetTomorrowTask()
        {
            var data = (from a in _context.Tasks
                        join b in _context.TaskLists on a.TaskId equals b.TaskId
                        where a.StartDate.Date == DateTime.Now.AddDays(1).Date
                        select new TaskDto
                        {
                            TaskId = a.TaskId,
                            Title = a.Title,
                            Description = a.Description,
                            StartDate = a.StartDate,
                            DueDate = a.DueDate,
                            Progress = a.Progress,
                            CreateDate = a.CreatedDate,
                            FinishDate = a.FinishDate,
                            TaskList = a.TaskLists.Select(z => new TaskListDto
                            {
                                TaskListId = z.TaskListId,
                                TaskName = z.TaskName,
                                IsComplete = z.IsComplete,
                                FinishDate = z.FinishDate
                            }).ToList()
                        }).ToList();
            return data;
        }
    }
}
