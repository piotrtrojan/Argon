using Argon.Webapp.Contexts;
using Argon.Webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Argon.Webapp.Repositories
{
    public class StudentRepository
    {
        public Student GetStudent(int id)
        {
            using (var ctx = new ArgonDbContext())
            {
                return ctx.Students.FirstOrDefault(q => q.Id == id);
            }
        }

        public void Update(int id, Student student)
        {
            using (var ctx = new ArgonDbContext())
            {
                var entity = ctx.Students.FirstOrDefault(q => q.Id == id);
                if (entity == null)
                    throw new ArgumentException($"Student {id} does not exist.");
                entity = student;
                ctx.Students.Update(entity);
                ctx.SaveChanges();
            }
        }

        public void RegisterStudent(Student student)
        {
            using (var ctx = new ArgonDbContext())
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }

        public ICollection<Student> GetStudents()
        {
            using (var ctx = new ArgonDbContext())
            {
                var queryable = ctx.Students.AsQueryable();
                return queryable.ToList();
            }
        }
    }
}
