namespace WebApp.ServiceInterfaces
{
    public interface IDataService
    {
        public ITodoGroupsService TodoGroups {  get; }
        public ITodoListsService TodoLists { get; }
        public ITodosService Todos { get; }
    }
}
