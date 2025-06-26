using employee_management_api.Models;

namespace employee_management_api.Repositories
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        Task<IEnumerable<EmployeeModel>> FindByPositionAsync(string position);
        Task<IEnumerable<EmployeeModel>> GetHighEarnersAsync(decimal minSalary);
    }
}
