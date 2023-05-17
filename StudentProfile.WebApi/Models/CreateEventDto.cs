using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Application.Events.Commnad.CreateEvent;
using StudentProfile.Domain;

namespace StudentProfile.WebApi.Models
{
    public class CreateEventDto : IMapWith<CreateEventCommand>
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TeacherId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public List<Skill>? Skills { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventDto, CreateEventCommand>()
                .ForMember(eventCommand => eventCommand.Title,
                opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Description,
                opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(eventCommand => eventCommand.TeacherId,
                opt => opt.MapFrom(eventDto => eventDto.TeacherId))
                .ForMember(eventCommand => eventCommand.Begin,
                opt => opt.MapFrom(eventDto => eventDto.Begin))
                .ForMember(eventCommand => eventCommand.End,
                opt => opt.MapFrom(eventDto => eventDto.End))
            .ForMember(eventCommand => eventCommand.Skills,
                opt => opt.MapFrom(eventDto => eventDto.Skills));
        }
    }
}
