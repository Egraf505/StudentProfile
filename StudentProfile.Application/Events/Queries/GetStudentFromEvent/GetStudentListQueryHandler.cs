using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Interfaces;

namespace StudentProfile.Application.Events.Queries.GetStudentFromEvent
{
    public class GetStudentListQueryHandler 
        : IRequestHandler<GetStudentListQuery, StudentListVm>
    {
        private readonly IStudentProfileContext _dbContext;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(IStudentProfileContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<StudentListVm> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = 
                await _dbContext.Students
                .Where(@event => @event.Id == request.EventId)
                .ProjectTo<StudentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new StudentListVm() { Students = students };
        }
    }
}
