using AutoMapper;
using WhiskyMan.Entities;
using WhiskyMan.Models.Dtos.User;
using WhiskyMan.Models.User;

namespace WhiskyMan.Repositories.Mapping
{
    static class UserMaps
    {
        public static void CreateMaps(IMapperConfigurationExpression mce)
        {
            mce.CreateMap<User, UserModel>();
            mce.CreateMap<UserForAuthModel, User>();
            mce.CreateMap<User, UserForAuthModel>();
            mce.CreateMap<User, UserView>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(user => $"{user.FirstName} {user.LastName}"));
            mce.CreateMap<UserForRegister, UserForAuthModel>();
        }
    }
}
