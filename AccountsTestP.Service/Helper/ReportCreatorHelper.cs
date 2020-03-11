using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AccountsTestP.Service.Dxos;

namespace AccountsTestP.Service.Helper
{

    /// <summary>
    /// Класс методов для создания отчетов
    /// </summary>
    public class ReportCreatorHelper
    {
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        /// <summary>
        /// Конструктор класса методов для создания отчета
        /// </summary>
        /// <param name="accountHistoryDxos"></param>
        public ReportCreatorHelper(IAccountHistoryDxos accountHistoryDxos) 
        {
            _accountHistoryDxos = accountHistoryDxos;
        }
        /// <summary>
        /// Преобразования списка записей журнала проводок в список DTO журнала проводок
        /// </summary>
        /// <param name="entryList"></param>
        /// <returns></returns>
        public List<AccountHistoryDto> GetAccountList(List<AccountHistoryModel> entryList)
        {
            return _accountHistoryDxos.MapAccountHistoryDto(entryList);
        }

    }
}
