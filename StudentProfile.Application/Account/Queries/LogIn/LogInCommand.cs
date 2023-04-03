using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Account.Queries.LogIn
{
    public class LogInCommand : IRequest<int>
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
