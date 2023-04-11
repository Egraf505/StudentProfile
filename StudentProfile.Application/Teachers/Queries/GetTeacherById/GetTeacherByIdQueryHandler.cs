using AutoMapper;
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

namespace StudentProfile.Application.Teachers.Queries.GetTeacherById
{
    internal class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherLookupDto>
    {
        private readonly IStudentProfileContext _context;
        private readonly IMapper _mapper;

        public GetTeacherByIdQueryHandler(IStudentProfileContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherLookupDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == request.TeacherId);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(Domain.Teacher), request.TeacherId);
            }

            var dto = _mapper.Map<TeacherLookupDto>(teacher);

            return dto;
        }
    }
}
