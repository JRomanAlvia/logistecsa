using System.Collections.Generic;
using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logistecsa.Controllers
{
    [Route("api/tarea")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly IRepository<Tarea> _dataRepository;

        public TareaController(IRepository<Tarea> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Tarea
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Tarea> tareas = _dataRepository.GetAll();
            return Ok(tareas);
        }

        // GET: api/Tarea/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Tarea tarea = _dataRepository.Get(id);

            if (tarea == null)
            {
                return NotFound("The Tarea record couldn't be found.");
            }

            return Ok(tarea);
        }

        // POST: api/Tarea
        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("Tarea is null.");
            }

            _dataRepository.Add(tarea);
            return CreatedAtRoute(
                  "Get",
                  new { Id = tarea.Id },
                  tarea);
        }

        // PUT: api/Tarea/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("Tarea is null.");
            }

            Tarea tareaToUpdate = _dataRepository.Get(id);
            if (tareaToUpdate == null)
            {
                return NotFound("The Tarea record couldn't be found.");
            }

            _dataRepository.Update(tareaToUpdate, tarea);
            return NoContent();
        }

        // DELETE: api/Tarea/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Tarea tarea = _dataRepository.Get(id);
            if (tarea == null)
            {
                return NotFound("The Tarea record couldn't be found.");
            }

            _dataRepository.Delete(tarea);
            return NoContent();
        }
    }
}
