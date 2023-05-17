using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Interfaces;

namespace StudentProfile.Application.Skills.Queries.GetSkillList
{
    public class GetSkillListQueryHandler
        : IRequestHandler<GetSkillListQuery, SkillListVm>
    {
        private readonly IStudentProfileContext _dbContext;
        private readonly IMapper _mapper;

        public GetSkillListQueryHandler(IStudentProfileContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SkillListVm> Handle(GetSkillListQuery request, CancellationToken cancellationToken)
        {
            var skills = 
                await _dbContext.Skills
                .ProjectTo<SkillLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new SkillListVm() { Skills = skills};
        }
    }
}
