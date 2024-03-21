using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaton.ViewModels
{
    public class TodoListVM
    {
        public int Id { get; set; }
        public int? TodoGroupId { get; set; }
        public string ListName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
