using employee_management_api.Context;
using employee_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_api.Repositories
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeModel>> FindByPositionAsync(string position)
        {
            return await _context.Employees
                .Where(e => e.Position == position)
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeModel>> GetHighEarnersAsync(decimal minSalary)
        {
            return await _context.Employees
                .Where(e => e.Salary >= minSalary)
                .ToListAsync();
        }
    }
}
