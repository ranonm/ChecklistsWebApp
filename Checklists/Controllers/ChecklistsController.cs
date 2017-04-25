using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;
using Checklists.ViewModels;
using Microsoft.AspNet.Identity;

namespace Checklists.Controllers
{
    [Authorize]
    public class ChecklistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChecklistsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Checklists
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checklists = _context.Checklists
                .Where(c => c.AuthorId == userId)
                .ToList();

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

                _context.Checklists.Add(checklist);
            }
            else
            {
                var checklist = _context.Checklists.SingleOrDefault(c => c.Id == viewModel.Id);

                if (checklist == null)
                    return HttpNotFound();

                checklist.Name = viewModel.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var checklist = _context.Checklists.SingleOrDefault(c => c.Id == id);

            if (checklist == null)
                return HttpNotFound();

            var viewModel = new ChecklistFormViewModel(checklist);

            return View("ChecklistForm", viewModel);
        }
    }
}