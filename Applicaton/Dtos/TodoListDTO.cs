using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicaton.Dtos
{
    public class TodoListDTO
    {
        public int Id { get; set; }
        public int? TodoGroupId { get; set; }

        [Display(Name = "List Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(128, ErrorMessage = "{0} can not be more than {1} characters")]
        public string ListName { get; set; }

        [Display(Name = "Created On")]
        [Column(TypeName = "Date Time")]
        public DateTime CreatedOn { get; set; }
    }
}
