using MediatR;

namespace StudentProfile.Application.Events.Commnad.CreateEvent
{
    public class CreateEventCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
