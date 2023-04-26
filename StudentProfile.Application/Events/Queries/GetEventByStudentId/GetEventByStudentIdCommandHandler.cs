using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Queries.GetEventByStudentId
{
    public class GetEventByStudentIdCommandHandler : IRequestHandler<GetEventByStudentIdCommand, List<Event>>
    {
        private readonly IStudentProfileContext _context;

        public GetEventByStudentIdCommandHandler(IStudentProfileContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> Handle(GetEventByStudentIdCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.id == request.studentId, cancellationToken);

            if (student == null)
            {
                throw new NotFoundException(nameof(Student), request.studentId);
            }

            var events = await _context.Events.Where(x => x.Students.Contains(student)).ToListAsync(cancellationToken);

            return events;
        }
    }
}
