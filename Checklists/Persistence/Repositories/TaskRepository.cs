using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Checklists.Core.Models;
using Checklists.Core.Repositories;

namespace Checklists.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Task task)
        {
            _context.Tasks.Add(task);
        }

        public Task GetTaskFromChecklist(int checklistId, int taskId)
        {
            return _context.Tasks
                .Include(t => t.Checklist)
                .SingleOrDefault(t => t.Id == taskId && t.ChecklistId == checklistId && !t.IsDeleted);
        }

        public Task GetTaskWithChecklist(int taskId)
        {
            return _context.Tasks
                .Include(t => t.Checklist)
                .SingleOrDefault(t => t.Id == taskId);
        }

        public IEnumerable<Task> GetTasksFromChecklist(int checklistId)
        {
            return _context.Tasks
                .Where(t => t.ChecklistId == checklistId && !t.IsDeleted)
                .ToList();
        }
    }
}