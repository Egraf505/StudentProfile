using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Application.Events.Queries.GetEventList;
using StudentProfile.Domain;

namespace StudentProfile.Application.Teachers.Queries
{
    public class TeacherLookupDto : IMapWith<Domain.Teacher>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? MiddleName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Teacher, TeacherLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Name,
                opt => opt.MapFrom(note => note.Name))
                .ForMember(noteDto => noteDto.SurName,
                opt => opt.MapFrom(note => note.SurName))
                .ForMember(noteDto => noteDto.MiddleName,
                opt => opt.MapFrom(note => note.MiddleName));
        }
    }
}
