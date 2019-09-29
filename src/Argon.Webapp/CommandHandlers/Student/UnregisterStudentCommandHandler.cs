using Argon.Webapp.Attributes;
using Argon.Webapp.Commands.Student;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;

namespace Argon.Webapp.CommandHandlers.Student
{
    [CommandLogAtribute]
    public class UnregisterStudentCommandHandler : ICommandHandler<UnregisterStudentCommand>
    {
        private readonly StudentRepository _studentRepository;

        public UnregisterStudentCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public CommandResult Handle(UnregisterStudentCommand command)
        {
            if (_studentRepository.GetStudent(command.StudentId) == null)
                return CommandResult.Fail($"Student {command.StudentId} does not exist.");
            _studentRepository.UnregisterStudent(command.StudentId);
            return CommandResult.Ok();
        }
    }
}