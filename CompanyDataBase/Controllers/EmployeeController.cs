using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;
using Microsoft.EntityFrameworkCore;


namespace CompanyDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationContext db;
        public EmployeeController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await db.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get(int id)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            if (!db.Employees.Any(x => x.Id == employee.Id))
            {
                return NotFound();
            }

            db.Update(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
