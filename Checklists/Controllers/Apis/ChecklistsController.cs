using System.Net;
using System.Web.Http;
using Checklists.Core;
using Microsoft.AspNet.Identity;

namespace Checklists.Controllers.Apis
{
    [Authorize]
    public class ChecklistsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChecklistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var checklist = _unitOfWork.ChecklistRepository.GetChecklist(id);

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
