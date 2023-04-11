using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Interfaces;
using StudentProfile.Application.Teacher.Queries.GetTeacherList;

namespace StudentProfile.Application.Teachers.Queries.GetTeacherList
{
    public class GetTeacherListQueryHandler : IRequestHandler<GetTeacherListQuery, TeacherListVm>
    {
        private readonly IStudentProfileContext _context;
        private readonly IMapper _mapper;

        public GetTeacherListQueryHandler(IStudentProfileContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherListVm> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            var teachers = 
                await _context.Teachers
                .ProjectTo<TeacherLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TeacherListVm { Teachers = teachers };
        }
    }
}
