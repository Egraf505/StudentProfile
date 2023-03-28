using MediatR;
using StudentProfile.Application.Events.Queries.GetEventList;

namespace StudentProfile.Application.Events.Queries.GetEvents
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
    }
}
