using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.Utils;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Argon.Webapp.QueryHandlers.Student
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, GetStudentByIdResponseDto>
    {
        private readonly string _connectionString;

        public GetStudentByIdQueryHandler(QueryConnectionStringWrapper connectionStringWrapper)
        {
            _connectionString = connectionStringWrapper.Value;
        }

        public GetStudentByIdResponseDto Handle(GetStudentByIdQuery query)
        {

            string sql = @"
                SELECT TOP 1 Id, Name, Surname
                FROM Students s
                WHERE s.Id = @StudentId
            ";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var students = sqlConnection.Query<GetStudentByIdResponseDto>(sql, new
                    {
                        query.StudentId
                    }).FirstOrDefault();
                return students;
            }
        }
    }
}