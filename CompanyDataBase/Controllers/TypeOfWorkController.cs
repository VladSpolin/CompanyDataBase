using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfWorkController : ControllerBase
    {
        ApplicationContext db;
        public TypeOfWorkController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfWork>>> Get()
        {
            return await db.TypeOfWorks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TypeOfWork>>> Get(int id)
        {
            var type = await db.TypeOfWorks.FirstOrDefaultAsync(c => c.Id == id);
            if (type == null)
                return NotFound();
            return new ObjectResult(type);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> Post(TypeOfWork type)
        {
            if (type == null)
            {
                return BadRequest();
            }

            db.TypeOfWorks.Add(type);
            await db.SaveChangesAsync();
            return Ok(type);
        }

        [HttpPut]
        public async Task<ActionResult<TypeOfWork>> Put(TypeOfWork type)
        {
            if (type == null)
            {
                return BadRequest();
            }
            if (!db.TypeOfWorks.Any(x => x.Id == type.Id))
            {
                return NotFound();
            }

            db.Update(type);
            await db.SaveChangesAsync();
            return Ok(type);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeOfWork>> Delete(int id)
        {
            var type = db.TypeOfWorks.FirstOrDefault(x => x.Id == id);
            if (type == null)
            {
                return NotFound();
            }
            db.TypeOfWorks.Remove(type);
            await db.SaveChangesAsync();
            return Ok(type);
        }
    }
}
