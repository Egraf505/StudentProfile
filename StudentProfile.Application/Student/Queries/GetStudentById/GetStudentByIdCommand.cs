using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Student.Queries.GetStudentById
{
    public class GetStudentByIdCommand : IRequest<StudentVm>
    {
        public int studentId { get; set; }  
    }
}
