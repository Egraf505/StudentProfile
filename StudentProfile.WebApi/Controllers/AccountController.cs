using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProfile.Application.Account.Queries.LogIn;
using StudentProfile.WebApi.Models;

namespace StudentProfile.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost] 
        public async Task<ActionResult<LoginInVm>> LogIn([FromBody] AccountDto accountDto)
        {
            if (accountDto == null)
            {
                return BadRequest();
            }

            var query = _mapper.Map<LogInCommand>(accountDto);

            var logInVm = await Mediator.Send(query);

            return Ok(logInVm);
        }
    }
}
