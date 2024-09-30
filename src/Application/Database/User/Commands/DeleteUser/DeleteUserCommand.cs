using Application.DataBase;
using Domain.Entities;
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
            var entity = await _databaseService.User.FirstOrDefaultAsync(x => x.UserID == idUser);
            if (entity == null)
                return false;

            entity.Active = false;

            _databaseService.User.Update(entity);

            return await _databaseService.SaveAsync();
        }
    }
}
