using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicaton.Dtos
{
    public class TodoGroupDTO
    {
        public int Id { get; set; }

        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(128, ErrorMessage = "{0} can not be more than {1} characters")]
        public string GroupName { get; set; }

        [Display(Name = "Created On")]
        [Column(TypeName = "Date Time")]
        public DateTime CreatedOn { get; set; }
    }
}
