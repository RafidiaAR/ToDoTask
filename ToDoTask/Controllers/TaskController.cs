using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Dto;
using ToDoTask.Models;
using ToDoTask.Repository.Interface;

namespace ToDoTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;
        public TaskController(ITaskRepository taskRepo) 
        {
            _taskRepo = taskRepo;
        }

        [HttpPost]
        public void Create(TaskDto param) 
        {
            try {
                Tasks data = new Tasks
                {
                    Title = param.Title,
                    Description = param.Description,
                    StartDate = param.StartDate,
                    DueDate = param.DueDate,
                    Progress = 0,
                    CreatedDate = DateTime.Now,
                    TaskLists = param.TaskList.Select(x => new TaskList
                    {
                        TaskName = x.TaskName
                    }).ToList()
                };
                _taskRepo.Create(data);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public void Update(TaskDto param)
        {
            try
            {
                Tasks data = new Tasks
                {
                    TaskId = param.TaskId,
                    Title = param.Title,
                    Description = param.Description,
                    StartDate = param.StartDate,
                    DueDate = param.DueDate,
                    Progress = param.Progress,
                    FinishDate = param.FinishDate,
                    TaskLists = param.TaskList.Select(x => new TaskList
                    {
                        TaskListId = x.TaskListId,
                        TaskName = x.TaskName,
                        IsComplete = x.IsComplete,
                        FinishDate = x.FinishDate
                    }).ToList()
                };
                _taskRepo.Update(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<TaskDto>> GetAllTask() 
        {
            try {
                List<TaskDto>  obj = _taskRepo.GetAllTask();
                return obj;
            } 
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById(int id)
        {
            try
            {
                TaskDto obj = _taskRepo.FindById(id);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _taskRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public void UpdateDoneTask(TaskListDto param)
        {
            try
            {
                TaskList data = new TaskList
                {
                    TaskListId = param.TaskListId,
                    TaskId = param.TaskId,
                    IsComplete = param.IsComplete
                };

                _taskRepo.UpdateDone(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult<List<TaskDto>> GetIncomingToDo(int param)
        {
            try
            {
                List<TaskDto> obj = _taskRepo.GetAllTask();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
