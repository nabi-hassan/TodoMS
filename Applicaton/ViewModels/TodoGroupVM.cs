using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaton.ViewModels
{
    public class TodoGroupVM
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
