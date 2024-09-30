using Application.DataBase;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.UpdateUser
{
    public class UpdateTaskCommand: IUpdateTaskCommand
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;

        public UpdateTaskCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }
        public async Task<UpdateTaskModel> Execute(UpdateTaskModel model)
        {
          
            var existUserEntity = _dataBaseService.TaskUser.Where(x => x.TaskID == Guid.Parse(model.Id)).FirstOrDefault();
            existUserEntity.UserTask = model.Id_asignado;
            existUserEntity.State = model.Estado;
            existUserEntity.Detail = model.Nota;
            existUserEntity.Name = model.Nombre_tarea;
            existUserEntity.DateTask = model.Fecha;

            //var rolId = _dataBaseService.Rol.Where(x => x.Code == model.codigo_rol).Select(x => x.RolID).FirstOrDefault();
            //existUserEntity.RolUser = rolId;
            _dataBaseService.TaskUser.Update(existUserEntity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
