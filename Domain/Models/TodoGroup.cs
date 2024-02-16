using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TodoGroup
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
