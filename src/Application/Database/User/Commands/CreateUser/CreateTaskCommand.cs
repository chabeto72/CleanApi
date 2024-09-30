using Application.DataBase;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.CreateUser
{
    public class CreateTaskCommand: ICreateTaskCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public CreateTaskCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService ?? throw new ArgumentNullException(nameof(dataBaseService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateTaskModel> Execute(CreateTaskModel model)
        {
            var userId = _dataBaseService.User.Where(x => x.UserID == model.Id_asignado).FirstOrDefault();

            Domain.Entities.TaskUser? userEntity = _dataBaseService.TaskUser.Where(x => x.Name == model.Nombre_tarea).FirstOrDefault();
            if (userEntity == null)
            {
                userEntity = new();
                userEntity.TaskID = Guid.NewGuid();
                userEntity.Name = model.Nombre_tarea;
                userEntity.State = model.Estado;
                userEntity.DateTask = model.Fecha;
                userEntity.UserTask = userId?.UserID;              
                userEntity.Detail = model.Nota ;              
            }          

            await _dataBaseService.TaskUser.AddAsync(userEntity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
    
}
