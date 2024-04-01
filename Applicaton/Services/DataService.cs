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
            IRepository<TodoGroup> TodoGroupsRepo,
            IRepository<TodoList> TodoListsRepo,
            IRepository<Todo> TodosRepo
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            TodoGroupsService = new TodoGroupsService(_unitOfWork, _mapper, TodoGroupsRepo);
            TodoListsService = new TodoListsService(_unitOfWork, _mapper, TodoListsRepo);
            TodosService = new TodosService(_unitOfWork, _mapper, TodosRepo);
        }
    }
}
