using System.Collections.Generic;
using Logistecsa.Domain.Entities;
using Logistecsa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logistecsa.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepository<Client> _dataRepository;

        public ClientController(IRepository<Client> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Client
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Client> clients = _dataRepository.GetAll();
            return Ok(clients);
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Client client = _dataRepository.Get(id);

            if (client == null)
            {
                return NotFound("The Client record couldn't be found.");
            }

            return Ok(client);
        }

        // POST: api/Client
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest("Client is null.");
            }

            _dataRepository.Add(client);
            return CreatedAtRoute(
                  "Get",
                  new { Id = client.Id },
                  client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest("Client is null.");
            }

            Client clientToUpdate = _dataRepository.Get(id);
            if (clientToUpdate == null)
            {
                return NotFound("The Client record couldn't be found.");
            }

            _dataRepository.Update(clientToUpdate, client);
            return NoContent();
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Client client = _dataRepository.Get(id);
            if (client == null)
            {
                return NotFound("The Client record couldn't be found.");
            }

            _dataRepository.Delete(client);
            return NoContent();
        }
    }
}
