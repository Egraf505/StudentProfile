using MediatR;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Queries.GetEventByTeacherId
{
    public class GetEventByTeacherIdCommand : IRequest<List<Event>>
    {
        public int teacherId { get; set; }
    }
}
