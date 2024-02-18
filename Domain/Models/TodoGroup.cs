using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TodoGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
