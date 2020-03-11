using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using AccountsTestP.Service.Helper;
using MediatR;

namespace AccountsTestP.Service.Services
{
    /// <summary>
    /// Класс handler'а для обработки запроса на получение всех проводок вхождящих в указанную по ее Id операцияю
    /// </summary>
    public class GetAccountForOperationHandler: IRequestHandler<GetAccountHistoryForOperationQuery, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        private readonly ReportCreatorHelper _helper;

        /// <summary>
        /// Конструктор handler'а для обработки запроса на получение всех проводок вхождящих в указанную по ее Id операцияю
        /// </summary>
        /// <param name="accountsHistoryRepository">Объект типа класса работы с таблицей журнала проводок</param>
        /// <param name="accountHistoryDxos">Объект класса методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки</param>
        public GetAccountForOperationHandler(IAccountsHistoryRepository accountsHistoryRepository, IAccountHistoryDxos accountHistoryDxos) 
        {
            _accountHistoryDxos = accountHistoryDxos;
            _accountsHistoryRepository = accountsHistoryRepository;
            _helper = new ReportCreatorHelper(_accountHistoryDxos);
        }
        /// <summary>
        /// Handler для обработки запроса на получение всех проводок вхождящих в указанную по ее Id операцияю
        /// </summary>
        /// <param name="request">Pапроса на получение всех проводок вхождящих в указанную по ее Id операцияю</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> Handle(GetAccountHistoryForOperationQuery request, CancellationToken cancellationToken)
        {
            var operationList = _helper.GetAccountList(await _accountsHistoryRepository.GetListForOperationAsync(request.OperationId));
            if (operationList.Count == 0)
                return null;
            return new ResponseOkDto<List<AccountHistoryDto>>
            {
                Status = "Ok",
                Result = operationList
            };

        }
    }
}
