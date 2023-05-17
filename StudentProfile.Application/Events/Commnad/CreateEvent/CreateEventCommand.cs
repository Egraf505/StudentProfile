using MediatR;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Commnad.CreateEvent
{
    public class CreateEventCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public List<Skill>? Skills { get; set; }
    }
}
