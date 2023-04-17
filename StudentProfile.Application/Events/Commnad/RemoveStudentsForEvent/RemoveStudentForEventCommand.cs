using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Events.Commnad.RemoveStudentsForEvent
{
    public class RemoveStudentForEventCommand : IRequest
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }
    }
}
