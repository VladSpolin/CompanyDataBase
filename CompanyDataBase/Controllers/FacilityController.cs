using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        ApplicationContext db;
        public FacilityController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> Get()
        {
            return await db.Facilities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Facility>>> Get(int id)
        {
            var facility = await db.Facilities.FirstOrDefaultAsync(c => c.Id == id);
            if (facility == null)
                return NotFound();
            return new ObjectResult(facility);
        }

        [HttpPost]
        public async Task<ActionResult<Facility>> Post(Facility facility)
        {
            if (facility == null)
            {
                return BadRequest();
            }

            db.Facilities.Add(facility);
            await db.SaveChangesAsync();
            return Ok(facility);
        }

        [HttpPut]
        public async Task<ActionResult<Facility>> Put(Facility facility)
        {
            if (facility == null)
            {
                return BadRequest();
            }
            if (!db.Facilities.Any(x => x.Id == facility.Id))
            {
                return NotFound();
            }

            db.Update(facility);
            await db.SaveChangesAsync();
            return Ok(facility);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Facility>> Delete(int id)
        {
            var facility = db.Facilities.FirstOrDefault(x => x.Id == id);
            if (facility == null)
            {
                return NotFound();
            }
            db.Facilities.Remove(facility);
            await db.SaveChangesAsync();
            return Ok(facility);
        }
    }
}
