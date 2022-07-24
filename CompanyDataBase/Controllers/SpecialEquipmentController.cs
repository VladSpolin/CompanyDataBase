using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialEquipmentController : ControllerBase
    {
        ApplicationContext db;
        public SpecialEquipmentController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialEquipment>>> Get()
        {
            return await db.SpecialEquipments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SpecialEquipment>>> Get(int id)
        {
            var equipment = await db.SpecialEquipments.FirstOrDefaultAsync(c => c.Id == id);
            if (equipment == null)
                return NotFound();
            return new ObjectResult(equipment);
        }

        [HttpPost]
        public async Task<ActionResult<SpecialEquipment>> Post(SpecialEquipment equipment)
        {
            if (equipment == null)
            {
                return BadRequest();
            }

            db.SpecialEquipments.Add(equipment);
            await db.SaveChangesAsync();
            return Ok(equipment);
        }

        [HttpPut]
        public async Task<ActionResult<SpecialEquipment>> Put(SpecialEquipment equipment)
        {
            if (equipment == null)
            {
                return BadRequest();
            }
            if (!db.SpecialEquipments.Any(x => x.Id == equipment.Id))
            {
                return NotFound();
            }

            db.Update(equipment);
            await db.SaveChangesAsync();
            return Ok(equipment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialEquipment>> Delete(int id)
        {
            var equipment = db.SpecialEquipments.FirstOrDefault(x => x.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }
            db.SpecialEquipments.Remove(equipment);
            await db.SaveChangesAsync();
            return Ok(equipment);
        }
    }
}
