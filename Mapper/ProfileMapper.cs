using AutoMapper;
using Login.Data.DTO;
using Login.Data.DTO.Request;
using Login.Data.DTO.Response;
using Login.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.Utils.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            // List to hash map.
            CreateMap<List<string>, HashSet<string>>()
                .ConvertUsing(s => s.ToHashSet<string>());

            //request mapping
            CreateMap<UserRegisterRequest, AppUser>();

            CreateMap<UserEditRequest, AppUser>();
            //response mapping
            CreateMap<AppUser, UserDataResponse>();
            CreateMap<AppUser, UserListResponse>();
            //CreateMap<AppUser, ViewUserResponse>();
            CreateMap<IdentityRole, RoleDataResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Name));

           
        }
    }
}
