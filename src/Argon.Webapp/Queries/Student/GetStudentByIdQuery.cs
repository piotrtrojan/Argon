using Argon.Webapp.Dtos.Student;

namespace Argon.Webapp.Queries.Student
{
    public class GetStudentByIdQuery : IQuery<StudentResponseDto>
    {
        public int StudentId { get; }

        public GetStudentByIdQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}