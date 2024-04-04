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
    public interface ITodoListsService : IService<TodoList, TodoListDTO, TodoListVM>
    {
        Task<TodoListVM> GetDuplicate(TodoListDTO dto);
        Task<List<TodoListVM>> GetByGroupID(int? gid);
    }
}
