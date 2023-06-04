using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;
using StudentProfile.Application.Skills.Queries.GetSkillList;
using System.Linq;

namespace StudentProfile.Application.Skills.Queries.GetSkillsFromStudentId
{
    internal class GetSkillsFromStudentIdQueryHandler
        : IRequestHandler<GetSkillsFromStudentIdQuery, SkillListVm>
    {
        private readonly IStudentProfileContext _dbContext;
        private readonly IMapper _mapper;

        public GetSkillsFromStudentIdQueryHandler(IStudentProfileContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SkillListVm> Handle(GetSkillsFromStudentIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == request.studentId);

            if (student == null)
            {
                throw new NotFoundException(nameof(Student), request.studentId);
            }

            var skills =
                await _dbContext.Skills
                .Where(x => x.Students.Contains(student))
                .ProjectTo<SkillLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new SkillListVm { Skills = skills };
        }
    }
}
