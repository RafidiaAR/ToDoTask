using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTask.Models
{
    public class TaskList
    {
        [Key]
        public int TaskListId { get; set; }
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        [Required]
        [StringLength(300)]
        public string TaskName { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
