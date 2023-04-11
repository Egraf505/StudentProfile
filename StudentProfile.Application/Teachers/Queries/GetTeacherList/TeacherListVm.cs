
using StudentProfile.Application.Teachers.Queries;

namespace StudentProfile.Application.Teacher.Queries.GetTeacherList
{
    public class TeacherListVm
    {
        public IList<TeacherLookupDto> Teachers { get; set; } = null!;
    }
}
