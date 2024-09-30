using Application.Database.User.Querys.GetAllUser;
using Application.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetAllTask
{
    public class GetAllTaskQuery: IGetAllTaskQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllTaskQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllTaskModel>> Execute()
        {
            var ListEntity = await _dataBaseService.TaskUser.Include(x => x.UserTaskNavigation).ToListAsync();
            return _mapper.Map<List<GetAllTaskModel>>(ListEntity);
        }
    }
}
