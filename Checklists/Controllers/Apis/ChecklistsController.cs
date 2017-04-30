using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Checklists.Models;
using Checklists.Repositories;
using Microsoft.AspNet.Identity;

namespace Checklists.Controllers.Apis
{
    [Authorize]
    public class ChecklistsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly IChecklistRepository _checklistRepository;

        public ChecklistsController()
        {
            _context = new ApplicationDbContext();
            _checklistRepository = new ChecklistRepository(_context);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var checklist = _checklistRepository.GetChecklistById(id);

            if (checklist == null || checklist.IsDeleted)
                return NotFound();

            if (checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            checklist.Delete();
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
