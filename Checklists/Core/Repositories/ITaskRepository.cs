using System.Collections.Generic;
using Checklists.Core.Models;

namespace Checklists.Core.Repositories
{
    public interface ITaskRepository
    {
        void Add(Task task);
        Task GetTaskFromChecklist(int checklistId, int taskId);
        Task GetTaskWithChecklist(int taskId);
        IEnumerable<Task> GetTasksFromChecklist(int checklistId);
    }
}