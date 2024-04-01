using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicaton.Dtos
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public int? TodoListId { get; set; }

        [Display(Name = "Todo Item")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(512, ErrorMessage = "{0} can not be more than {1} characters")]
        public string TodoItem { get; set; }

        [Display(Name = "Created On")]
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Due Date")]
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Reminder Date")]
        [Column(TypeName = "datetime")]
        public DateTime? ReminderDate { get; set; }


        [StringLength(32, ErrorMessage = "{0} can not be more than {1} characters")]
        public string Repeat { get; set; }

        public bool Important { get; set; }

        public bool Completed { get; set; }
    }
}
