using System.Collections.Generic;
using Checklists.Models;

namespace Checklists.Repositories
{
    public interface ITaskRepository
    {
        void Add(Task task);
        Task GetTaskFromChecklist(int checklistId, int taskId);
        Task GetTaskWithChecklist(int taskId);
        IEnumerable<Task> GetTasksFromChecklist(int checklistId);
    }
}