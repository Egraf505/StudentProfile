using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Events.Commnad.AddStudentsForEvent;
using StudentProfile.Application.Events.Commnad.CreateEvent;
using StudentProfile.Application.Events.Queries.GetDetailsFromEvent;
using StudentProfile.Application.Events.Queries.GetEventByStudentId;
using StudentProfile.Application.Events.Queries.GetEventByTeacherId;
using StudentProfile.Application.Events.Queries.GetEventList;
using StudentProfile.Application.Events.Queries.GetEvents;
using StudentProfile.Domain;
using StudentProfile.WebApi.Models;

namespace StudentProfile.WebApi.Controllers
{
    public class EventController : BaseController
    {
        private readonly IMapper _mapper;

        public EventController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EventListVm>> GetAll()
        {
            var query = new GetEventListQuery();                        

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("eventId")]
        public async Task<ActionResult<EventDetailVm>> GetDetails(int eventId)
        {
            var query = new GetDetailsFromEventQuery() { EventId = eventId };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateEventDto eventDto)
        {
            var command = _mapper.Map<CreateEventCommand>(eventDto);
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }


        /// <summary>
        /// Получение мероприятий по id преподователя
        /// </summary>
        /// <param name="teadcherId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEventByTeacher(int teadcherId)
        {
            var query = new GetEventByTeacherIdCommand() { teacherId = teadcherId };
            var events = await Mediator.Send(query);
            return Ok(events);
        }

        /// <summary>
        /// Получение мероприятий по id студента
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEventByStudent(int studentId)
        {
            var query = new GetEventByStudentIdCommand() { studentId = studentId };
            var events = await Mediator.Send(query);
            return Ok(events);
        }
    }
}
