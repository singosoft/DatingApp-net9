using API.Data;
using API.DTOs;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles :Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
        .ForMember(u => u.Age , o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
        .ForMember(u => u.PhotoUrl, o => o.MapFrom(s => s.Photos.SingleOrDefault(p => p.IsMain)!.Url))
        ;
        CreateMap<Photo , PhotoDto>();
    }

    
}
