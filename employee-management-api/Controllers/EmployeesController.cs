
using EmployeeAdminAPIemployee_management_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<EmployeeModel> employees = new List<EmployeeModel>
        {
            new EmployeeModel { Id = 1, Name = "Alice Smith", Position = "Developer", Salary = 75000 },
            new EmployeeModel { Id = 2, Name = "Bob Johnson", Position = "Manager", Salary = 90000 },
            new EmployeeModel { Id = 3, Name = "Carol Williams", Position = "Designer", Salary = 68000 }
        };

        [HttpGet]
        public IActionResult GetAll() => Ok(employees);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeModel updated)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            emp.Name = updated.Name;
            emp.Position = updated.Position;
            emp.Salary = updated.Salary;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            employees.Remove(emp);
            return NoContent();
        }
    }
}

