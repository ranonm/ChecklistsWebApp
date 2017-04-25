using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;
using Checklists.ViewModels;

namespace Checklists.Controllers
{
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
            var checklists = _context.Checklists.ToList();

            return View(checklists);
        }

        public ActionResult Create()
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
                return View("ChecklistForm");
            }


            if (viewModel.Id == 0)
            {
                var checklist = new Checklist
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name
                };

                _context.Checklists.Add(checklist);
            }
            else
            {
                var checklist = _context.Checklists.Single(c => c.Id == viewModel.Id);
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