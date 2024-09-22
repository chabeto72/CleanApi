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
            var ListEntity = await _dataBaseService.User.ToListAsync();
            return _mapper.Map<List<GetAllUserModel>>(ListEntity);
        }
    }
}
