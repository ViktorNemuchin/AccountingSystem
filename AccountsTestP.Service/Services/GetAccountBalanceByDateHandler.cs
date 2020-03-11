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
    /// Класс handler'а для обработки запроса на получении баланса счета на дату 
    /// </summary>
    public class GetAccountBalanceByDateHandler: IRequestHandler<GetAccountBalanceByDateQuery, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountHistoryRepository;
        private readonly IAccountHistorySingleDxos _accountHistorySingleDxos;
        /// <summary>
        /// Конструктор handler'а для обработки запроса на получении баланса счета на дату  
        /// </summary>
        /// <param name="accountHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="accountHistorySingleDxos">Объект класса методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки</param>
        public GetAccountBalanceByDateHandler(IAccountsHistoryRepository accountHistoryRepository, IAccountHistorySingleDxos accountHistorySingleDxos) 
        {
            _accountHistoryRepository = accountHistoryRepository;
            _accountHistorySingleDxos = accountHistorySingleDxos;
        }
        /// <summary>
        /// Handler для обработки запроса на получении баланса счета на дату
        /// </summary>
        /// <param name="request">Обхект запроса на получение баланса счета на дату</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> Handle(GetAccountBalanceByDateQuery request, CancellationToken cancellationToken)
        {
            if (request.AccountId == Guid.Empty) 
            {
                return null;
            }
            var account = await _accountHistoryRepository.GetBalanceByDate(request.AccountId, request.DateBy);
            if (account == null)
                return null;
            ReportAccountBalanceDto result = new ReportAccountBalanceDto();

            if (account.SourceAccountId == request.AccountId) 
            {
                result.AccountId = account.SourceAccountId;
                result.Balance = account.SourceAccountBalance;
                result.DueDate = account.DueDate;
            }
            else 
            {
                result.AccountId = account.DestinationAccountId;
                result.Balance = account.DestinationAccountBalance;
                result.DueDate = account.DueDate;
            }
            return new ResponseOkDto<ReportAccountBalanceDto>()
            {
                Status = "Ok",
                Result = result
            };

        }
    }
}
