using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ApplicationContext db;
        public ClientController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await db.Clients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Client>>> Get(int id)
        {
            var client = await db.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (!db.Clients.Any(x => x.Id == client.Id))
            {
                return NotFound();
            }

            db.Update(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            var client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }
    }
}
