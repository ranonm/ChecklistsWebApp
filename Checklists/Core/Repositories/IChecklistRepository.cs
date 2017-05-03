using System.Collections.Generic;
using Checklists.Core.Models;

namespace Checklists.Core.Repositories
{
    public interface IChecklistRepository
    {
        IEnumerable<Checklist> GetChecklistsCreatedByUser(string authorId);
        Checklist GetChecklistWithTasks(int checklistId);
        Checklist GetChecklist(int checklistId);
        void Add(Checklist checklist);
    }
}