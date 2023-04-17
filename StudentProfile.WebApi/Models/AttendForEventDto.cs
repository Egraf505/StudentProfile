using AutoMapper;
using StudentProfile.Application.Common.Mapping;
using StudentProfile.Application.Events.Commnad.AddStudentsForEvent;

namespace StudentProfile.WebApi.Models
{
    public class RequestForEventDto
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }
    }
}
