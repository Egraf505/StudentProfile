using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Events.Queries.GetEvents;
using StudentProfile.Application.Interfaces;

namespace StudentProfile.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler
        : IRequestHandler<GetEventListQuery, EventListVm>
    {
        private readonly IStudentProfileContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IStudentProfileContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventListVm> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var eventQuery =
                 await _dbContext.Events
                 .Include(t => t.CreatedTeacher)
                 .Include(s => s.Skills)
                 .ProjectTo<EventLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

            return new EventListVm { Events = eventQuery };
        }
    }
}
