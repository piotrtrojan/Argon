using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.Repositories;
using AutoMapper;

namespace Argon.Webapp.QueryHandlers.Student
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentResponseDto>
    {
        private readonly StudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentResponseDto Handle(GetStudentByIdQuery query)
        {
            var student = _studentRepository.GetStudent(query.StudentId);
            return Mapper.Map<StudentResponseDto>(student);
        }
    }
}
