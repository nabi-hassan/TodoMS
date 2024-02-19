using Applicaton.Dtos;
using Applicaton.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaton.Interfaces
{
    public interface ITodoGroupsService : IService<TodoGroup, TodoGroupDTO, TodoGroupVM>
    {
        Task<TodoGroupVM> GetDuplicate(TodoGroupDTO dto);
    }
}
