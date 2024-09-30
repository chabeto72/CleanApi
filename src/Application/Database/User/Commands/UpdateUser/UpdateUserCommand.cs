using Application.Database.User.Commands.CreateUser;
using Application.DataBase;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.UpdateUser
{
    
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;

        public UpdateUserCommand(IDataBaseService dataBaseService,IMapper mapper) { 
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            //var entity = _mapper.Map<Domain.Entities.User>(model);
            var existUserEntity = _dataBaseService.User.Where(x => x.UserID == model.Id).FirstOrDefault();
            existUserEntity.FirtsName = model.Nombre;
            existUserEntity.Address = model.Direccion;
            existUserEntity.UserID = model.Id;
            existUserEntity.Email = model.Correo;
            existUserEntity.NumberDocument = model.Documento;

            var rolId = _dataBaseService.Rol.Where(x => x.Code == model.codigo_rol).Select(x => x.RolID).FirstOrDefault();
            existUserEntity.RolUser = rolId;
            _dataBaseService.User.Update(existUserEntity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
