using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Application.Events.Commnad.AddStudentsForEvent;

namespace StudentProfile.WebApi.Models
{
    public class AttendForEventDto : IMapWith<AttendTheEventCommand>
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AttendForEventDto, AttendTheEventCommand>()
                .ForMember(attendTheEventCommand => attendTheEventCommand.EventId,
                opt => opt.MapFrom(attendForEventDto => attendForEventDto.EventId))
                .ForMember(attendTheEventCommand => attendTheEventCommand.StudentId,
                opt => opt.MapFrom(attendForEventDto => attendForEventDto.StudentId));
        }
    }
}
