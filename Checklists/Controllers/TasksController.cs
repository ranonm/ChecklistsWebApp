using Checklists.Models;
using Checklists.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Checklists.Repositories;

namespace Checklists.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IChecklistRepository _checklistRepository;
        private readonly ITaskRepository _taskRepository;

        public TasksController()
        {
            _context = new ApplicationDbContext();
            _checklistRepository = new ChecklistRepository(_context);
            _taskRepository = new TaskRepository(_context);
        }

        [Route("checklists/{checklistId}/tasks")]
        public ActionResult Index(int? checklistId)
        {
            if (checklistId == null)
                return HttpNotFound();

            var checklist = _checklistRepository.GetChecklistWithTasks(checklistId.Value);

            if (checklist == null)
                return HttpNotFound();

            return View(checklist);
        }

        [Route("checklists/{checklistId}/tasks/new")]
        public ActionResult New(int? checklistId)
        {
            if (checklistId == null)
                return HttpNotFound();

            if (_checklistRepository.GetChecklist(checklistId.Value) == null)
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
                _taskRepository.Add(task);
            }
            else
            {
                var taskFromDb = _taskRepository.GetTaskFromChecklist(task.ChecklistId, task.Id);

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
            var task = _taskRepository.GetTaskFromChecklist(checklistId, id);

            if (task == null)
                return HttpNotFound();

            return View("TaskForm", new TaskFormViewModel(task));
        }
    }
}