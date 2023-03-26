using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Commnad.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommnad, Unit>
    {

        private readonly IStudentProfileContext _dbContext;

        public DeleteEventCommandHandler(IStudentProfileContext dbContext) =>
            _dbContext = dbContext;                

        public async Task<Unit> Handle(DeleteEventCommnad request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Events.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null || entity.CreatedTeacher.Id == request.TeacherId) 
            {
                throw new NotFoundExeption(nameof(Event), request.Id);
            }

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
