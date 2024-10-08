﻿using Application.DataBase;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.CreateUser
{
    public class CreateUserCommand: ICreateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public CreateUserCommand(IDataBaseService  dataBaseService,IMapper mapper)
        {
            _dataBaseService = dataBaseService ?? throw new ArgumentNullException(nameof(dataBaseService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var rolId = _dataBaseService.Rol.Where(x => x.Code == model.codigo_rol).FirstOrDefault();

            Domain.Entities.User? userEntity = _dataBaseService.User.Where(x => x.NumberDocument == model.Documento).FirstOrDefault();
            if (userEntity == null)
            {
                userEntity = new();
                userEntity.FirtsName = model.Nombre;
                userEntity.Address = model.Direccion;
                userEntity.Active = true;
                userEntity.RolUser = rolId?.RolID;
                userEntity.Email = model.Correo;
                userEntity.NumberDocument = model.Documento;
                userEntity.Password = "task123";
            }

            await _dataBaseService.User.AddAsync(userEntity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
