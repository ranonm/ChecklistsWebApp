using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Checklists.Models;

namespace Checklists.Repositories
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
                .SingleOrDefault(t => t.Id == taskId && t.ChecklistId == checklistId);
        }

        public Task GetTaskWithChecklist(int taskId)
        {
            return _context.Tasks
                .Include(t => t.Checklist)
                .SingleOrDefault(t => t.Id == taskId);
        }
    }
}