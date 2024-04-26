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
            var existingModel = await _unitOfWork.TodosRepository.GetDuplicate(model);
            if (existingModel == null) return null;
            var vm = _mapper.Map<TodoVM>(existingModel);
            return vm;
        }

        public async Task<List<TodoVM>> GetByListID(int? lid)
        {
            if (lid <= 0) return null;

            var models = await _unitOfWork.TodosRepository.GetByListID(lid);

            if (models == null) return null;
            var ModelVMs = _mapper.Map<List<TodoVM>>(models);
            return ModelVMs;
        }
    }
}
