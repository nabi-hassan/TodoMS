using Applicaton.Dtos;
using Applicaton.Interfaces;
using Applicaton.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Applicaton.Services
{
    public class TodoListsService : Service<TodoList, TodoListDTO, TodoListVM>, ITodoListsService
    {
        public TodoListsService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<TodoList> repository)
            : base(unitOfWork, mapper, repository)
        {
        }
        public async Task<TodoListVM> GetDuplicate(TodoListDTO dto)
        {
            if (dto == null) return null;
            var model = _mapper.Map<TodoList>(dto);
            var matchingModel = await _unitOfWork.TodoListsRepository.GetDuplicate(model);
            if (matchingModel == null) return null;
            var vm = _mapper.Map<TodoListVM>(matchingModel);
            return vm;
        }
    }
}
