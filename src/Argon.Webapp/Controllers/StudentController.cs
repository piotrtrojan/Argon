using Argon.Webapp.Commands.Student;
using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Argon.Webapp.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ArgonBaseController
    {
        private readonly Messages _messages;

        public StudentController(Messages messages)
        {
            _messages = messages;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var students = _messages.Dispatch(new GetStudentListQuery());
            return HandleQueryResult(students);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudent(int id)
        {
            var student = _messages.Dispatch(new GetStudentByIdQuery(id));
            if (student is null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult RegisterStudent(RegisterStudentDto dto)
        {
            var command = new RegisterStudentCommand(dto.Name, dto.Surname);
            var result = _messages.Dispatch(command);
            return HandleCommandResult(result);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudentPersonalInfo(int id, UpdateStudentInfoDto dto)
        {
            var command = new UpdateStudentInfoCommand(id, dto.Name, dto.Surname);
            var result = _messages.Dispatch(command);
            return HandleCommandResult(result);

        }

        [HttpDelete("{id:int}")]
        public IActionResult UnregisterStudent(int id)
        {
            var command = new UnregisterStudentCommand(id);
            var result = _messages.Dispatch(command);
            return HandleCommandResult(result);
        }
    }
}