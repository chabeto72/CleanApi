using Application.Database.User.Querys.GetAllUser;
using Application.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetUserById
{
    public class GetUserByIdQuery: IGetUserByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetUserByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetAllUserModel> Execute(int userId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<GetAllUserModel>(entity);
        }
    }
}
