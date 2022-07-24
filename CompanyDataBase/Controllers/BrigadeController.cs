using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;


namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrigadeController : ControllerBase
    {
        ApplicationContext db;
        public BrigadeController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brigade>>> Get()
        {
            return await db.Brigades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Brigade>>> Get(int id)
        {
            var brigade = await db.Brigades.FirstOrDefaultAsync(c => c.Id == id);
            if (brigade == null)
                return NotFound();
            return new ObjectResult(brigade);
        }

        [HttpPost]
        public async Task<ActionResult<Brigade>> Post(Brigade brigade)
        {
            if (brigade == null)
            {
                return BadRequest();
            }

            db.Brigades.Add(brigade);
            await db.SaveChangesAsync();
            return Ok(brigade);
        }

        [HttpPut]
        public async Task<ActionResult<Brigade>> Put(Brigade brigade)
        {
            if (brigade == null)
            {
                return BadRequest();
            }
            if (!db.Brigades.Any(x => x.Id == brigade.Id))
            {
                return NotFound();
            }

            db.Update(brigade);
            await db.SaveChangesAsync();
            return Ok(brigade);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brigade>> Delete(int id)
        {
            var brigade = db.Brigades.FirstOrDefault(x => x.Id == id);
            if (brigade == null)
            {
                return NotFound();
            }
            db.Brigades.Remove(brigade);
            await db.SaveChangesAsync();
            return Ok(brigade);
        }
    }
}
