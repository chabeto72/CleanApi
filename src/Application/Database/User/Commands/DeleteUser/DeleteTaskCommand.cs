using Application.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.DeleteUser
{
    public class DeleteTaskCommand : IDeleteTaskCommand
    {
        private readonly IDataBaseService _databaseService;
        public DeleteTaskCommand(IDataBaseService dataBaseService)
        {
            _databaseService = dataBaseService;
        }

        public async Task<bool> Execute(Guid idTask)
        {
            var entity = await _databaseService.TaskUser.FirstOrDefaultAsync(x => x.TaskID == idTask);
            if (entity == null)
                return false;

            

            _databaseService.TaskUser.Remove(entity);

            return await _databaseService.SaveAsync();
        }
    }
}
