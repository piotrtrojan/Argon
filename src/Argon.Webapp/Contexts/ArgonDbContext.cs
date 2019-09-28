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


    }
}
