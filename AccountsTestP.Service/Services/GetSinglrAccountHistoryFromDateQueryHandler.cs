using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountsTestP.Service.Services
{
    /// <summary>
    /// Класс handler'а запроса на получение информации о провоодках по указанному счету с указанной даты до текущего момента 
    /// </summary>
    public class GetSinglrAccountHistoryFromDateQueryHandler: IRequestHandler<GetSingleAccountHistoryFromDateQuery, List<AccountHistoryDto>>
    {
        private readonly IAccountsHistoryRepository _accountHistoryRepository;
        private readonly IAccountHistorySingleDxos _accountHistorySingleDxos;
        /// <summary>
        /// Конструктор handler'а запроса на получение информации о провоодках по указанному счету с указанной даты до текущего момента 
        /// </summary>
        /// <param name="accountHistorySingleDxos">Объект класса методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки</param>
        /// <param name="accountHistoryRepository">Объект класса работы с таблицей журнала проводок</param>
        public GetSinglrAccountHistoryFromDateQueryHandler(IAccountHistorySingleDxos accountHistorySingleDxos,  IAccountsHistoryRepository accountHistoryRepository)
        {
            _accountHistoryRepository = accountHistoryRepository;
            _accountHistorySingleDxos = accountHistorySingleDxos;
        }
        /// <summary>
        /// Handler запроса на получение информации о провоодках по указанному счету с указанной даты до текущего момента 
        /// </summary>
        /// <param name="request">Объект класса запроса на получение информации о провоодках по указанному счету с указанной даты до текущего момента</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<List<AccountHistoryDto>> Handle(GetSingleAccountHistoryFromDateQuery request, CancellationToken cancellationToken)
        {
            var accountHistoryDtoList = new List<AccountHistoryDto>();
            await foreach (var entry in _accountHistoryRepository.GetAccountHistoryFromDate(request.DateTimeFrom, request.AccountId))
            {
                accountHistoryDtoList.Add(_accountHistorySingleDxos.MapAccountHistoryModel(entry));
            }
            if (accountHistoryDtoList.Count != 0)
            {
                return accountHistoryDtoList;
            }
            return null;
        }
    }
}
