using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;
using StudentProfile.Application.Common.Exeptions;

namespace StudentProfile.Application.Events.Commnad.AddStudentsForEvent
{
    public class AttendTheEventCommandHandler 
        : IRequestHandler<AttendTheEventCommand>
    {
        private readonly IStudentProfileContext _dbContext;

        public AttendTheEventCommandHandler(IStudentProfileContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(AttendTheEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _dbContext.Events.Include(x => x.Skills).FirstOrDefaultAsync(@event => @event.Id == request.EventId);

            if (@event == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            var student = await _dbContext.Students.Include(events => events.Events).FirstOrDefaultAsync(student => student.Id == request.StudentId);

            if (student == null)
                throw new NotFoundException(nameof(Student), request.StudentId);

            if (@event.Skills != null)
            {
                student.Skills.AddRange(@event.Skills);
            }

            student.Events.Add(@event);
            await _dbContext.SaveChangesAsync(cancellationToken);            
        }
    }
}
