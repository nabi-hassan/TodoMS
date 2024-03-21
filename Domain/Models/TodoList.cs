using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public int? TodoGroupId { get; set; }
        public string ListName { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual TodoGroup TodoGroup { get; set; }

    }
}
