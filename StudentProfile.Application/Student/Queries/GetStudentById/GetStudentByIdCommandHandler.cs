using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;

namespace StudentProfile.Application.Student.Queries.GetStudentById
{
    internal class GetStudentByIdCommandHandler 
        : IRequestHandler<GetStudentByIdCommand, StudentVm>
    {
        private readonly IStudentProfileContext _context;
        private readonly IMapper _mapper;

        public GetStudentByIdCommandHandler(IStudentProfileContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentVm> Handle(GetStudentByIdCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.Id == request.studentId, cancellationToken);

            if (student == null)
            {
                throw new NotFoundException(nameof(Domain.Student), request.studentId);
            }

            var studentVm = _mapper.Map<StudentVm>(student);

            return studentVm;
        }
    }
}
