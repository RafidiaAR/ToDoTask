using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTask.Dto
{
    public class TaskListDto
    {
        public int TaskListId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
