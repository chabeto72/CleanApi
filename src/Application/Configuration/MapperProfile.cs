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
            CreateMap<UpdateUserModel, UserEntity>();
                //.ForMember(target => target.UserId, opt => opt.MapFrom(source => source.Id));
                //.ForMember(target => target.FirtsName, opt => opt.MapFrom(source => source.Nombre))
                //.ForMember(target => target.Email, opt => opt.MapFrom(source => source.Correo))
                //.ForMember(target => target.Address, opt => opt.MapFrom(source => source.Direccion))               
                //.ForMember(target => target.NumberDocument, opt => opt.MapFrom(source => source.Documento));
                
            CreateMap<UserEntity, GetAllUserModel>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.UserId))
                .ForMember(target => target.Nombre, opt => opt.MapFrom(source => source.FirtsName))
                .ForMember(target => target.Correo, opt => opt.MapFrom(source => source.Email))
                .ForMember(target => target.Direccion, opt => opt.MapFrom(source => source.Address))
                .ForMember(target => target.Codigo_rol, opt => opt.MapFrom(source => source.Rol.Code))
                .ForMember(target => target.Rol, opt => opt.MapFrom(source => source.Rol.RolName))
                .ForMember(target => target.Documento, opt => opt.MapFrom(source => source.NumberDocument));
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByCodeDocumentNumberModel>().ReverseMap();

           
        }
    }
}
