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
    public interface ITodosService : IService<Todo, TodoDTO, TodoVM>
    {
        Task<TodoVM> GetDuplicate(TodoDTO dto);
    }
}
