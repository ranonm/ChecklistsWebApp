using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;
using Checklists.Repositories;
using Checklists.ViewModels;
using Microsoft.AspNet.Identity;

namespace Checklists.Controllers
{
    [Authorize]
    public class ChecklistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IChecklistRepository _checklistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChecklistsController()
        {
            _context = new ApplicationDbContext();
            _checklistRepository = new ChecklistRepository(_context);
            _unitOfWork = new UnitOfWork(_context);
        }

        // GET: Checklists
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checklists = _checklistRepository.GetChecklistsCreatedByUser(userId);

            return View(checklists);
        }

        public ActionResult New()
        {
            var viewModel = new ChecklistFormViewModel();
            return View("ChecklistForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ChecklistFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ChecklistForm", viewModel);
            }


            if (viewModel.Id == 0)
            {
                var checklist = new Checklist
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    AuthorId = User.Identity.GetUserId()
                };

                _checklistRepository.Add(checklist);
            }
            else
            {
                var checklist = _checklistRepository.GetChecklist(viewModel.Id);

                if (checklist == null)
                    return HttpNotFound();

                checklist.Name = viewModel.Name;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var checklist = _checklistRepository.GetChecklist(id.Value);

            if (checklist == null)
                return HttpNotFound();

            if (checklist.AuthorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new ChecklistFormViewModel(checklist);

            return View("ChecklistForm", viewModel);
        }
    }
}