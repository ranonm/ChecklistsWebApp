using System.Collections.Generic;
using System.Linq;
using Checklists.Models;

namespace Checklists.Repositories
{
    public class ChecklistRepository : IChecklistRepository
    {
        private readonly ApplicationDbContext _context;

        public ChecklistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddChecklist(Checklist checklist)
        {

        }

        public Checklist GetChecklistById(int id)
        {
            return _context.Checklists
                .SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Checklist> GetChecklistsCreatedByAuthor(string authorId)
        {
            return _context.Checklists
                .Where(c => c.AuthorId == authorId && !c.IsDeleted)
                .ToList();
        }

        public void Add(Checklist checklist)
        {
            _context.Checklists.Add(checklist);
        }
    }
}