using System.Net;
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
        private readonly IUnitOfWork _unitOfWork;

        public ChecklistsController()
        {
            _context = new ApplicationDbContext();
            _checklistRepository = new ChecklistRepository(_context);
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var checklist = _checklistRepository.GetChecklist(id);

            if (checklist == null || checklist.IsDeleted)
                return NotFound();

            if (checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            checklist.Delete();
            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
