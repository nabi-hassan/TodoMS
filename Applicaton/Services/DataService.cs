using Applicaton.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Applicaton.Services
{
    public class DataService : IDataService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DataService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<TodoGroup> TodoGroupRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            TodoGroupsService = new TodoGroupsService(_unitOfWork, _mapper, TodoGroupRepo);
        }
        public ITodoGroupsService TodoGroupsService { get; }
    }
}
