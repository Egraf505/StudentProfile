﻿using AutoMapper;
using StudentProfile.Application.Common.Mapping;

namespace StudentProfile.Application.Student.Queries.GetStudentById
{
    public class StudentVm : IMapWith<Domain.Student>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? MiddleName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Student, StudentVm>()
                .ForMember(studentDto => studentDto.Id,
                opt => opt.MapFrom(student => student.Id))
                .ForMember(studentDto => studentDto.Name,
                opt => opt.MapFrom(student => student.Name))
                .ForMember(studentDto => studentDto.SurName,
                opt => opt.MapFrom(student => student.SurName))
                .ForMember(studentDto => studentDto.MiddleName,
                opt => opt.MapFrom(student => student.MiddleName));
        }
    }
}
