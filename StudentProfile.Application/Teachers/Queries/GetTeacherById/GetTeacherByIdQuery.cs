using MediatR;

namespace StudentProfile.Application.Teachers.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery : IRequest<TeacherLookupDto>
    {
        public int TeacherId { get; set; }  
    }
}
