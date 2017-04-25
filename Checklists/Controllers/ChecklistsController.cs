using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;

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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Checklists.Add(checklist);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}