using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Queries.GetDetailsFromEvent
{
    public class GetDetailsFromEventQueryHandler : IRequestHandler<GetDetailsFromEventQuery, EventDetailVm>
    {
        private readonly IStudentProfileContext _dbContext;
        private readonly IMapper _mapper;

        public GetDetailsFromEventQueryHandler(IStudentProfileContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<EventDetailVm> Handle(GetDetailsFromEventQuery request, CancellationToken cancellationToken)
        {
            var @event = await _dbContext.Events.FirstOrDefaultAsync(@event => @event.Id == request.EventId, cancellationToken);

            if (@event == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }             

            return _mapper.Map<EventDetailVm>(@event);
        }
    }
}
