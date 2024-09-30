using Application.DataBase;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.DeleteUser
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly IDataBaseService _databaseService;
        public DeleteUserCommand(IDataBaseService dataBaseService) {
            _databaseService = dataBaseService;
        }

        public async Task<bool> Execute(int idUser)
        {
            var entity = await _databaseService.User.FirstOrDefaultAsync(x => x.UserId == idUser);
            if (entity == null)
                return false;

            entity.Active = false;

            _databaseService.User.Update(entity);
            //_databaseService.User.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}
