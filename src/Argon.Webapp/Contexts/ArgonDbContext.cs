using Argon.Webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Argon.Webapp.Contexts
{
    public class ArgonDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Argon-2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
