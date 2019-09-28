using Argon.Webapp.Commands.Student;
using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

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
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult RegisterStudent(RegisterStudentDto dto)
        {
            var command = new RegisterStudentCommand(dto.Name, dto.Surname);
            var result = _messages.Dispatch(command);
            return result.IsSuccess ? Ok() : Error(result.Error);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateStudentPersonalInfo(int studentId, UpdateStudentInfoDto dto)
        {
            var command = new UpdateStudentInfoCommand(studentId, dto.Surname, dto.Name);
            var result = _messages.Dispatch(command);
            return result.IsSuccess ? Ok() : Error(result.Error);

        }

        [HttpDelete]
        public IActionResult UnregisterStudent()
        {
            throw new NotImplementedException();
        }
    }
}