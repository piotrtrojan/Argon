using System.Collections.Generic;

namespace Argon.Webapp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}