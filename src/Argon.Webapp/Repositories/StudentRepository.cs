using Argon.Webapp.Contexts;
using Argon.Webapp.Models;
using Argon.Webapp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Argon.Webapp.Repositories
{
    public class StudentRepository
    {
        private readonly CommandConnectionStringWrapper _connectionStringWrapper;

        public StudentRepository(CommandConnectionStringWrapper connectionStringWrapper)
        {
            _connectionStringWrapper = connectionStringWrapper;
        }
        public Student GetStudent(int id)
        {
            using (var ctx = new ArgonDbContext(_connectionStringWrapper))
            {
                return ctx.Students.FirstOrDefault(q => q.Id == id);
            }
        }

        public void Update(int id, Student student)
        {
            using (var ctx = new ArgonDbContext(_connectionStringWrapper))
            {
                var entity = ctx.Students.FirstOrDefault(q => q.Id == id);
                if (entity == null)
                    throw new ArgumentException($"Student {id} does not exist.");
                entity.Name = student.Name;
                entity.Surname = student.Surname;
                ctx.Students.Update(entity);
                ctx.SaveChanges();
            }
        }

        public void UnregisterStudent(int id)
        {
            using (var ctx = new ArgonDbContext(_connectionStringWrapper))
            {
                var student = GetStudent(id);
                if (student == null)
                    throw new ArgumentException($"Student {id} does not exist.");
                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
        }

        public void RegisterStudent(Student student)
        {
            using (var ctx = new ArgonDbContext(_connectionStringWrapper))
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }

        public ICollection<Student> GetStudents()
        {
            using (var ctx = new ArgonDbContext(_connectionStringWrapper))
            {
                var queryable = ctx.Students.AsQueryable();
                return queryable.ToList();
            }
        }
    }
}