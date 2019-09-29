using Argon.Webapp.Attributes;
using Argon.Webapp.Commands.Student;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;

namespace Argon.Webapp.CommandHandlers.Student
{
    [CommandLogAtribute]
    public class RegisterStudentCommandHandler : ICommandHandler<RegisterStudentCommand>
    {
        private readonly StudentRepository _studentRepository;

        public RegisterStudentCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public CommandResult Handle(RegisterStudentCommand command)
        {
            var student = new Models.Student
            {
                Name = command.Name,
                Surname = command.Surname
            };
            _studentRepository.RegisterStudent(student);
            return CommandResult.Ok();
        }
    }
}