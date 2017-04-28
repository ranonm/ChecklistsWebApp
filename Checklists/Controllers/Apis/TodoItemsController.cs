using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Checklists.Models;
using Microsoft.AspNet.Identity;

namespace Checklists.Controllers.Apis
{
    [Authorize]
    public class TodoItemsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public TodoItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var item = _context.TodoItems
                .Include(i => i.Checklist)
                .SingleOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            if (item.Checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            item.Delete();

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/todoitems/{id}/check")]
        public IHttpActionResult Check(int? id)
        {
            if (id == null)
                return BadRequest("Requires an id for the to-do item");

            var todoItem = _context.TodoItems.Include(i => i.Checklist).SingleOrDefault(i => i.Id == id);

            if (todoItem == null)
                return NotFound();

            if (todoItem.Checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            todoItem.Check();

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("api/todoitems/{id}/check")]
        public IHttpActionResult Uncheck(int? id)
        {
            if (id == null)
                return BadRequest("Requires an id for the to-do item");

            var todoItem = _context.TodoItems.Include(i => i.Checklist).SingleOrDefault(i => i.Id == id);

            if (todoItem == null)
                return NotFound();

            if (todoItem.Checklist.AuthorId != User.Identity.GetUserId())
                return Unauthorized();

            todoItem.Uncheck();

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
