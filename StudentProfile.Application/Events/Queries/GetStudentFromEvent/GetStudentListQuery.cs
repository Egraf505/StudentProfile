using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Events.Queries.GetStudentFromEvent
{
    public class GetStudentListQuery : IRequest<StudentListVm>
    {
        public int EventId { get; set; }
    }
}
