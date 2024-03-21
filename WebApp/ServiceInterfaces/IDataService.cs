namespace WebApp.ServiceInterfaces
{
    public interface IDataService
    {
        public ITodoGroupsService TodoGroups {  get; }
    }
}
