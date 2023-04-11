using MediatR;
using StudentProfile.Application.Teacher.Queries.GetTeacherList;

namespace StudentProfile.Application.Teachers.Queries.GetTeacherList
{
    public class GetTeacherListQuery : IRequest<TeacherListVm>
    {
    }
}
