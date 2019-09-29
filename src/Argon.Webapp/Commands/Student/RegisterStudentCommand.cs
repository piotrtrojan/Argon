namespace Argon.Webapp.Commands.Student
{
    public class RegisterStudentCommand : ICommand
    {
        public string Name { get; }
        public string Surname { get; }

        public RegisterStudentCommand(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}