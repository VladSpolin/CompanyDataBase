using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialUseController : ControllerBase
    {
        ApplicationContext db;
        public MaterialUseController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialUse>>> Get()
        {
            return await db.MaterialUses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MaterialUse>>> Get(int id)
        {
            var material = await db.MaterialUses.FirstOrDefaultAsync(c => c.Id == id);
            if (material == null)
                return NotFound();
            return new ObjectResult(material);
        }

        [HttpPost]
        public async Task<ActionResult<MaterialUse>> Post(MaterialUse material)
        {
            if (material == null)
            {
                return BadRequest();
            }

            db.MaterialUses.Add(material);
            await db.SaveChangesAsync();
            return Ok(material);
        }

        [HttpPut]
        public async Task<ActionResult<MaterialUse>> Put(MaterialUse material)
        {
            if (material == null)
            {
                return BadRequest();
            }
            if (!db.MaterialUses.Any(x => x.Id == material.Id))
            {
                return NotFound();
            }

            db.Update(material);
            await db.SaveChangesAsync();
            return Ok(material);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialUse>> Delete(int id)
        {
            var material = db.MaterialUses.FirstOrDefault(x => x.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            db.MaterialUses.Remove(material);
            await db.SaveChangesAsync();
            return Ok(material);
        }
    }
}
