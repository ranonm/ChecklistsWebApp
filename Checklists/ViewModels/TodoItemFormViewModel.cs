using System.ComponentModel.DataAnnotations;
using Checklists.Models;

namespace Checklists.ViewModels
{
    public class TodoItemFormViewModel
    {
        public TodoItemFormViewModel()
        {
            Id = 0;
        }

        public TodoItemFormViewModel(TodoItem item)
        {
            Id = item.Id;
            Title = item.Title;
            ChecklistId = item.ChecklistId;
        }

        public string PageTitle
        {
            get { return Id == 0 ? "New Item" : "Modify Item"; }
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int ChecklistId { get; set; }
    }
}