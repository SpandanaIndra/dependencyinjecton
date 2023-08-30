using Microsoft.EntityFrameworkCore;

namespace DIDemo2.Models
{
    public class EmployDbContext:DbContext
    {
        public EmployDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
