using System.Collections.Generic;
using Checklists.Core.Models;

namespace Checklists.Core.ViewModels
{
    public class TaskListingViewModel
    {
        public TaskListingViewModel(Checklist checklist, IEnumerable<Task> tasks)
        {
            ChecklistId = checklist.Id;
            Name = checklist.Name;
            Tasks = tasks;
        }

        public string Name { get; private set; }
        public int ChecklistId { get; private set; }
        public IEnumerable<Task> Tasks { get; private set; }
    }
}