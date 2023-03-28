using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Events.Commnad.AddStudentsForEvent;
using StudentProfile.Application.Events.Queries.GetStudentFromEvent;
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


        [HttpGet("{eventId}")]
        public async Task<ActionResult<StudentListVm>> GetAll(int eventId)
        {
            var query = new GetStudentListQuery() { EventId = eventId };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AttendForEvent(AttendForEventDto attendForEventDto)
        {
            var command = _mapper.Map<AttendTheEventCommand>(attendForEventDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
