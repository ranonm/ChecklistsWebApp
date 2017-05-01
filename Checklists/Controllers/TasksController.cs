using Checklists.Models;
using Checklists.ViewModels;
using System.Web.Mvc;
using Checklists.Repositories;
using Microsoft.AspNet.Identity;

namespace Checklists.Controllers
{
    public class TasksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [Route("checklists/{checklistId}/tasks")]
        public ActionResult Index(int? checklistId)
        {
            if (checklistId == null)
                return HttpNotFound();

            var checklist = _unitOfWork.ChecklistRepository.GetChecklist(checklistId.Value);

            if (checklist == null)
                return HttpNotFound();

            if (checklist.AuthorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var tasks = _unitOfWork.TaskRepository.GetTasksFromChecklist(checklistId.Value);

            return View(new TaskListingViewModel(checklist, tasks));
        }

        [Route("checklists/{checklistId}/tasks/new")]
        public ActionResult New(int? checklistId)
        {
            if (checklistId == null)
                return HttpNotFound();


            var checklist = _unitOfWork.ChecklistRepository.GetChecklist(checklistId.Value);

            if (checklist == null)
                return HttpNotFound();

            if (checklist.AuthorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

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
                _unitOfWork.TaskRepository.Add(task);
            }
            else
            {
                var taskFromDb = _unitOfWork.TaskRepository.GetTaskFromChecklist(task.ChecklistId, task.Id);

                if (taskFromDb == null)
                    return HttpNotFound();

                taskFromDb.Title = task.Title;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", new { ChecklistId = task.ChecklistId });
        }

        [Route("checklists/{checklistId}/tasks/edit/{id}")]
        public ActionResult Edit(int checklistId, int id)
        {
            var task = _unitOfWork.TaskRepository.GetTaskFromChecklist(checklistId, id);

            if (task == null)
                return HttpNotFound();

            if (task.Checklist.AuthorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            return View("TaskForm", new TaskFormViewModel(task));
        }
    }
}