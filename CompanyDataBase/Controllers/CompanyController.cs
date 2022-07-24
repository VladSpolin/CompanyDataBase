using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ApplicationContext db;
        public CompanyController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return await db.Companies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Company>>> Get(int id)
        {
            var company = await db.Companies.FirstOrDefaultAsync(c=>c.Id == id);  
            if (company == null)
                return NotFound();
            return new ObjectResult(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> Post(Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            db.Companies.Add(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }

        [HttpPut]
        public async Task<ActionResult<Company>> Put(Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }
            if (!db.Companies.Any(x => x.Id == company.Id))
            {
                return NotFound();
            }

            db.Update(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(int id)
        {
            var company = db.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            db.Companies.Remove(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }
    }
}
