using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Skills.Queries.GetSkillList;

namespace StudentProfile.WebApi.Controllers
{
    public class SkillController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetSkillListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
