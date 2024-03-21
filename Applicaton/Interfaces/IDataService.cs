namespace Applicaton.Interfaces
{
    public interface IDataService
    {
        ITodoGroupsService TodoGroupsService { get; }
        ITodoListsService TodoListsService { get; }
        ITodosService TodosService { get; }

    }
}
