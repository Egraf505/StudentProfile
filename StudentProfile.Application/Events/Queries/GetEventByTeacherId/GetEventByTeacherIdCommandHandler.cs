using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Queries.GetEventByTeacherId
{
    public class GetEventByTeacherIdCommandHandler : IRequestHandler<GetEventByTeacherIdCommand, List<Event>>
    {

        private readonly IStudentProfileContext _context;

        public GetEventByTeacherIdCommandHandler(IStudentProfileContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> Handle(GetEventByTeacherIdCommand request, CancellationToken cancellationToken)
        {
            var events = await _context.Events.Where(x => x.CreatedTeacher.Id == request.teacherId).ToListAsync();

            if (events == null || events.Count() == 0)
            {
                throw new NotFoundException(nameof(Teacher), request.teacherId);
            }

            return events;
        }
    }
}
