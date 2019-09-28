using Argon.Webapp.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Argon.Webapp.Queries.Student
{
    public class GetStudentListQuery : IQuery<ICollection<StudentResponseDto>>
    {
        public int EnrollmentId { get; }

        public GetStudentListQuery(int enrollmentId)
        {
            EnrollmentId = enrollmentId;
        }
    }
}
