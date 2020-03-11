using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    /// <summary>
    /// Класс методов работы с таблицей типов счетов
    /// </summary>
    public interface IAccountTypeRepository: IRepository<AccountTypeModel>
    {
        /// <summary>
        /// Получить тип счета по его Id
        /// </summary>
        /// <param name="AccountTypeId">Id типа счета</param>
        /// <returns>Тип счета</returns>
        Task<AccountTypeModel> GetAccountType(int AccountTypeId);
        /// <summary>
        /// Получить список всех типов счетов
        /// </summary>
        /// <returns>Список всех типов счетов</returns>
        Task<List<AccountTypeModel>> GetAllAccountTypes();
    }
}
