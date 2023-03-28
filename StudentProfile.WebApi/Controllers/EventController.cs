using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Events.Commnad.AddStudentsForEvent;
using StudentProfile.Application.Events.Commnad.CreateEvent;
using StudentProfile.Application.Events.Queries.GetEventList;
using StudentProfile.Application.Events.Queries.GetEvents;
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

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateEventDto eventDto)
        {
            var command = _mapper.Map<CreateEventCommand>(eventDto);
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }        
    }
}
