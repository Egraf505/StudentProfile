using MediatR;
using StudentProfile.Application.Events.Queries.GetEventList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Events.Queries.GetEvents
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
    }
}
