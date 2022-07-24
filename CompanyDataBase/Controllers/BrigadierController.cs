using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;


namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrigadierController : ControllerBase
    {
        ApplicationContext db;
        public BrigadierController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brigadier>>> Get()
        {
            return await db.Brigadiers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Brigadier>>> Get(int id)
        {
            var brigadier = await db.Brigadiers.FirstOrDefaultAsync(c => c.Id == id);
            if (brigadier == null)
                return NotFound();
            return new ObjectResult(brigadier);
        }

        [HttpPost]
        public async Task<ActionResult<Brigadier>> Post(Brigadier brigadier)
        {
            if (brigadier == null)
            {
                return BadRequest();
            }

            db.Brigadiers.Add(brigadier);
            await db.SaveChangesAsync();
            return Ok(brigadier);
        }

        [HttpPut]
        public async Task<ActionResult<Brigadier>> Put(Brigadier brigadier)
        {
            if (brigadier == null)
            {
                return BadRequest();
            }
            if (!db.Brigadiers.Any(x => x.Id == brigadier.Id))
            {
                return NotFound();
            }

            db.Update(brigadier);
            await db.SaveChangesAsync();
            return Ok(brigadier);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brigadier>> Delete(int id)
        {
            var brigadier = db.Brigadiers.FirstOrDefault(x => x.Id == id);
            if (brigadier == null)
            {
                return NotFound();
            }
            db.Brigadiers.Remove(brigadier);
            await db.SaveChangesAsync();
            return Ok(brigadier);
        }
    }
}
