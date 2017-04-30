using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class TasksController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly ITaskRepository _taskRepository;

        public TasksController()
        {
            _context = new ApplicationDbContext();
            _taskRepository = new TaskRepository(_context);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var task = _taskRepository.GetTaskWithChecklist(id);

            if (task == null)
                return NotFound();

            if (task.Checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            task.Delete();

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/tasks/{id}/check")]
        public IHttpActionResult Check(int? id)
        {
            if (id == null)
                return BadRequest("Requires an id for the to-do item");

            var task = _taskRepository.GetTaskWithChecklist(id.Value);

            if (task == null)
                return NotFound();

            if (task.Checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            if (task.IsDeleted)
                return BadRequest("Cannot check a deleted item");

            task.Check();

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("api/tasks/{id}/check")]
        public IHttpActionResult Uncheck(int? id)
        {
            if (id == null)
                return BadRequest("Requires an id for the to-do item");

            var task = _taskRepository.GetTaskWithChecklist(id.Value);

            if (task == null)
                return NotFound();

            if (task.Checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            if (task.IsDeleted)
                return BadRequest("Cannot uncheck a deleted item");

            task.Uncheck();

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
