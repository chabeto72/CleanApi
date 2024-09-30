using Application.DataBase;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetAllUser
{
    public class GetAllUserQuery : IGetAllUserQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllUserQuery(IDataBaseService dataBaseService, IMapper mapper)    
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserModel>> Execute()
        {
            //var ListEntity = await _dataBaseService.User.Include(x => x.Rol).ToListAsync();
            var ListEntity = await (from  user in _dataBaseService.User
                                    join rol in _dataBaseService.Rol 
                                    on user.RolUser equals rol.RolID into rolGroup
                                    from rol in rolGroup.DefaultIfEmpty()
                                    where user.Active == true
                                    select new GetAllUserModel
                                    {
                                        Id = user.UserId,
                                        Nombre = user.FirtsName,
                                        Correo = user.Email,
                                        Direccion = user.Address,
                                        Codigo_rol = rol.Code,
                                        Documento = user.NumberDocument,
                                        Rol = rol.RolName
                                    } ).ToListAsync();
           
            return ListEntity;
        }
    }
}
