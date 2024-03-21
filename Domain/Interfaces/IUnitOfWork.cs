using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoGroupsRepository TodoGroupsRepository { get; }
        ITodoListsRepository TodoListsRepository { get; }
        ITodosRepository TodosRepository { get; }
        Task<int> SaveChanges();    
    }
}
