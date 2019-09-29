using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;
using AutoMapper;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Argon.Webapp.QueryHandlers.Student
{
    public class GetStudentListQueryHandler : IQueryHandler<GetStudentListQuery, ICollection<GetStudentListResponseDto>>
    {
        private readonly string _connectionString;

        public GetStudentListQueryHandler(ConnectionStringWrapper connectionStringWrapper)
        {
            _connectionString = connectionStringWrapper.Value;
        }

        public ICollection<GetStudentListResponseDto> Handle(GetStudentListQuery query)
        {
            var sql = @"
                SELECT Id, Name, Surname
                FROM Students s
            ";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var students = sqlConnection.Query<GetStudentListResponseDto>(sql).ToList();
                return students;
            }
        }
    }
}