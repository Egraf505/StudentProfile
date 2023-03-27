using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Application.Events.Commnad.CreateEvent;

namespace StudentProfile.WebApi.Models
{
    public class CreateEventDto : IMapWith<CreateEventCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventDto, CreateEventCommand>()
                .ForMember(eventCommand => eventCommand.Title,
                opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Description,
                opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(eventCommand => eventCommand.TeacherId,
                opt => opt.MapFrom(eventDto => eventDto.TeacherId));
        }
    }
}
