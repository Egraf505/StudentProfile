using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Skills.Queries.GetSkillList;
using StudentProfile.Application.Skills.Queries.GetSkillsFromStudentId;

namespace StudentProfile.WebApi.Controllers
{
    public class SkillController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SkillListVm>> GetAll()
        {
            var query = new GetSkillListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Получение навыков студента по id.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<SkillListVm>> GetByStudentId(int studentId)
        {
            var query = new GetSkillsFromStudentIdQuery() { studentId = studentId };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
