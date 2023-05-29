﻿
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Common.Exeptions;
using StudentProfile.Application.Interfaces;

namespace StudentProfile.Application.Account.Queries.LogIn
{

    public class LoginCommandHandler : IRequestHandler<LogInCommand, LoginInVm>
    {
        private readonly IStudentProfileContext _dbContext;

        public LoginCommandHandler(IStudentProfileContext dbContex)
        {
            _dbContext = dbContex;
        }

        public async Task<LoginInVm> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Login == request.Login && teacher.Password == request.Password);       

            if (user?.Id != 0 && user != null)
            {
                return new LoginInVm() { UserId = user.Id, IsTheacher = true };
            }            

            var student = await _dbContext.Students.FirstOrDefaultAsync(student => student.Login == request.Login && student.Password == request.Password);

            if (user?.Id != 0 && user != null)
            {
                return new LoginInVm() { UserId = user.Id, IsTheacher = false };
            }

            throw new NotFoundException("User", "");

        }
    }
}
