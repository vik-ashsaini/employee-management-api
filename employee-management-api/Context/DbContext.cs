using employee_management_api.Models;
using EmployeeAdminAPIemployee_management_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace employee_management_api.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        //public DbSet<EmployeeModel> Employees { get; set; }
        ////public DbSet<UserModel> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<EmployeeModel>().HasData(
        //        new EmployeeModel { Id = 1, Name = "Alice Johnson", Position = "HR", Salary = 55000 },
        //        new EmployeeModel { Id = 2, Name = "Bob Smith", Position = "IT", Salary = 72000 },
        //        new EmployeeModel { Id = 3, Name = "Charlie Brown", Position = "Finance", Salary = 68000 },
        //        new EmployeeModel { Id = 4, Name = "Diana Prince", Position = "IT", Salary = 90000 }
        //    );
        //}
    }

}
