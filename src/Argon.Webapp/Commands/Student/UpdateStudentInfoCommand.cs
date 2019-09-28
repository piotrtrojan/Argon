namespace Argon.Webapp.Commands.Student
{
    public class UpdateStudentInfoCommand : ICommand
    {
        public int StudentId { get; }
        public string Name { get; }
        public string Surname { get; }

        public UpdateStudentInfoCommand(int studentId, string name, string surname)
        {
            StudentId = studentId;
            Name = name;
            Surname = surname;
        }
    }
}
