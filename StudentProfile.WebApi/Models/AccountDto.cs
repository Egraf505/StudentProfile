using AutoMapper;
using StudentProfile.Application.Account.Queries.LogIn;
using StudentProfile.Application.Common.Mapping;

namespace StudentProfile.WebApi.Models
{
    public class AccountDto : IMapWith<LogInCommand>
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountDto, LogInCommand>()
                .ForMember(logInCommmand => logInCommmand.Login,
                opt => opt.MapFrom(accountDto => accountDto.Login))
                .ForMember(logInCommmand => logInCommmand.Password,
                opt => opt.MapFrom(accountDto => accountDto.Password));
        }
    }
}
