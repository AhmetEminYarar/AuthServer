using AuthServer.Data.Entity;
using AuthServer.DTO.Request.Users;
using AuthServer.DTO.Response.Users;
using AutoMapper;

namespace AuthServer.DTO.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserAddRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.password));
            CreateMap<UserUpdateRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.password));
            CreateMap<User, UserGetResponse>();
            CreateMap<User, UserGetByTCKNResponse>()
                .ForMember(dest => dest.tckn, opt => opt.MapFrom(src => src.TCKN));


        }
    }
}
