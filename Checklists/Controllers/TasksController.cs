using Checklists.Models;
using Checklists.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Checklists.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("checklists/{checklistId}/tasks")]
        public ActionResult Index(int? ChecklistId)
        {
            if (ChecklistId == null)
                return HttpNotFound();

            var checklist = _context.Checklists
                .Include(c => c.Tasks)
                .SingleOrDefault(c => c.Id == ChecklistId);

            if (checklist == null)
                return HttpNotFound();

            return View(checklist);
        }

        [Route("checklists/{checklistId}/tasks/new")]
        public ActionResult New(int? checklistId)
        {
            if (checklistId == null)
                return HttpNotFound();

            var isChecklistExists = _context.Checklists.Any(c => c.Id == checklistId);

            if (!isChecklistExists)
                return HttpNotFound();

            var task = new Task
            {
                ChecklistId = checklistId.Value
            };

            return View("TaskForm", new TaskFormViewModel(task));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Task task)
        {
            if (!ModelState.IsValid)
            {
                return View("TaskForm", new TaskFormViewModel(task));
            }

            if (task.Id == 0)
            {
                _context.Tasks.Add(task);
            }
            else
            {
                var taskFromDb =
                    _context.Tasks.SingleOrDefault(t => t.Id == task.Id && t.ChecklistId == task.ChecklistId);

                if (taskFromDb == null)
                    return HttpNotFound();

                taskFromDb.Title = task.Title;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { ChecklistId = task.ChecklistId });
        }

        [Route("checklists/{checklistId}/tasks/edit/{id}")]
        public ActionResult Edit(int checklistId, int id)
        {
            var item = _context.Tasks
                .SingleOrDefault(i => i.Id == id && i.ChecklistId == checklistId);

            if (item == null)
                return HttpNotFound();

            return View("TaskForm", new TaskFormViewModel(item));
        }
    }
}