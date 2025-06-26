using employee_management_api.Models;
using employee_management_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<EmployeeModel> _repo;

        public EmployeeController(IRepository<EmployeeModel> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _repo.GetByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employee)
        {
            var created = await _repo.AddAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeModel employee)
        {
            if (id != employee.Id) return BadRequest();
            var updated = await _repo.UpdateAsync(employee);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("department/{name}")]
        public async Task<IActionResult> GetByDepartment(string name)
        {
            var employees = await _repo.FindAsync(e => e.Position == name);
            return Ok(employees);
        }

        [HttpGet("high-earners/{minSalary}")]
        public async Task<IActionResult> GetHighEarners(decimal minSalary)
        {
            var employees = await _repo.FindAsync(e => e.Salary >= minSalary);
            return Ok(employees);
        }
    }
}

