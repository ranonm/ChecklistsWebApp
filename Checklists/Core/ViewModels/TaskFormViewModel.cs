using System.ComponentModel.DataAnnotations;
using Checklists.Core.Models;

namespace Checklists.Core.ViewModels
{
    public class TaskFormViewModel
    {
        public TaskFormViewModel()
        {
            Id = 0;
        }

        public TaskFormViewModel(Task item)
        {
            Id = item.Id;
            Title = item.Title;
            ChecklistId = item.ChecklistId;
        }

        public string PageTitle
        {
            get { return Id == 0 ? "New Task" : "Modify Task"; }
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int ChecklistId { get; set; }
    }
}