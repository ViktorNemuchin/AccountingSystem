using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using System.Threading.Tasks;
using System.Threading;
using AccountsTestP.Service.Dxos;

namespace AccountsTestP.Service.Services
{
    /// <summary>
    /// Класс handler'а запроса на получкения записи всех проводок с указанной даты для счета списания и зачисления в рамках корректирующей проводки
    /// </summary>
    public class GetAccountHistoryFromDateQueryHandler: IRequestHandler<GetAccountHistoryFromDateQuery, List<AccountHistoryDto>>
    {

        private readonly IAccountsHistoryRepository _accountHistoryRepository;
        private readonly IAccountHistorySingleDxos _accountHistorySingleDxos;
        /// <summary>
        /// Конструктор handler'а запроса на получкения записи всех проводок с указанной даты для счета списания и зачисления в рамках корректирующей проводки
        /// </summary>
        /// <param name="accountHistorySingleDxos">Объект класса методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки</param>
        /// <param name="accountHistoryRepository">Объект класса работы с таблицей журнала проводок</param>
        public GetAccountHistoryFromDateQueryHandler(IAccountHistorySingleDxos accountHistorySingleDxos, IAccountsHistoryRepository accountHistoryRepository) 
        {

            _accountHistoryRepository = accountHistoryRepository;
            _accountHistorySingleDxos = accountHistorySingleDxos;
        }
        /// <summary>
        /// Handler запроса на получкения записи всех проводок с указанной даты для счета списания и зачисления в рамках корректирующей проводки
        /// </summary>
        /// <param name="request">Запрос на получкения записи всех проводок с указанной даты для счета списания и зачисления в рамках корректирующей проводки</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async  Task<List<AccountHistoryDto>> Handle(GetAccountHistoryFromDateQuery request, CancellationToken cancellationToken)
        {
            var accountHistoryDtoList = new List<AccountHistoryDto>(); 
            await foreach(var entry in _accountHistoryRepository.GetAccountHistoryFromDate(request.DateTimeFrom, request.SourceAccountId, request.DestinationAccountId)) 
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
