using Argon.Webapp.Attributes;
using Argon.Webapp.Commands.Student;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;

namespace Argon.Webapp.CommandHandlers.Student
{
    [CommandLogAtribute]
    public class UpdateStudentInfoCommanHandler : ICommandHandler<UpdateStudentInfoCommand>
    {
        private readonly StudentRepository _studentRepository;

        public UpdateStudentInfoCommanHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public CommandResult Handle(UpdateStudentInfoCommand command)
        {
            if (_studentRepository.GetStudent(command.StudentId) == null)
                return CommandResult.Fail($"Student {command.StudentId} does not exist.");
            var student = new Models.Student()
            {
                Name = command.Name,
                Surname = command.Surname
            };
            _studentRepository.Update(command.StudentId, student);
            return CommandResult.Ok();
        }
    }
}