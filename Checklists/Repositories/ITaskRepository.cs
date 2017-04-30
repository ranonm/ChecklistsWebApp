using Checklists.Models;

namespace Checklists.Repositories
{
    public interface ITaskRepository
    {
        void Add(Task task);
        Task GetTaskFromChecklist(int checklistId, int taskId);
        Task GetTaskWithChecklist(int taskId);
    }
}