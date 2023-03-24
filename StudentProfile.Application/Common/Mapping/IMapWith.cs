using AutoMapper;

namespace StudentProfile.Application.Common.Mapping
{
    public interface IMapWith<T> 
    {
        void Mapping(Profile profile)=>
            profile.CreateMap(typeof(T), GetType());
    }
}
