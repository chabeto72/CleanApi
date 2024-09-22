using Application.DataBase;
using AutoMapper;
using Domain.Entities.User;
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
            var entity = _mapper.Map<UserEntity>(model);
            await _dataBaseService.User.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
