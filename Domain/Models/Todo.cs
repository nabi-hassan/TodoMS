using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public int? TodoListId { get; set; }
        public string TodoItem { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Repeat { get; set; }
        public bool Important { get; set; }
        public bool Completed { get; set; }

        public virtual TodoList TodoList{ get; set; }

    }
}
