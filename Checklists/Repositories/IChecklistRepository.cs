using System.Collections;
using System.Collections.Generic;
using Checklists.Models;

namespace Checklists.Repositories
{
    public interface IChecklistRepository
    {
        IEnumerable<Checklist> GetChecklistsCreatedByUser(string authorId);
        Checklist GetChecklistWithTasks(int checklistId);
        Checklist GetChecklist(int checklistId);
        void Add(Checklist checklist);
    }
}