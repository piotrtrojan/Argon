using Argon.Webapp.Models;
using Argon.Webapp.Utils;
using Microsoft.EntityFrameworkCore;

namespace Argon.Webapp.Contexts
{
    public class ArgonDbContext : DbContext
    {
        private readonly string _connectionString;

        public ArgonDbContext(ConnectionStringWrapper connectionStringWrapper)
        {
            _connectionString = connectionStringWrapper.Value;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}