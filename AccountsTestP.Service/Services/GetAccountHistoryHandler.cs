using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Service.Dxos;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Service.Services
{
    /// <summary>
    /// Класс handler'а запроса на получениt записей всех проводок по указанному счету
    /// </summary>
    public class GetAccountHistoryHandler : IRequestHandler<GetAccountHistoryQuery, ResponseBaseDto>
    {
        private readonly IAccountsHistoryRepository _accountsHistoryRepository;
        private readonly IAccountHistoryDxos _accountHistoryDxos;
        /// <summary>
        /// Конструктор handler'а запроса на получениt записей всех проводок по указанному счету
        /// </summary>
        /// <param name="accountsHistoryRepository">Объект класса работы с таблицей журнала проводок</param>
        /// <param name="accountHistoryDxos">Объект класас методов для преобразования сущности модели записи в журнале проводки в с DTO записи журнала проводки</param>
        public GetAccountHistoryHandler(IAccountsHistoryRepository accountsHistoryRepository, IAccountHistoryDxos accountHistoryDxos)
        {
            _accountHistoryDxos = accountHistoryDxos;
            _accountsHistoryRepository = accountsHistoryRepository;
        }
        /// <summary>
        /// Handler'а запроса на получениt записей всех проводок по указанному счету
        /// </summary>
        /// <param name="request">Запроса на получения списка всех проводок для указанного счета</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public async Task<ResponseBaseDto> Handle(GetAccountHistoryQuery request, CancellationToken cancellationToken)
        {
            var accountEntryList = await _accountsHistoryRepository.GetListAsync(request.AccountId);
            if (accountEntryList.Count != 0)
            {
                var accountHistoryDtoList = _accountHistoryDxos.MapAccountHistoryDto(accountEntryList);                 
                return new ResponseOkDto<List<AccountHistoryDto>>
                {
                    Status = "Ok",
                    Result = accountHistoryDtoList.ToList()
                };
            }
            return null;
        }
    }

}
