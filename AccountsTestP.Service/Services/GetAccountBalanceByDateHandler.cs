using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using AccountsTestP.Service.Helper;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountHistorySingleDxos _accountHistorySingleDxos;
        private readonly ReportCreatorHelper _reportCreatorHelper;
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        private readonly BaseHelper _helper;
        /// <summary>
        /// Конструктор handler'а для обработки запроса на получении баланса счета на дату  
        /// </summary>
        /// <param name="accountHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="accountHistorySingleDxos">Объект класса методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки</param>
        public GetAccountBalanceByDateHandler(IAccountsHistoryRepository accountHistoryRepository, IAccountRepository accountRepository,  IAccountHistorySingleDxos accountHistorySingleDxos, IAccountHistoryDxos accountHistoryDxos) 
        {
            _accountHistoryRepository = accountHistoryRepository;
            _accountHistorySingleDxos = accountHistorySingleDxos;
            _accountRepository = accountRepository;
            _accountHistoryDxos = accountHistoryDxos;
            _reportCreatorHelper = new ReportCreatorHelper(_accountHistoryDxos, _accountHistorySingleDxos);
            _helper = new BaseHelper(_accountRepository);
        }
        /// <summary>
        /// Handler для обработки запроса на получении баланса счета на дату
        /// </summary>
        /// <param name="request">Обхект запроса на получение баланса счета на дату</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> Handle(GetAccountBalanceByDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _reportCreatorHelper.SetReportAccount(_accountHistoryRepository.GetAccountHistoryByDate(request.DateBy, request.AccountId), request.AccountId);
            if (result == null)
                return null;
            return new ResponseOkDto<ReportAccountBalanceDto>()
            {
                Status = "Ok",
                Result = result
            };

        }
    }
}
