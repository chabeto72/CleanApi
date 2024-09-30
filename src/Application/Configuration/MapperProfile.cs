using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.UpdateUser;
using Application.Database.User.Querys.GetAllTask;
using Application.Database.User.Querys.GetAllUser;
using Application.Database.User.Querys.GetUserByCodeDocumentNumber;
using Application.Database.User.Querys.GetUserById;
using AutoMapper;
using Domain.Entities;


namespace Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UpdateUserModel, User>()
            .ForMember(target => target.UserID, opt => opt.MapFrom(source => source.Id))
            .ForMember(target => target.FirtsName, opt => opt.MapFrom(source => source.Nombre))
            .ForMember(target => target.Email, opt => opt.MapFrom(source => source.Correo))
            .ForMember(target => target.Address, opt => opt.MapFrom(source => source.Direccion))
            .ForMember(target => target.NumberDocument, opt => opt.MapFrom(source => source.Documento));

            CreateMap<User, GetAllUserModel>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.UserID))
                .ForMember(target => target.Nombre, opt => opt.MapFrom(source => source.FirtsName))
                .ForMember(target => target.Correo, opt => opt.MapFrom(source => source.Email))
                .ForMember(target => target.Direccion, opt => opt.MapFrom(source => source.Address))
                .ForMember(target => target.Codigo_rol, opt => opt.MapFrom(source => source.RolUserNavigation.Code))
                .ForMember(target => target.Rol, opt => opt.MapFrom(source => source.RolUserNavigation.RolName))
                .ForMember(target => target.Documento, opt => opt.MapFrom(source => source.NumberDocument));

            CreateMap<TaskUser, GetAllTaskModel>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.TaskID))
                .ForMember(target => target.Nombre_tarea, opt => opt.MapFrom(source => source.Name))
                .ForMember(target => target.Estado, opt => opt.MapFrom(source => source.State))
                .ForMember(target => target.Nota, opt => opt.MapFrom(source => source.Detail))
                .ForMember(target => target.Fecha, opt => opt.MapFrom(source => source.DateTask))
                .ForMember(target => target.Nombre_asignado, opt => opt.MapFrom(source => source.UserTaskNavigation.FirtsName))
                .ForMember(target => target.Id_asignado, opt => opt.MapFrom(source => source.UserTask));

            
            //CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<User, GetUserByCodeDocumentNumberModel>()
                .ForMember(target => target.UserId, opt => opt.MapFrom(source => source.UserID)).ReverseMap();


        }
    }
}
