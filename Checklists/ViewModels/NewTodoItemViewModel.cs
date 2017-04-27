using Checklists.Models;

namespace Checklists.ViewModels
{
    public class NewTodoItemViewModel
    {
        public string Title { get; set; }
        public TodoItem TodoItem { get; set; }
    }
}