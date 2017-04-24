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
    }
}