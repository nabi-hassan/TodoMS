using Applicaton.Dtos;
using Applicaton.Interfaces;
using Applicaton.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Applicaton.Services
{
    public class TodosService : Service<Todo, TodoDTO, TodoVM>, ITodosService
    {
        public TodosService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Todo> repository)
            : base(unitOfWork, mapper, repository)
        {
        }
        public async Task<TodoVM> GetDuplicate(TodoDTO dto)
        {
            if (dto == null) return null;
            var model = _mapper.Map<Todo>(dto);
            var matchingModel = await _unitOfWork.TodosRepository.GetDuplicate(model);
            if (matchingModel == null) return null;
            var vm = _mapper.Map<TodoVM>(matchingModel);
            return vm;
        }
    }
}
