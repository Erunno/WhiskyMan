using AutoMapper;
using System.Linq;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Models.User;

namespace WhiskyMan.Repositories.Mapping
{
    static class UserMaps
    {
        public static void CreateMaps(IMapperConfigurationExpression mce)
        {
            mce.CreateMap<User, UserModel>()
                .ForMember(
                dest => dest.Roles,
                opt => opt.MapFrom(user => user.Roles.Select(r => r.Name).ToList()));
            mce.CreateMap<User, UserView>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(user => $"{user.FirstName} {user.LastName}"));
            mce.CreateMap<User, UserReference>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(user => $"{user.FirstName} {user.LastName}"));
            mce.CreateMap<UserForRegister, User>();
        }
    }
}
