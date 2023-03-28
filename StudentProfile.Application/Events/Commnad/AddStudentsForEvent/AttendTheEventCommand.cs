using MediatR;

namespace StudentProfile.Application.Events.Commnad.AddStudentsForEvent
{
    public class AttendTheEventCommand : IRequest
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }
    }
}
