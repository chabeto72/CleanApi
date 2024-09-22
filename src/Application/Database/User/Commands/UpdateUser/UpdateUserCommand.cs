using Application.Database.User.Commands.CreateUser;
using Application.DataBase;
using AutoMapper;
using Domain.Entities.User;
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

        public async Task<UpdateUserModel> Execute (UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
             _dataBaseService.User.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
