using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Commnad.CreateEvent
{

    public class CreateEventCommandHandler 
        : IRequestHandler<CreateEventCommand, int>
    {

        private readonly IStudentProfileContext _dbContext;

        public CreateEventCommandHandler(IStudentProfileContext dbContext)=>
            _dbContext = dbContext;               

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {

            Teacher teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.Id == request.TeacherId)!;

            if (teacher == null)
                throw new NotFoundExeption(nameof(Teacher), request.TeacherId);

            Event eventNew = new Event()
            {
                CreatedTeacher = teacher,
                Title = request.Title,
                Description = request.Description
            };

            await _dbContext.Events.AddAsync(eventNew);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return eventNew.Id; 
        }
    }
}
