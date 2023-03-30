using MediatR;

namespace StudentProfile.Application.Events.Queries.GetDetailsFromEvent
{
    public class GetDetailsFromEventQuery : IRequest<EventDetailVm>
    {
        public int EventId { get; set; }
    }
}
