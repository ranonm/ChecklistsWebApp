using Checklists.Core.Repositories;

namespace Checklists.Core
{
    public interface IUnitOfWork
    {
        IChecklistRepository ChecklistRepository { get; }
        ITaskRepository TaskRepository { get; }
        void Complete();
    }
}