using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaton.ViewModels
{
    public class TodoVM
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
    }
}
