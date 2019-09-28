using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Argon.Webapp.QueryHandlers.Student
{
    public class GetStudentListQueryHandler : IQueryHandler<GetStudentListQuery, ICollection<StudentResponseDto>>
    {
        private readonly StudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(StudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public ICollection<StudentResponseDto> Handle(GetStudentListQuery query)
        {
            var students = _studentRepository.GetStudents(query.EnrollmentId);
            return _mapper.Map<List<StudentResponseDto>>(students);
        }
    }
}
