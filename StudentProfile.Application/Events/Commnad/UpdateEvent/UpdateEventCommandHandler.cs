using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Events.Commnad.UpdateEvent
{
    public class UpdateEventCommandHandler
        : IRequestHandler<UpdateEventCommnad, Unit>
    {

        private readonly IStudentProfileContext _dbContext;

        public UpdateEventCommandHandler(IStudentProfileContext dbContext)=>
            _dbContext= dbContext;                

        public async Task<Unit> Handle(UpdateEventCommnad request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Events.FirstOrDefaultAsync(entity => 
                entity.Id == request.Id, cancellationToken);

            if (entity == null || entity.CreatedTeacher.Id != request.TeacherId)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
