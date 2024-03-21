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
        public ITodoGroupsService TodoGroupsService { get; }
        public ITodoListsService TodoListsService { get; }
        public ITodosService TodosService { get; }

        public DataService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IRepository<TodoGroup> TodoGroupRepo,
            IRepository<TodoList> TodoListRepo,
            IRepository<Todo> TodoRepo
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            TodoGroupsService = new TodoGroupsService(_unitOfWork, _mapper, TodoGroupRepo);
            TodoListsService = new TodoListsService(_unitOfWork, _mapper, TodoListRepo);
            TodosService = new TodosService(_unitOfWork, _mapper, TodoRepo);
        }
    }
}
