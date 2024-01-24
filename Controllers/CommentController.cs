using System.Collections.Generic;
using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logistecsa.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IRepository<Comment> _dataRepository;

        public CommentController(IRepository<Comment> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Comment
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Comment> comments = _dataRepository.GetAll();
            return Ok(comments);
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Comment comment = _dataRepository.Get(id);

            if (comment == null)
            {
                return NotFound("The Comment record couldn't be found.");
            }

            return Ok(comment);
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest("Comment is null.");
            }

            _dataRepository.Add(comment);
            return CreatedAtRoute(
                  "Get",
                  new { Id = comment.Id },
                  comment);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest("Comment is null.");
            }

            Comment commentToUpdate = _dataRepository.Get(id);
            if (commentToUpdate == null)
            {
                return NotFound("The Comment record couldn't be found.");
            }

            _dataRepository.Update(commentToUpdate, comment);
            return NoContent();
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Comment comment = _dataRepository.Get(id);
            if (comment == null)
            {
                return NotFound("The Comment record couldn't be found.");
            }

            _dataRepository.Delete(comment);
            return NoContent();
        }
    }
}
