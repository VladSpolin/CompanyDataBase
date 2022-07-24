using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;


namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderController : ControllerBase
    {
        ApplicationContext db;
        public BuilderController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Builder>>> Get()
        {
            return await db.Builders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Builder>>> Get(int id)
        {
            var builder = await db.Builders.FirstOrDefaultAsync(c => c.Id == id);
            if (builder == null)
                return NotFound();
            return new ObjectResult(builder);
        }

        [HttpPost]
        public async Task<ActionResult<Builder>> Post(Builder builder)
        {
            if (builder == null)
            {
                return BadRequest();
            }

            db.Builders.Add(builder);
            await db.SaveChangesAsync();
            return Ok(builder);
        }

        [HttpPut]
        public async Task<ActionResult<Builder>> Put(Builder builder)
        {
            if (builder == null)
            {
                return BadRequest();
            }
            if (!db.Builders.Any(x => x.Id == builder.Id))
            {
                return NotFound();
            }

            db.Update(builder);
            await db.SaveChangesAsync();
            return Ok(builder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Builder>> Delete(int id)
        {
            var builder = db.Builders.FirstOrDefault(x => x.Id == id);
            if (builder == null)
            {
                return NotFound();
            }
            db.Employees.Remove(builder);
            await db.SaveChangesAsync();
            return Ok(builder);
        }
    }
}
