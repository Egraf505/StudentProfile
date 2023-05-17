using MediatR;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Queries.GetEventByStudentId
{
    public class GetEventByStudentIdCommand : IRequest<List<Event>>
    {
        public int studentId { get; set; }
    }
}
