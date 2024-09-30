using Application.Database.User.Querys.GetAllUser;
using Application.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetUserByCodeDocumentNumber
{
    public class GetUserByCodeDocumentNumberQuery: IGetUserByCodeDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetUserByCodeDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByCodeDocumentNumberModel> Execute(string password,string documentNumber)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.Password == password && x.NumberDocument == documentNumber);
            return _mapper.Map<GetUserByCodeDocumentNumberModel>(entity);
            
        }
    }
}
