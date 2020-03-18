using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IAccountHistorySingleDxos _accountHistorySingleDxos;
        /// <summary>
        /// Конструктор класса методов для создания отчета
        /// </summary>
        /// <param name="accountHistoryDxos"></param>
        public ReportCreatorHelper(IAccountHistoryDxos accountHistoryDxos, IAccountHistorySingleDxos accountHistorySingleDxos)
        {
            _accountHistoryDxos = accountHistoryDxos;
            _accountHistorySingleDxos = accountHistorySingleDxos;
        }
        /// <summary>
        /// Преобразования списка записей журнала проводок в список DTO журнала проводок
        /// </summary>
        /// <param name="entryList">Список проводок</param>
        /// <returns></returns>
        public List<AccountHistoryDto> GetAccountList(List<AccountHistoryModel> entryList)
        {
            return _accountHistoryDxos.MapAccountHistoryDto(entryList);
        }
        /// <summary>
        /// Получение баланса счета на указанную дату
        /// </summary>
        /// <param name="entryList">Список проводок по счету с момента </param>
        /// <param name="accountId"> Id счета </param>
        /// <returns></returns>
        public async Task<ReportAccountBalanceDto> SetReportAccount(IAsyncEnumerable<AccountHistoryModel> entryList, Guid accountId) 
        {
            var transformedList = await GetAccountHistoryDtoList(entryList);
            if (transformedList == null || transformedList.Count == 0 )
                return null;
            return CheckAccountHistoryDto(GetLastEntry(transformedList), accountId);
        }

        /// <summary>
        ///  Сортировка списка проводок по дате применения
        /// </summary>
        /// <param name="entryList">Список проводок</param>
        /// <returns></returns>
        private async Task<List<AccountHistoryDto>> GetAccountHistoryDtoList(IAsyncEnumerable<AccountHistoryModel> entryList)
        {
            var outEntryList = new List<AccountHistoryDto>();
            await foreach (var entry in entryList)
            {
                var outEntry = _accountHistorySingleDxos.MapAccountHistoryModel(entry);
                outEntryList.Add(outEntry);
            }
            return outEntryList.OrderBy(x=>x.DueDateTime).ToList();
        }

        private AccountHistoryDto GetLastEntry(List<AccountHistoryDto> entryList) 
        {
            return entryList.LastOrDefault();
        }
        private ReportAccountBalanceDto CheckAccountHistoryDto (AccountHistoryDto entryToCheck, Guid accountId)
        {
            ReportAccountBalanceDto result = new ReportAccountBalanceDto();

            if (entryToCheck.SourceAccountId == accountId)
            {
                result.AccountId = entryToCheck.SourceAccountId;
                result.Balance = entryToCheck.SourceBalance;
                result.DueDate = entryToCheck.DueDateTime;
            }
            else
            {
                result.AccountId = entryToCheck.DestinationAccounId;
                result.Balance = entryToCheck.DestinationBalance;
                result.DueDate = entryToCheck.DueDateTime;
            }
            return result;
        }
    }
}
