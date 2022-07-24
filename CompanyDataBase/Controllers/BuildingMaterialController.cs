using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingMaterialController : ControllerBase
    {
        ApplicationContext db;
        public BuildingMaterialController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingMaterial>>> Get()
        {
            return await db.BuildingMaterials.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BuildingMaterial>>> Get(int id)
        {
            var material = await db.BuildingMaterials.FirstOrDefaultAsync(c => c.Id == id);
            if (material == null)
                return NotFound();
            return new ObjectResult(material);
        }

        [HttpPost]
        public async Task<ActionResult<BuildingMaterial>> Post(BuildingMaterial material)
        {
            if (material == null)
            {
                return BadRequest();
            }

            db.BuildingMaterials.Add(material);
            await db.SaveChangesAsync();
            return Ok(material);
        }

        [HttpPut]
        public async Task<ActionResult<BuildingMaterial>> Put(BuildingMaterial material)
        {
            if (material == null)
            {
                return BadRequest();
            }
            if (!db.BuildingMaterials.Any(x => x.Id == material.Id))
            {
                return NotFound();
            }

            db.Update(material);
            await db.SaveChangesAsync();
            return Ok(material);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BuildingMaterial>> Delete(int id)
        {
            var material = db.BuildingMaterials.FirstOrDefault(x => x.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            db.BuildingMaterials.Remove(material);
            await db.SaveChangesAsync();
            return Ok(material);
        }
    }
}
