using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;

namespace Checklists.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: TodoItems
        [Route("checklists/{id}/items")]
        public ActionResult Index(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var todoItems = _context.TodoItems.Where(t => t.ChecklistId == id).ToList();
            return View(todoItems);
        }
    }
}