using MediatR;
using StudentProfile.Application.Skills.Queries.GetSkillList;

namespace StudentProfile.Application.Skills.Queries.GetSkillsFromStudentId
{
    public class GetSkillsFromStudentIdQuery : IRequest<SkillListVm>
    {
        public int studentId { get; set; }
    }
}
