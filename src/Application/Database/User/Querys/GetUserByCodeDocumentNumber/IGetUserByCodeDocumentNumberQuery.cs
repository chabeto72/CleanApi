using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetUserByCodeDocumentNumber
{
    public interface IGetUserByCodeDocumentNumberQuery
    {
        Task<GetUserByCodeDocumentNumberModel> Execute(string code, string documentNumber);
    }
}
