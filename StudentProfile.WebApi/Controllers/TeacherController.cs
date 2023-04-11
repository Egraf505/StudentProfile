using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Teacher.Queries.GetTeacherList;
using StudentProfile.Application.Teachers.Queries;
using StudentProfile.Application.Teachers.Queries.GetTeacherById;
using StudentProfile.Application.Teachers.Queries.GetTeacherList;

namespace StudentProfile.WebApi.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly IMapper _mapper;

        public TeacherController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TeacherListVm>> GetTeachers()
        {
            var query = new GetTeacherListQuery();

            var teacherListVm = await Mediator.Send(query);

            return Ok(teacherListVm);
        }

        [HttpGet("teacherId")]
        public async Task<ActionResult<TeacherLookupDto>> GetTeacherById(int teacherId)
        {
            var query = new GetTeacherByIdQuery() { TeacherId = teacherId };

            var teacher = await Mediator.Send(query);

            return Ok(teacher);
        }
    }
}
