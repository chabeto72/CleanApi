using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.UpdateUser;
using Application.Database.User.Querys.GetAllUser;
using Application.Database.User.Querys.GetUserByCodeDocumentNumber;
using Application.Database.User.Querys.GetUserById;
using AutoMapper;
using Domain.Entities.User;

namespace Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByCodeDocumentNumberModel>().ReverseMap();
        }
    }
}
