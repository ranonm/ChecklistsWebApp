using System.Collections.Generic;
using System.Linq;
using System.Web;
using Checklists.Repositories;

namespace Checklists
{
    public interface IUnitOfWork
    {
        IChecklistRepository ChecklistRepository { get; }
        ITaskRepository TaskRepository { get; }
        void Complete();
    }
}