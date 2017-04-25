using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Checklists.Models;

namespace Checklists.Controllers.Apis
{
    public class ChecklistsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ChecklistsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var checklist = _context.Checklists.SingleOrDefault(c => c.Id == id);

            if (checklist == null || checklist.IsDeleted)
                return NotFound();

            checklist.Delete();
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
