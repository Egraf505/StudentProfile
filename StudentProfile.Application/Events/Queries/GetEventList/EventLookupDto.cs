using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Domain;

namespace StudentProfile.Application.Events.Queries.GetEventList
{
    public class EventLookupDto : IMapWith<Event>
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public List<Skill>? Skills { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDto => noteDto.Description,
                opt => opt.MapFrom(note => note.Description))
                .ForMember(noteDto => noteDto.TeacherId,
                opt => opt.MapFrom(note => note.CreatedTeacher.Id))
                .ForMember(noteDto => noteDto.Begin,
                opt => opt.MapFrom(note => note.Begin))
                .ForMember(noteDto => noteDto.End,
                opt => opt.MapFrom(note => note.End))
                .ForMember(noteDto => noteDto.Skills,
                opt => opt.MapFrom(note => note.Skills));
        }
    }
}
