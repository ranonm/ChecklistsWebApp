using System.Collections;
using System.Collections.Generic;
using Checklists.Models;

namespace Checklists.Repositories
{
    public interface IChecklistRepository
    {
        IEnumerable<Checklist> GetChecklistsCreatedByAuthor(string authorId);
        Checklist GetChecklistById(int id);
        void Add(Checklist checklist);
    }
}