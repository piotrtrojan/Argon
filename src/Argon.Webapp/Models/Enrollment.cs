using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Argon.Webapp.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Grade Grade { get; set; }

    }
}
