using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Events.Queries.GetDetailsFromEvent
{
    public class EventDetailVm : IMapWith<Event>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventDetailVm>()
                .ForMember(eventDetailsVm => eventDetailsVm.Id,
                opt => opt.MapFrom(@event => @event.Id))
                .ForMember(eventDetailsVm => eventDetailsVm.Title,
                opt => opt.MapFrom(@event => @event.Title))
                .ForMember(eventDetailsVm => eventDetailsVm.Description,
                opt => opt.MapFrom(@event => @event.Description));
        }
    }
}
