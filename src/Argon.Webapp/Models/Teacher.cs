using System.Collections.Generic;

namespace Argon.Webapp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}