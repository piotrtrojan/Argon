namespace Argon.Webapp.Commands.Student
{
    public class UnregisterStudentCommand : ICommand
    {
        public int StudentId { get; set; }

        public UnregisterStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
    }
}