using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;
using StudentProfile.Application.Common.Exeptions;
using System.Security.Cryptography.X509Certificates;

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
            var entity = await _dbContext.Events.Include(x => x.Skills).FirstOrDefaultAsync(@event => @event.Id == request.EventId);

            if (entity == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            var student = await _dbContext.Students.Include(events => events.Events).Include(s => s.Skills).FirstOrDefaultAsync(student => student.Id == request.StudentId);

            if (student == null)
                throw new NotFoundException(nameof(Student), request.StudentId);

            if (entity.Skills != null)
            {
                student.Skills.AddRange(entity.Skills);
            }

            student.Events.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);            
        }
    }
}
