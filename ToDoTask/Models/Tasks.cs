using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTask.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get;set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set;}
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Progress { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime? FinishDate { get; set; }
        public ICollection<TaskList> TaskLists { get; set; }
    }
}
