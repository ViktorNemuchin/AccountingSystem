using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    public interface IAccountTypeRepository: IRepository<AccountTypeModel>
    {
        Task<AccountTypeModel> GetAccountType(int AccountTypeId);
        Task<List<AccountTypeModel>> GetAllAccountTypes();
    }
}
