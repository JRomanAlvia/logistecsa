using System.Collections.Generic;
using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logistecsa.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> _dataRepository;

        public ProjectController(IRepository<Project> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Project
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Project> projects = _dataRepository.GetAll();
            return Ok(projects);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Project project = _dataRepository.Get(id);

            if (project == null)
            {
                return NotFound("The Project record couldn't be found.");
            }

            return Ok(project);
        }

        // POST: api/Project
        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Project is null.");
            }

            _dataRepository.Add(project);
            return CreatedAtRoute(
                  "Get",
                  new { Id = project.Id },
                  project);
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Project is null.");
            }

            Project projectToUpdate = _dataRepository.Get(id);
            if (projectToUpdate == null)
            {
                return NotFound("The Project record couldn't be found.");
            }

            _dataRepository.Update(projectToUpdate, project);
            return NoContent();
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Project project = _dataRepository.Get(id);
            if (project == null)
            {
                return NotFound("The Project record couldn't be found.");
            }

            _dataRepository.Delete(project);
            return NoContent();
        }
    }
}
