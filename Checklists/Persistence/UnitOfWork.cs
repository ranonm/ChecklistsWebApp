using Checklists.Core;
using Checklists.Core.Models;
using Checklists.Core.Repositories;
using Checklists.Persistence.Repositories;

namespace Checklists.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ChecklistRepository = new ChecklistRepository(_context);
            TaskRepository = new TaskRepository(_context);
        }

        public IChecklistRepository ChecklistRepository { get; }
        public ITaskRepository TaskRepository { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }


    }
}