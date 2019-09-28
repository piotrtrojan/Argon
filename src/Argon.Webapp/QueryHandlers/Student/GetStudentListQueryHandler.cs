using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Argon.Webapp.QueryHandlers.Student
{
    public class GetStudentListQueryHandler : IQueryHandler<GetStudentListQuery, ICollection<StudentResponseDto>>
    {
        private readonly StudentRepository _studentRepository;

        public GetStudentListQueryHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ICollection<StudentResponseDto> Handle(GetStudentListQuery query)
        {
            var students = _studentRepository.GetStudents(query.EnrollmentId);
            return Mapper
        }
    }
}
