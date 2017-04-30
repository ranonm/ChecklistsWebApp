using System.Collections.Generic;
using Checklists.Models;

namespace Checklists.ViewModels
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