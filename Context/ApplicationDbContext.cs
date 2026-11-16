using CustomerMangementApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerMangementApi.Context
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
    }
}
