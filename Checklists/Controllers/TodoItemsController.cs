using Checklists.Models;
using Checklists.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Checklists.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("checklists/{id}/items")]
        public ActionResult Index(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var checklist = _context.Checklists
                .Include(c => c.TodoItems)
                .SingleOrDefault(c => c.Id == id);

            if (checklist == null)
                return HttpNotFound();

            return View(checklist);
        }

        [Route("checklists/{id}/items/new")]
        public ActionResult New(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var isChecklistExists = _context.Checklists.Any(c => c.Id == id);

            if (!isChecklistExists)
                return HttpNotFound();

            var todoItem = new TodoItem
            {
                ChecklistId = (int)id
            };

            return View("TodoItemForm", new TodoItemFormViewModel(todoItem));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return View("TodoItemForm", new TodoItemFormViewModel(item));
            }

            if (item.Id == 0)
            {
                _context.TodoItems.Add(item);
            }
            else
            {
                var itemFromDb =
                    _context.TodoItems.SingleOrDefault(i => i.Id == item.Id && i.ChecklistId == item.ChecklistId);

                if (itemFromDb == null)
                    return HttpNotFound();

                itemFromDb.Title = item.Title;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { Id = item.ChecklistId });
        }

        [Route("checklists/{checklistId}/items/edit/{id}")]
        public ActionResult Edit(int checklistId, int id)
        {
            var item = _context.TodoItems
                .SingleOrDefault(i => i.Id == id && i.ChecklistId == checklistId);

            if (item == null)
                return HttpNotFound();

            return View("TodoItemForm", new TodoItemFormViewModel(item));
        }
    }
}