using Applicaton.Dtos;
using Applicaton.Interfaces;
using Applicaton.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Applicaton.Services
{
    public class TodoGroupsService : Service<TodoGroup, TodoGroupDTO, TodoGroupVM>, ITodoGroupsService
    {
        public TodoGroupsService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<TodoGroup> repository)
            : base(unitOfWork, mapper, repository)
        {
        }
        public async Task<TodoGroupVM> GetDuplicate(TodoGroupDTO dto)
        {
            if (dto == null) return null;
            var model = _mapper.Map<TodoGroup>(dto);
            var matchingModel = await _unitOfWork.TodoGroupsRepository.GetDuplicate(model);
            if (matchingModel == null) return null;
            var vm = _mapper.Map<TodoGroupVM>(matchingModel);
            return vm;
        }
    }
}
