using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Application.Events.Queries.GetEventList;
using StudentProfile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfile.Application.Skills.Queries.GetSkillList
{
    public class SkillLookupDto : IMapWith<Skill>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Point { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Skill, SkillLookupDto>()
                .ForMember(skillDto => skillDto.Id,
                opt => opt.MapFrom(skill => skill.Id))
                .ForMember(skillDto => skillDto.Title,
                opt => opt.MapFrom(skill => skill.Title))
                .ForMember(skillDto => skillDto.Description,
                opt => opt.MapFrom(skill => skill.Description))
                .ForMember(skillDto => skillDto.Point,
                opt => opt.MapFrom(skill => skill.Point));
        }
    }
}
