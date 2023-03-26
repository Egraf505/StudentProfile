
namespace StudentProfile.Application.Events.Queries.GetEventList
{
    public class EventListVm
    {
        public IList<EventLookupDto> Events { get; set; } = null!;
    }
}
