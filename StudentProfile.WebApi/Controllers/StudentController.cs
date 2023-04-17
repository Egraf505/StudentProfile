using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Events.Commnad.AddStudentsForEvent;
using StudentProfile.Application.Events.Commnad.RemoveStudentsForEvent;
using StudentProfile.Application.Events.Queries.GetStudentFromEvent;
using StudentProfile.Application.Student.Queries.GetStudentById;
using StudentProfile.WebApi.Models;

namespace StudentProfile.WebApi.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentVm>> GetById(int studentId)
        {
            var query = new GetStudentByIdCommand() { studentId = studentId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<StudentListVm>> GetAll(int eventId)
        {
            var query = new GetStudentListQuery() { EventId = eventId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AttendForEvent(RequestForEventDto attendForEventDto)
        {
            var command = new AttendTheEventCommand() { EventId = attendForEventDto.EventId, StudentId = attendForEventDto.StudentId };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveForEvent(RequestForEventDto attendForEventDto)
        {
            var command = new RemoveStudentForEventCommand() { EventId = attendForEventDto.EventId, StudentId = attendForEventDto.StudentId };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
