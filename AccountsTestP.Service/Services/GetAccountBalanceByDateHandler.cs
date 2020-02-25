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
    public class GetAccountBalanceByDateHandler: IRequestHandler<GetAccountBalanceByDateQuery, ResponseBaseDto>
    {
        private IAccountsHistoryRepository _accountHistoryRepository;
        private IAccountHistorySingleDxos _accountHistorySingleDxos;

        public GetAccountBalanceByDateHandler(IAccountsHistoryRepository accountHistoryRepository, IAccountHistorySingleDxos accountHistorySingleDxos) 
        {
            _accountHistoryRepository = accountHistoryRepository;
            _accountHistorySingleDxos = accountHistorySingleDxos;
        }

        public async Task<ResponseBaseDto> Handle(GetAccountBalanceByDateQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountHistoryRepository.GetBalanceByDate(request.AccountId, request.DateBy);
            if (account == null)
                return null;
            var result = _accountHistorySingleDxos.MapAccountHistoryModel(account);

            return new ResponseOkDto<AccountHistoryDto>()
            {
                Status = "Ok",
                Result = result
            };

        }
    }
}
